using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float increaseSpeedValue = 2f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    void Update()
    {
        if (!playerHealth.playerIsDead)
        {
            PlayerWalking();
            PlayerRunning();
        }
    }

    private void PlayerWalking()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    private void PlayerRunning()
    {
        //Create a time limit for running

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += increaseSpeedValue;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= increaseSpeedValue;
        }
    }
}

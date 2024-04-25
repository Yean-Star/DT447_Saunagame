using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float superSpeed = 20f;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private float jumpHeight = 3f;
    [SerializeField]
    private float superJumpHeight = 15f;
    [SerializeField]
    private ShoppingManager shoppingManager;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        if (!shoppingManager.getSpeedBought())
        {
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(transform.TransformDirection(moveDirection) * superSpeed * Time.deltaTime);
        }
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            if (!shoppingManager.getHighJumpBought())
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
            else
            {
                playerVelocity.y = Mathf.Sqrt(superJumpHeight * -3.0f * gravity);
            }
            
        }
    }

    
}

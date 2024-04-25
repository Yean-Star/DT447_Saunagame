using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    // Start is called before the first frame update
    private PlayerMotor motor;
    private PlayerLook look;
    private void Awake()
    {
        Cursor.visible = false;
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ShoppingManager.isOpenUI)
        {
            return;
        }
        else
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        }
        
    }

    private void LateUpdate()
    {
        if (ShoppingManager.isOpenUI)
        {
            return;
        }
        else
        {
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
        
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{

    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    [Header("Boost")]
    public float boostEnergy = 100f;
    public float reduceAmount = 40f;
    public float increaseAmount = 15f;
    public bool isRunning = false;
    public bool isExhausted = false;
    
    


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;


    CharacterController characterController;
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        #region  Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

       
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        if(canMove){
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        }

        #endregion

        #region Handles Jumping
        if(Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            //_rigidbody.AddForce(this.transform.up * 100, ForceMode.Impulse);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        characterController.Move(moveDirection * Time.deltaTime);
        #region  Handles Rotation

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
        #region Boost Administration
        //Press Left Shift to run
        if(Input.GetKey(KeyCode.LeftShift) && !isExhausted)
        {
            boostEnergy = Mathf.Clamp(boostEnergy - (reduceAmount * Time.deltaTime), 0f, 100f);
            if(boostEnergy > 0f)
            {
                isRunning = true;
            }
            else
            {
                isExhausted = true;
            }
            
        }
        else
        {
            boostEnergy = Mathf.Clamp(boostEnergy + (increaseAmount * Time.deltaTime), 0f, 100f);
            isRunning = false;
            if(boostEnergy >= 15f){
                isExhausted = false;
            }
        }
        #endregion
    }

    public void JumpTrampoline(float jumpPowerTrampoline)
    {
        moveDirection.y = jumpPowerTrampoline;

    }

    public void SpeedTrampoline(float speedPowerTrampoline, Vector3 dir)
    {

        canMove = false;
        moveDirection = (dir * runSpeed * 2);
        Invoke("SetMovement", 0.5f);
       
    }

    private void SetMovement()
    {
        canMove = true;
    }

    public void BoostPowerUp(){
        reduceAmount = 0f;
        runSpeed = 15f;
        walkSpeed = 9f;
        Invoke("BoostPowerUpEnd", 5.0f);
    }

    private void BoostPowerUpEnd(){
        reduceAmount = 40f;
        runSpeed = 12f;
        walkSpeed = 6f;
    }


}

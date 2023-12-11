using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{

[SerializeField] AudioSource walking;
[SerializeField] AudioSource running;
public Camera playerCamera;
public float walkSpeed = 4f;
public float runSpeed = 12f;
public float jumpPower = 7f;
public float gravity = 10f;

public float lookSpeed = 1f;
public float lookXLimit = 60f;

Vector3 moveDirection = Vector3.zero;
float rotatationX = 0;

public bool canMove = true;
public bool isMoving = false; 
public bool enabled = false;

CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

void Update() {

    if (Keyboard.current.eKey.wasPressedThisFrame) {
        enabled = true;
    }

    if (enabled) {
        updatePlayer();
    }
}

    // Update is called once per frame
    void updatePlayer()
    {
        #region handles movement

        Vector3  forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curspeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        if (curSpeedX == 0 && curspeedY == 0) {
            isMoving = false;
        } else {
            isMoving = true;
        }

        moveDirection = (forward * curSpeedX) + (right * curspeedY);

        #endregion

        #region handles jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded) {
            moveDirection.y = jumpPower;
        } else {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded) {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region handles rotation/cam movement

        characterController.Move(moveDirection * Time.deltaTime);

        if(canMove) {
            rotatationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotatationX = Mathf.Clamp(rotatationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotatationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion

        #region handles sound
        if (isMoving && canMove) {
            if (isRunning) {
                walking.Play();
            } else {
                running.Play();
            }
        } 
        if (!isMoving || !characterController.isGrounded) {
            walking.Pause();
            running.Pause();
        }

        #endregion
    }
}

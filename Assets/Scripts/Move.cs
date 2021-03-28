using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 3;

    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    private float gravity = 9.87f;
    private float verticalSpeed = 0;

    public Vector3 jump;
    private float jumpHeight = 10.0f;
    public bool isRun = false;
    private Vector3 playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CharachterRotate();
        CharachterMove();
    }

    public void CharachterRotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }

    private void CharachterMove()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        var playerSpeed = speed;
        if (Input.GetButton("Jump"))
            verticalSpeed = jumpHeight;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRun = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            isRun = false;
        if (isRun)
            playerSpeed *= 3;

        if (characterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(playerSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }
}

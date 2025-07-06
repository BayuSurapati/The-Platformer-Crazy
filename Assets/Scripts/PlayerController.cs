using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce, gravityScale;
    private float yStore;

    public CharacterController charCon;
    private CameraController cam;
    private Vector3 moveAmount;

    public float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraController>();
    }

    void FixedUpdate()
    {
        if (!charCon.isGrounded)
        {
            moveAmount.y = moveAmount.y + (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);
        }
        else
        {
            moveAmount.y = Physics.gravity.y * gravityScale * Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        yStore = moveAmount.y;
        //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z + (Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));
        moveAmount.y = 0f;

        moveAmount = moveAmount.normalized;

        if (moveAmount.magnitude > 0.1f) 
        {
            if (moveAmount != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveAmount);
            }
        }

        moveAmount.y = yStore;

        if (charCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveAmount.y = jumpForce;
            }
        }

        charCon.Move(new Vector3(moveAmount.x * moveSpeed, moveAmount.y * moveSpeed, moveAmount.z * moveSpeed) * Time.deltaTime);

    }
}

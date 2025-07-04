using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public CharacterController charCon;
    private CameraController cam;
    private Vector3 moveAmount;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraController>();
    }

    void FixedUpdate()
    {
        if (!charCon.isGrounded)
        {
            moveAmount.y = moveAmount.y + (Physics.gravity.y * Time.fixedDeltaTime);
        }
        else
        {
            moveAmount.y = Physics.gravity.y * Time.deltaTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveAmount.y;
        //transform.position = new Vector3(transform.position.x + (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z + (Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
        moveAmount = (cam.transform.forward * Input.GetAxisRaw("Vertical")) + (cam.transform.right * Input.GetAxisRaw("Horizontal"));
        moveAmount.y = 0f;

        moveAmount = moveAmount.normalized;

        moveAmount.y = yStore;

        charCon.Move(new Vector3(moveAmount.x * moveSpeed, moveAmount.y * moveSpeed, moveAmount.z * moveSpeed) * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;




public class PlayerInput : MonoBehaviour
{
   
    Wrapper CPPDLL;
    public Rigidbody player;
    public float moveSpeed = 10.0f;
    private Vector3 moveDirection;
    public static bool CanMove = true;
    public Canvas BtnCanvas;

    public UnityEngine.UI.Button SaveBtn;
    public UnityEngine.UI.Button LoadBtn;
    Vector2 rotation = new Vector2(0, 0);
    public float sensitivity = 1.5f;
    public mouseHovor MsHvr;

   





    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        BtnCanvas.enabled = false;
        
    }

    public void SaveButtonClick()
    {

        BtnCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        CanMove = true;
        Vector3 temp = mouseHovor.ObjectMoving.transform.position;
        float x = temp.x;
        float y = temp.y;
        float z = temp.z;

        //Wrapper.SavePos(x,y,z);
    }

    public void LoadButtonClick()
    {

        BtnCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        CanMove = true;
        //mouseHovor.ObjectMoving.transform.position = Wrapper.LoadPos();
    }


    void Update()
    {
        if (CanMove == true)
        {
            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            player.transform.eulerAngles = (Vector2)rotation * sensitivity;

            if (Input.GetKey("w"))
            {
                moveDirection = player.transform.rotation * Vector3.forward;
            }
            if (Input.GetKey("s"))
            {
                moveDirection = player.transform.rotation * -Vector3.forward;
            }
            if (Input.GetKey("c"))
            {
                moveDirection = player.transform.rotation * Vector3.up;
            }
            if (Input.GetKey("x"))
            {
                moveDirection = player.transform.rotation * -Vector3.up;
            }
            if (Input.GetKey("d"))
            {
                moveDirection = player.transform.rotation * Vector3.right;
            }
            if (Input.GetKey("a"))
            {
                moveDirection = player.transform.rotation * -Vector3.right;
            }
            
            GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;
            moveDirection = new Vector3(0, 0, 0);
            player.transform.position = new Vector3(player.position.x, player.position.y, player.position.z);


            
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 50;
        }
        else
        {
            moveSpeed = 10;
        }
        if (Input.GetKeyDown("f"))
        {
            if (CanMove) {
                BtnCanvas.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                CanMove = false;
            }
            else if (!CanMove)
            {
                BtnCanvas.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                CanMove = true;
            }
            
        }

    }
}

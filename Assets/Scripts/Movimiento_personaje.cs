using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_personaje : MonoBehaviour
{
    public Camera camara;
    public float speedH;
    public float speedV;
    public float rotMax;
    public float rotMin;
    float ejeV, ejeH;

    CharacterController CC;
    public float runSpeed;
    public float speedMovimiento;
    public float jump;
    public float gravity;

    private Vector3 movimiento = Vector3.zero;
    
     

    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; 
        
    }

    // Update is called once per frame
    void Update()
    {

        ejeH = speedH * Input.GetAxis("Mouse X");
        ejeV += speedV * Input.GetAxis("Mouse Y");

        camara.transform.localEulerAngles = new Vector3(-ejeV, 0, 0);
        transform.Rotate(0, ejeH, 0);
        ejeV = Mathf.Clamp(ejeV, rotMin, rotMax);

        if(CC.isGrounded)
        {
            movimiento = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            
            if (Input.GetKey(KeyCode.LeftShift))
           
                movimiento = transform.TransformDirection(movimiento) * runSpeed;
            else
                movimiento = transform.TransformDirection(movimiento) * speedMovimiento;
            
            //salto sin movimiento fijo// 
            if (Input.GetKey(KeyCode.Space))
            
                movimiento.y = jump;
            
        }

        movimiento.y -= gravity * Time.deltaTime;
        CC.Move(movimiento * Time.deltaTime);

    }
}

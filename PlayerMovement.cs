using System;
using Photon.Pun;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviourPun
{
    [SerializeField]
    float speed, Rotationspeed;

    CharacterController Controller;
    Vector3 MyRotation;

    void Awake()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Movement();
        Rotation();
    }


    private void Movement()
    {
        var Haxis = Input.GetAxis("Horizontal");
        var Vaxis = Input.GetAxis("Vertical");
        var Movement = (Haxis * transform.right) + (Vaxis * transform.forward);
        Movement = Movement.normalized * speed;

        if (!Controller.isGrounded)
        {
            Movement.y += Physics.gravity.y;
        }

        Controller.Move(Movement * Time.deltaTime);
    }

    private void Rotation()
    {
        var MouseX = Input.GetAxis("Mouse X");
        var MouseY = Input.GetAxis("Mouse Y");

        MyRotation.x += MouseX;
        MyRotation.y += MouseY;

        transform.eulerAngles = new Vector2(-MyRotation.y, MyRotation.x);

    }

}

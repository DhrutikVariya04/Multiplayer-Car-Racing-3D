using System;
using Photon.Pun;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviourPun
{
    [SerializeField]
    float speed, Rotationspeed;

    CharacterController Controller;
    Vector3 MyRotation;

    public bool isLocal = false;

    void Awake()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isLocal)
        {
            Movement();
        }
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
}

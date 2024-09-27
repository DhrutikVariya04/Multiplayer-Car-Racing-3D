using TMPro;
using System;
using Photon.Pun;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Photon.Realtime;

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
            transform.tag = "Man";
            Movement();
        }

        GetComponentInChildren<TMP_Text>().text = PhotonNetwork.NickName;
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

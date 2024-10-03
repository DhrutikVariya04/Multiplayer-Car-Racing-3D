using TMPro;
using System;
using Photon.Pun;
using UnityEngine;
using UnityEditor;
using Photon.Realtime;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

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
            GetComponentInChildren<TMP_Text>().text = PhotonNetwork.NickName;
            GetComponentInChildren<CameraFollow>()._isLocal = true;
            transform.tag = "Man";
            Movement();

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Ammo();
            }
        }
        else
        {
            GetComponentInChildren<TMP_Text>().text = "";
            //GetComponentInChildren<CameraFollow>()._isLocal = false;
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

    void Ammo()
    {
        GameObject ammo = PhotonNetwork.Instantiate("Ammo", transform.GetChild(0).position, Quaternion.identity);
    }
}

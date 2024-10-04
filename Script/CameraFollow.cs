using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float RotateSpeed = 5f;
    Vector3 MyRotation;

    void Update()
    {
        //print(PhotonNetwork.GetPing());
        CameraRotation();
    }

    void CameraRotation()
    {
        var MouseX = Input.GetAxis("Mouse X");
        var MouseY = Input.GetAxis("Mouse Y");
        MyRotation.x += MouseX * RotateSpeed;
        MyRotation.y += MouseY * RotateSpeed;

        MyRotation.y = Mathf.Clamp(MyRotation.y, -45f, 10f);

        // Calculate the new position and rotation
        Vector3 direction = new Vector3(0, 0, 5.0f);
        Quaternion rotation = Quaternion.Euler(MyRotation.y, MyRotation.x, 0);
        transform.position = transform.parent.position + rotation * direction;

        transform.parent.rotation = Quaternion.Euler(0f, MyRotation.x + 180, 0f);
        transform.LookAt(transform.parent);
    }
}

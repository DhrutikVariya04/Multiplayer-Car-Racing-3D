using TMPro;
using System;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayScript : MonoBehaviourPunCallbacks
{
    Transform Gun;
    GameObject Player;

    void Awake()
    {
        Player = PhotonNetwork.Instantiate("Man", new Vector3(0, 1, 0), Quaternion.identity, 0);
        Player.GetComponent<PlayerMovement>().isLocal = true;
        Gun = Player.GetComponentInChildren<Transform>();
        Player.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ammo();
        }
    }

    void Ammo()
    {
        GameObject ammo = PhotonNetwork.Instantiate("Ammo", Gun.transform.position , Quaternion.identity);
        ammo.transform.SetParent(Player.transform);

        Physics.IgnoreCollision(ammo.GetComponent<Collider>(), Player.GetComponent<Collider>());
        ammo.transform.position = Gun.position;

        Vector3 rotation = ammo.transform.rotation.eulerAngles;
        ammo.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        ammo.GetComponent<Rigidbody>().AddForce(Gun.forward * 30, ForceMode.Impulse);

        Destroy(ammo, 3f);
    }
}

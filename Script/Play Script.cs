using TMPro;
using System;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayScript : MonoBehaviourPunCallbacks
{
    Transform Gun;
    GameObject Player;

    [SerializeField]
    Text PingText;

    private void Awake()
    {
        Player = PhotonNetwork.Instantiate("Man", new Vector3(0, 1, 0), Quaternion.identity, 0);
        Player.GetComponent<PlayerMovement>().isLocal = true;
        Gun = Player.GetComponentInChildren<Transform>();
    }

    void Update()
    {
        PingText.text = ""+PhotonNetwork.GetPing();
    }
}

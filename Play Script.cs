using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayScript : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        GameObject Player = PhotonNetwork.Instantiate("Man", new Vector3(0, 1, 0), Quaternion.identity, 0);
        Player.GetComponent<PlayerMovement>().isLocal = true;
    }
}

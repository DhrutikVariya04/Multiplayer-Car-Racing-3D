using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayScript : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    GameObject Player;

    void Update()
    {
        //photonView.RPC("PlayerPos", RpcTarget.All, Player,PhotonNetwork.NickName);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        print("OnPhotonInstantiate :" + info.Sender.NickName);
    }

    void Awake()
    {
        Player = PhotonNetwork.Instantiate("Man", new Vector3(0, 1, 0), Quaternion.identity, 0);
        Player.GetComponentInChildren<TMP_Text>().text = PhotonNetwork.NickName;
    }

    [PunRPC]
    void PlayerPos(GameObject Player,string name)
    {
        print($"{name} -- > {Player.transform.position}");
    }
}

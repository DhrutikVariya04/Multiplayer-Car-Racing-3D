using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ServerManger : MonoBehaviourPunCallbacks
{
    [SerializeField]
    TMP_InputField Name;

    [SerializeField]
    TMP_InputField RoomID;

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void btnusername()
    {
        PhotonNetwork.NickName = Name.text;
        print($"Nickname --> {PhotonNetwork.NickName}");
    }

    public void btn_Create()
    {
        PhotonNetwork.CreateRoom(RoomID.text);
    }

    public void btn_Join()
    {
        PhotonNetwork.JoinRoom(RoomID.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Playing");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Photon Disconnected....");
    }
}

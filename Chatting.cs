using TMPro;
using Photon.Pun;
using UnityEngine;

public class Chatting : MonoBehaviourPun
{
    [SerializeField]
    TMP_Text TextField;

    [SerializeField]
    TMP_InputField UserInput;

    void Start()
    {
        TextField.text = "";
    }

    public void MessageSend()
    {
        var Message = UserInput.text;
        photonView.RPC("ReceiveMessage", RpcTarget.All,Message, PhotonNetwork.NickName);
        UserInput.text = "";

    }

    [PunRPC]
    void ReceiveMessage(string Message,string name)
    {
        TextField.text += name + " == >" + Message+"\n";
    }
}

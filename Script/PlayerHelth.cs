using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviourPun
{
    [PunRPC]
    public void applyDamge(int ViewID, float damage)
    {
        var target = PhotonView.Find(ViewID);

        if (target != null)
        {
            print("ViewID ===>" + ViewID /*+ "\n Color ===>" + color*/);
        }
    }
}

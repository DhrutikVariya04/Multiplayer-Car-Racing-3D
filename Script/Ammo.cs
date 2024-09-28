using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Photon.Pun;

public class Ammo : MonoBehaviourPun
{
    bool test = false;
    float damage = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (test) return;

        if (collision.transform.tag == "Enemy")
        {
            var renderer = collision.transform.GetChild(3).GetComponent<Renderer>();
            var view = collision.transform.GetComponent<PhotonView>();    

            if (renderer != null)
            {
                /*Color color = renderer.material.color;

                if (color == Color.green)
                {
                    renderer.material.color  = Color.yellow;
                    PhotonNetwork.Destroy(transform.gameObject);
                    test = true;
                }
                else if (color == Color.yellow)
                {
                    renderer.material.color = Color.red;
                    PhotonNetwork.Destroy(transform.gameObject);                    
                }
                else
                {
                    print("You Died already . . .");
                    PhotonNetwork.Destroy(collision.transform.gameObject);
                }*/
                test = true;
                view.RPC("applyDamge",RpcTarget.All,collision.transform.GetComponent<PhotonView>().ViewID, damage);
            }
        }
    }
    
}

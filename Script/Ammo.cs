using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Photon.Pun;

public class Ammo : MonoBehaviour
{
    bool test = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (test) return;

        if (collision.transform.tag == "Enemy")
        {
            var renderer = collision.transform.GetChild(3).GetComponent<Renderer>();

            if (renderer != null)
            {
                Color color = renderer.material.color;

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
                    test = true;
                }
                else
                {
                    print("You Died already . . .");
                    PhotonNetwork.Destroy(collision.transform.gameObject);
                }
            }
        }
    }
}

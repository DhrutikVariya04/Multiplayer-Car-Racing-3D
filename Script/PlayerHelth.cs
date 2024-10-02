using Photon.Pun;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class PlayerHelth : MonoBehaviour
{
    float TotalHelth = 10f;
    float damage = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ammo"))
        {
            TotalHelth -= damage;
            if (TotalHelth == 0)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}

using Photon.Pun;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;

public class PlayerHelth : MonoBehaviour
{
    float damage = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ammo"))
        {
            print("Hello " + other.tag);
            print(gameObject.transform.parent.name);
        }
    }
}

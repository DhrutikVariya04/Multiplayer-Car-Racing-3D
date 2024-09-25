using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        print("Hello");

        if (collision.transform.tag == "Man")
        {
            var Obj = collision.transform.GetChild(3).GetComponent<MeshRenderer>().material.color;

            if (Obj == Color.green)
            {
                Obj = Color.yellow;
            }
            else if (Obj == Color.yellow)
            {
                Obj = Color.red;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Ammo : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreCollision(transform.GetComponentInParent<Collider>(), transform.GetComponent<Collider>());

        if (collision.transform.tag == "Man")
        {
            var renderer = collision.transform.GetChild(3).GetComponent<Renderer>();

            if (renderer != null)
            {
                Color color = renderer.material.color;

                if (color == Color.green)
                {
                    renderer.material.color  = Color.yellow;
                }
                else if (color == Color.yellow)
                {
                    renderer.material.color = Color.red;
                }
                else
                {
                    print("Destroy ...");
                }
            }
        }
    }
}

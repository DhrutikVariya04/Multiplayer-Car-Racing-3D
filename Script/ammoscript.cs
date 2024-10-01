using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoscript : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();      
    }
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}

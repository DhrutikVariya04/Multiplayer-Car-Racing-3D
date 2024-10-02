using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoscript : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        StartCoroutine("DisAmmo");
    }

    IEnumerator DisAmmo()
    {
        rb.velocity = transform.forward * speed;

        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}

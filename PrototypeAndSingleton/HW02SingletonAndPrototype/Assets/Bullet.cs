using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float force = 2f;
    internal void Init(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(direction.x, direction.y) * force, ForceMode.Impulse); 
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }
}

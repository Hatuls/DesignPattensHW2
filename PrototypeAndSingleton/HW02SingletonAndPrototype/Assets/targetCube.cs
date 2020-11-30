using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class targetCube : MonoBehaviour
{
   
    float speed = 2f;
    private Action AddScore;
    public void Init() {
        StartCoroutine(Move());
     }
    public Action GetSetAction {
        set { AddScore = value; }
        get { return AddScore; }
    }

    IEnumerator Move() {
        while (this.gameObject != null)
        {
        transform.position += Vector3.left * Time.deltaTime* speed ;

            yield return null;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        AddScore.Invoke();
        StopCoroutine(Move());
        Destroy(gameObject);
    }
}



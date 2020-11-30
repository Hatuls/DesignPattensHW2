using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.iOS;
using System.Runtime.InteropServices.WindowsRuntime;

public abstract class TargetEnemy : MonoBehaviour
{

    public void Init( GameObject thisgo) {
       // GetComponent<MeshFilter>().mesh = r.mesh;
        StartCoroutine(Move(SetSpeed() , thisgo));
        Destroy(thisgo, 5f);
       
    }


    protected IEnumerator Move(float speed, GameObject gameObject) {
        while (true)
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
           yield return null;
        }
    
    
    }
   
    protected virtual float SetSpeed() { return 5f; }

    

}
 



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Cube :TargetEnemy
{
    private void OnCollisionEnter(Collision collision)
    {
        Spawner.addScore();
        Debug.Log("Object Destroyed");
        Destroy(gameObject);
    }

   
    protected override float SetSpeed()
    {
        return 10f;
    }
}

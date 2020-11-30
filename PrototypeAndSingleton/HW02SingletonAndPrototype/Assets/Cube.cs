using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Cube :TargetEnemy
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

   
    protected override float SetSpeed()
    {
        return 10f;
    }
}

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
  public   targetCube targetCube;
 
    public Action addScore;

    public float min, max;

    public bool spawnObject = true;
    private void Awake()
    {
        instance = this;
        
    }


    public void StartThrowTarget()
    {
        StopCoroutine(SpawnTimer());
        Debug.Log(" start spawning cube corutine");
            
        StartCoroutine(SpawnTimer());
    }

     
    IEnumerator SpawnTimer()
    {

        float spawnBetweenTime = 2f;
        while (spawnObject)
        {
            Debug.Log("Spawn cube prefa every X seconds, initiate prefab");
            targetCube cubeObject = Instantiate(targetCube, GetRandomVector(), Quaternion.identity, this.transform);
            cubeObject.Init();
            cubeObject.GetSetAction = addScore;
            yield return new WaitForSeconds(spawnBetweenTime );
            spawnBetweenTime -= 0.02f;
            if (spawnBetweenTime <0.3f)
            {
                spawnBetweenTime = 0.3f;
            }
        }

    }

    private Vector3 GetRandomVector()
    {
        Debug.Log("generate random spawning vector for the cube prefab");
        Vector3 spawnLocation;
        float randomY = Random.Range( min, max) ;
        spawnLocation = new Vector3(transform.position.x, randomY, transform.position.z);
        return spawnLocation;
    }
}

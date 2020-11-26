using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform CannonJoint, EndOfCannon;
    public static Player Instance;

    [SerializeField] Bullet bullet;

    Vector3 TargetRotation;
    void Start()
    {
        Instance = this;
    }
    public void InstansiateBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click made: Instantiate Bullet and initiate it");
            Bullet b = Instantiate(bullet, EndOfCannon.position, Quaternion.identity, this.transform);
            b.Init(TargetRotation);
        }
    }

    public void RotateTheCannon(Vector3 target) {

        TargetRotation = target - CannonJoint.position;
        Quaternion rotation = Quaternion.LookRotation(TargetRotation.normalized, Vector3.back);

        Quaternion targetRotation = Quaternion.RotateTowards(CannonJoint.rotation, rotation, 180f);


        CannonJoint.rotation = new Quaternion(0, 0, targetRotation.z, targetRotation.w);

        Debug.Log("Rotate Towards mouse position");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody bulletRigidBody;
    GameObject playerObject;
    PlayerController playerControllerScript;
    GameObject BulletSpawnPoint;
    float bulletRange;


    /*public float BulletDistance => bulletDistance;*/ // bullet distance kullanabilirsin ama deger atamasi yapamassin 
    private void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = playerObject.GetComponent<PlayerController>();
        BulletSpawnPoint = playerControllerScript.fireModule.bulletSpawnPoint;

    }

    private void Update()
    {
        BulletMovement();

        CalculateDistance();
    }
    void BulletMovement()
    {
        bulletRigidBody.velocity = Vector3.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target")) // trigger ici haric baska bir scripti kullanman gereken yer oldugunda sikinti var 
        {
            gameObject.SetActive(false);
            var bulletPower = playerControllerScript.fireModule.GetBulletPower();
            var target = other.GetComponent<TargetController>();
            target.DecraeseValue(bulletPower);
            target.HitAnim();
        }
        if (other.CompareTag("Gate"))
        {
            var gate = other.GetComponent<GateController>();
            gate.GateIncreaseValue(playerControllerScript.fireModule.bulletPower);
            gate.GateHitAnim();
        }
    }
    void CalculateDistance() 
    {
        float distance = Vector3.Distance(transform.position, BulletSpawnPoint.transform.position);
        bulletRange = playerControllerScript.fireModule.GetBulletDistance();
        if (distance > bulletRange)
        {
            gameObject.SetActive(false);
        }
    }



}

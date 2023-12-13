using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody bulletRigidBody;
    [SerializeField] Transform bulletSpawnPosition;

    private void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
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
        if (other.CompareTag("Gate"))
        {

            Debug.Log("MermiDet");
        }
    }
    void CalculateDistance() // ?????
    {
       
            float distance = Vector3.Distance(transform.position, bulletSpawnPosition.position);
            if (distance > 15)
            {
                gameObject.SetActive(false);
            }
        
    }
}

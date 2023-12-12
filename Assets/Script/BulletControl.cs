using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody bulletRigidBody;

    private void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        BulletMovement();
    }
    void BulletMovement()
    {
        bulletRigidBody.velocity = Vector3.forward * bulletSpeed * Time.deltaTime;
    }
}

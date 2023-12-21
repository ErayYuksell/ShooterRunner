using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int bombSpeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        BombMovement();
    }
    void BombMovement()
    {
        rb.velocity = Vector3.forward * bombSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishWall"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

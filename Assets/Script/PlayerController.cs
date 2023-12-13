using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xSpeed;
    float maxXValue = 4.60f;
    [SerializeField] float playerSpeed = 5;
    [SerializeField] GameObject bulletObject;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] float bulletDuration = 0.5f;
    [SerializeField] ObjectPool objectPool = null;
    float time;
    void Start()
    {
        StartCoroutine(BulletFire());
    }


    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float touchX = 0;
        float newXValue;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            xSpeed = 250f;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            xSpeed = 350f;
            touchX = Input.GetAxis("Mouse X");
        }
        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxXValue, maxXValue);
        Vector3 playerNewPosition = new Vector3(newXValue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = playerNewPosition;

    }

    IEnumerator BulletFire()
    {
        while (true)
        {
            var obj = objectPool.GetPoolObject();

            obj.transform.position = bulletSpawnPoint.transform.position;
           
            yield return new WaitForSeconds(bulletDuration);
        }
    }

    public void GatePassed(GateType gateType, float currentValue)
    {
        switch (gateType)
        {
            case GateType.Power:

                break;
            case GateType.Range:

                break;
            case GateType.FireRate:
                bulletDuration -= currentValue / 100;
                break;
            default:
                break;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameObject bulletObject;

    BulletControl bulletControlScript;
    public MovementModule movementModule;
    public FireModule fireModule;
    public GatePassModule gatePassModule;
    public DeathModule deathModule;
    bool isAlive = true;

    void Start()
    {
        movementModule.init(this);
        fireModule.init(this);
        gatePassModule.init(this);
        deathModule.init(this);

        bulletControlScript = bulletObject.GetComponent<BulletControl>();
        StartCoroutine(fireModule.BulletFire());
    }


    void Update()
    {
        movementModule.PlayerMovement();
    }
    [Serializable]
    public class MovementModule
    {
        PlayerController playerController;
        float xSpeed;
        float maxXValue = 4.60f;
        [SerializeField] float playerSpeed = 5;
        public void init(PlayerController playerController)
        {
            this.playerController = playerController;
        }
        public void PlayerMovement()
        {
            if (!playerController.isAlive)
            {
                return;
            }
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
            newXValue = playerController.transform.position.x + xSpeed * touchX * Time.deltaTime;
            newXValue = Mathf.Clamp(newXValue, -maxXValue, maxXValue);
            Vector3 playerNewPosition = new Vector3(newXValue, playerController.transform.position.y, playerController.transform.position.z + playerSpeed * Time.deltaTime);
            playerController.transform.position = playerNewPosition;

        }
    }
    [Serializable]
    public class FireModule
    {
        PlayerController playerController;
        public GameObject bulletSpawnPoint;
        [SerializeField] ObjectPool objectPool = null;
        public float bulletDuration = 0.5f;
        public float bulletDistance = 15;
        public float bulletPower = 1f;
        public void init(PlayerController playerController)
        {
            this.playerController = playerController;
        }
        public IEnumerator BulletFire()
        {
            while (playerController.isAlive)
            {
                var obj = objectPool.NewGetPoolObject();

                obj.transform.position = bulletSpawnPoint.transform.position;

                yield return new WaitForSeconds(bulletDuration);
            }
        }
        public float GetBulletDistance()
        {
            return bulletDistance;
        }
        public float GetBulletPower()
        {
            return bulletPower;
        }
    }
    [Serializable]
    public class GatePassModule
    {
        PlayerController playerController;
        [SerializeField] float fireRateMultiply = 0.05f;
        [SerializeField] float rangeMultiply = 0.05f;
        [SerializeField] float powerMultiply = 0.05f;

        public void init(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public void GatePassed(GateType gateType, float currentValue)
        {

            switch (gateType)
            {
                case GateType.Power:
                    playerController.fireModule.bulletPower += currentValue * powerMultiply;
                    break;
                case GateType.Range:
                    playerController.fireModule.bulletDistance += currentValue * rangeMultiply;
                    break;
                case GateType.FireRate:
                    playerController.fireModule.bulletDuration -= currentValue * fireRateMultiply;
                    break;
                default:
                    break;
            }
        }
    }
    [Serializable]
    public class DeathModule
    {
        PlayerController playerController;
        public void init(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public void PlayerDeath()
        {
            playerController.isAlive = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            LevelController.Instance.NextLevel();
        }
    }


}

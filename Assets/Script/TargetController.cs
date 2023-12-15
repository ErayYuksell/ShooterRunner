using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] float targetValue = 20;
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip clip;
    GameObject playerObject;
    PlayerController playerControllerScript;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = playerObject.GetComponent<PlayerController>();
        targetText.text = targetValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DecraeseValue(float bulletPower)
    {
        //animator.SetBool("isShoot", true);
        targetValue -= bulletPower;
        if (targetValue <= 0)
        {
            targetValue = 0;
            gameObject.SetActive(false);
        }
        targetText.text = targetValue.ToString();
    }
    public void HitAnim()
    {
        animator.Play(clip.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerControllerScript.deathModule.PlayerDeath();
        }
    }

}

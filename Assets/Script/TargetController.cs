using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] float targetValue = 20;
    float targetFirstValue;
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip clip;

    GameObject playerObject;
    PlayerController playerController;

    void Start()
    {
        targetText.text = targetValue.ToString();
        targetFirstValue = targetValue;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerController = playerObject.GetComponent<PlayerController>();
    }

   
    void Update()
    {

    }
    public void DecraeseValue(float bulletPower)
    {
        targetValue -= bulletPower;
        if (targetValue <= 0)
        {
            targetValue = 0;
            gameObject.SetActive(false);
            playerController.deathModule.PlayerText(targetFirstValue);
        }
        targetText.text = targetValue.ToString("F0");
    }
    public void HitAnim()
    {
        animator.Play(clip.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerController>();
            player.deathModule.PlayerBounce();
            player.deathModule.PlayerDamage();
        }
    }

}

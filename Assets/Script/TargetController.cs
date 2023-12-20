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

    void Start()
    {
        targetText.text = targetValue.ToString();
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

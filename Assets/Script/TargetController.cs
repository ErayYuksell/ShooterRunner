using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] int targetValue = 20;
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip clip;
    void Start()
    {
        targetText.text = targetValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DecraeseValue()
    {
        HitAnim();
        targetValue--;
        targetText.text = targetValue.ToString();
    }
    public void HitAnim()
    {
        animator.Play(clip.name);
    }

}

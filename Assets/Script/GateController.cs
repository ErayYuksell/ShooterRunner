using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GateType { Power, Range, FireRate }
public class GateController : MonoBehaviour
{

    public GateType gateType;
    [SerializeField] TextMeshProUGUI GateText;
    [SerializeField] float currentValue;
    [SerializeField] GameObject glassGO;
    Renderer glassRenderer;
    [SerializeField] Material[] materials;
    bool isPassed = true;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip gateAnim;



    private void Start()
    {
        glassRenderer = glassGO.GetComponent<Renderer>();
        GateValue();
        GateCheck();
    }

    void GateValue()
    {
        switch (gateType)
        {
            case GateType.Power:
                GateText.text = currentValue.ToString("F0");
                break;
            case GateType.Range:
                GateText.text = currentValue.ToString("F0");
                break;
            case GateType.FireRate:
                GateText.text = currentValue.ToString("F0");
                break;
            default:
                break;
        }
    }
    void GateCheck()
    {
        if (currentValue < 0)
        {
            glassRenderer.material = materials[0];
        }
        if (currentValue > 0)
        {
            glassRenderer.material = materials[1];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isPassed == true)
        {
            isPassed = false;
            var player = other.GetComponent<PlayerController>();
            player.gatePassModule.GatePassed(gateType, currentValue);
        }
    }
    public void GateIncreaseValue(float value)
    {
        currentValue += value;
        GateValue();
        GateCheck();
    }
    public void GateHitAnim()
    {
        animator.Play(gateAnim.name);
    }

}

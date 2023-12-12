using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public enum GateType { Power, Range, FireRate, Count }
    public GateType gateType;
    [SerializeField] TextMeshProUGUI GateText;
    [SerializeField] int currentValue;
    [SerializeField] GameObject glassGO;
    Renderer glassRenderer;
    [SerializeField] Material[] materials;
    bool isPassed = true;

    private void Start()
    {
        glassRenderer = glassGO.GetComponent<Renderer>();
        GateStart();
        GateCheck();
    }
    void GateStart()
    {
        switch (gateType)
        {
            case GateType.Power:
                GateText.text = currentValue.ToString();
                break;
            case GateType.Range:
                GateText.text = currentValue.ToString();
                break;
            case GateType.FireRate:
                GateText.text = currentValue.ToString();
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
            Debug.Log("Gate Passed");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public enum GateType { Power, Range, FireRate, Count }
    public GateType gateType;
    [SerializeField] TextMeshProUGUI GateText;
    [SerializeField] int currentValue = 2;

    void GateStart()
    {
        switch (gateType)
        {
            case GateType.Power:
                GateText.text = "+" + currentValue.ToString();
                break;
            case GateType.Range:
                break;
            case GateType.FireRate:
                break;
            case GateType.Count:
                break;
            default:
                break;
        }
    }
}

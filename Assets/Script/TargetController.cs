using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] int targetValue = 20;
    [SerializeField] TextMeshProUGUI targetText;
    void Start()
    {
        ShowValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowValue()
    {
        targetText.text = targetValue.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutputText : MonoBehaviour
{
    TextMeshPro outputText;
    [SerializeField]InputText inputText;

    private void Awake()
    {
        outputText = GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        outputText.SetText($"Floor {inputText.currentFloor}");
    }
}

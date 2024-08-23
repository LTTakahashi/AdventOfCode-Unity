using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharactersPassed : MonoBehaviour
{
    TextMeshPro textMeshPro;
    [SerializeField]InputText inputText;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if (!inputText.hasReachedBasement)
        {
            textMeshPro.SetText($"Numbers of characters passed:          {inputText.numberOfCharcters}");
        }
        else if (inputText.hasReachedBasement)
        {
            textMeshPro.SetText($"Reached basement on the {inputText.reachedBasementAt} passing");
        }
    }
}

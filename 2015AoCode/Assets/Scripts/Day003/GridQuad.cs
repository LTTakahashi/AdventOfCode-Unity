using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridQuad : MonoBehaviour
{
    Renderer meshRenderer;
    
    private void Awake()
    {
        meshRenderer = GetComponent<Renderer>();
        meshRenderer.material.color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        meshRenderer.material.color = Color.yellow;
    }


}

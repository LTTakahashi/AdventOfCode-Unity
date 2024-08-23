using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Node[,] map;
    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y /  nodeDiameter);

    }

    void CreateMap()
    {
        map = new Node[gridSizeX, gridSizeY];
    }
}

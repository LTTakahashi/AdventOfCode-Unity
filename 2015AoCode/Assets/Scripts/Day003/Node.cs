using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Node 
{
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public Node (Vector3 _worldPos, int _gridX, int _gridY)
    {
        worldPosition =  _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

}

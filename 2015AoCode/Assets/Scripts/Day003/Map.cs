using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// A script to process a map that would change when the object "moves" 

public class Map : MonoBehaviour
{
    [SerializeField]GameObject gridQuad;
    List<string> quadIds;
    [SerializeField] int height = 8;
    [SerializeField] int width = 8;
    Vector3 positionQuad = Vector3.zero;
    [SerializeField] char command;
    [SerializeField] GameObject delivery;
    Quaternion rotation = Quaternion.identity;

    private void Awake()
    {
        BuildMap();
        SpawnDelivery();
        
    }
    private void Update()
    {
        MoverDelivery();
        MoveMap();
    }
    void BuildMap()
    {
        quadIds = new List<string>();
        positionQuad.z = 0;
        positionQuad.x =  - ((float)(width)) / 2;
        positionQuad.y = - ((float)(height)) / 2;
        
        
        for (int i = 0; i < width; i++, positionQuad.x++)
        {
            for(int j = 0; j < height; j++, positionQuad.y++)
            {
                GameObject newQuad = Instantiate(gridQuad, positionQuad, rotation, transform);

                string quadId = $"{i}-{j}";

                quadIds.Add(quadId);
                newQuad.name = quadId;
            }
            positionQuad.y = ((float) -height) / 2;
        }
        
    }
    void SpawnDelivery()
    {
        GameObject centerQuad = GameObject.Find($"{width / 2}-{height / 2}");

        Vector3 spawnpoint = centerQuad.transform.position;
        delivery = Instantiate(delivery, spawnpoint, rotation);
    }
    void MoverDelivery()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            delivery.transform.position += Vector3.left;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            delivery.transform.position += Vector3.down;
        }
        else if( Input.GetKeyDown(KeyCode.D))
        {
            delivery.transform.position += Vector3.right;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            delivery.transform.position += Vector3.up;
        }
    }
    void MoveMap()
    {
        if (command == 'v')
        {
            transform.position = Vector3.up;
        }
    }
        
   
}

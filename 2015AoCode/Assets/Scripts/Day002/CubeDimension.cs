using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Text.RegularExpressions;
using System.Linq;

public class CubeDimension : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField = default;
    [SerializeField] TextMeshProUGUI txt = default;
    public Transform cube = default;

    public string xDimension = "";
    public string yDimension = "";
    public string zDimension = "";
    
    Vector3 scaleValue = Vector3.one;
    int numberOfXPassed = 0;
    bool xIsAllowed = false;
    public int totalArea = 0;

    private void Awake()
    {
        cube = GetComponent<Transform>();
        txt.text = "00x00x00";
    }

    private void Update()
    {
        
        
        while(inputField.text.Length > 0)
        {
            char c = inputField.text[0];

            if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || 
                c == '6' || c == '7' || c == '8' || c == '9' || c == '0')
            {
                if (numberOfXPassed == 0 && xDimension.Length < 2)
                {
                    xDimension += c;
                }

                else if (numberOfXPassed == 1 && yDimension.Length < 2)
                {
                    yDimension += c;
                }

                else if (numberOfXPassed == 2 && zDimension.Length < 2)
                {
                    zDimension += c;
                    scaleValue.z = int.Parse(zDimension);
                    cube.localScale = scaleValue;
                }

                UpdateDimensionText();
                xIsAllowed = true;

            }

            else if (c == 'x' && xIsAllowed)
            {
                if (numberOfXPassed == 0)
                {
                    scaleValue.x = int.Parse(xDimension);
                    
                }

                else if (numberOfXPassed == 1)
                {
                    scaleValue.y = int.Parse(yDimension);
                }

                else if (numberOfXPassed == 2)
                {
                    scaleValue.z = int.Parse(zDimension);
                    
                }

                cube.localScale = scaleValue;
                numberOfXPassed++;
                xIsAllowed = false;
            }

            else if ((c == ' ' || inputField.text == " " || c == '\n') && zDimension.Length > 0)
            {

                cube.localScale = scaleValue;

                SurfaceArea(scaleValue.x, scaleValue.y, scaleValue.z);
                Debug.Log(totalArea);

                ResetValues();
                UpdateDimensionText();
            }

            inputField.text = inputField.text.Substring(1);
        }

       

        
    }

    int SurfaceArea(float l, float w, float h)
    {
        return totalArea += Mathf.RoundToInt(2 * l * w + 2 * w * h + 2 * h * l);
    }

    void ResetValues()
    {
        cube.localScale = Vector3.one;
        xDimension = "";
        yDimension = "";
        zDimension = "";
        scaleValue = Vector3.one;
        xIsAllowed = false;
        numberOfXPassed = 0;
    }
    void UpdateDimensionText()
    {
        // Set the txt.text to the correct format
        txt.text = $"{(xDimension.Length > 0 ? xDimension : "00")}x{(yDimension.Length > 0 ? yDimension : "00")}x{(zDimension.Length > 0 ? zDimension : "00")}";
    }
}

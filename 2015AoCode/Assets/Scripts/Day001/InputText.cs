using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    TextMeshPro text;
    string inputText;
    string visibleText;
    [SerializeField] TMP_InputField inputField;
    [SerializeField, Min(0)]float waitInputTime = 0.5f;
    [SerializeField, Min(0)] int numberOfCharcterShowing = 100;
    bool InputTimeIsRunning = false;
    public bool hasReachedBasement = false;
    public int currentFloor = 0;
    public int numberOfCharcters = 0;
    public int reachedBasementAt;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();

    }


    private void Update()
    {
        inputText = inputField.text;
        if(inputText.Length > numberOfCharcterShowing)
        {
            visibleText = inputField.text.Substring(0, numberOfCharcterShowing);
            text.SetText(visibleText);
        }
        else
        {
            text.SetText(inputText);

        }
        
        
        if (InputTimeIsRunning == false && waitInputTime != 0)
        {
            StartCoroutine(InputTime(waitInputTime));
        }

        //Even if we use waitTime to 0 there's still a delay frame from Unity Coroutine,
        // by using a yiled return null when the user specify the time to 0, 
        // we can bypass this frame delay
        else if (!InputTimeIsRunning && waitInputTime == 0)
        {
            ZeroTimeAlgorithmD1();
        }
        
    }



    private IEnumerator InputTime(float waitTime)
    {
        InputTimeIsRunning = true;

        // Process the inputText
        yield return StartCoroutine(AlgorithmD1(waitTime));

        InputTimeIsRunning = false;
    }

    private IEnumerator AlgorithmD1(float waitTime)
    {
        while (inputField.text.Length > 0)
        {
            char c = inputField.text[0];

            if (c == '(')
            {
                numberOfCharcters++;
                currentFloor++;
            }
            else if (c == ')')
            {
                numberOfCharcters++;
                currentFloor--;
            }
            
            if (!hasReachedBasement)
            {
                if (currentFloor < 0)
                {
                    hasReachedBasement = true;
                    reachedBasementAt = numberOfCharcters;
                    
                }
            }
            // Remove the processed character from the input field text
            inputField.text = inputField.text.Substring(1);

            // Wait for the specified time
            
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void ZeroTimeAlgorithmD1()
    {
        while (inputField.text.Length > 0)
        {
            char c = inputField.text[0];

            if (c == '(')
            {
                numberOfCharcters++;
                currentFloor++;
            }
            else if (c == ')')
            {
                numberOfCharcters++;
                currentFloor--;
            }
            if (!hasReachedBasement)
            {
                if (currentFloor < 0)
                {
                    hasReachedBasement = true;
                    reachedBasementAt = numberOfCharcters;

                }
            }
            // Remove the processed character from the input field text
            inputField.text = inputField.text.Substring(1);

        }
    }

}

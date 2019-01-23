using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

    public float WorkTimer;
    public float OtherTimer;
    public int WorkPayoff;
    public int OtherPayoff;
    private float currentValue;
    private float currentPercent;
    private bool wasPressed;

    public MainScript mainScriptButton;
    public Button WorkButton;
    public Image WorkBarImg;
    public Text WorkText;
    public Button OtherButton;
    public Image OtherBarImg;
    public Text OtherText;

    void Start()
    {
        //If you wanna do it the old-fashioned way, or create new buttons over the game:

        //mainScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainScript>();
        //WorkBar = GameObject.Find("WorkBar").GetComponent<WorkBar>();
    }

    //Add money to Main, start the timer, say you can't click
    public void WorkClicked()
    {
        currentValue = WorkTimer;
        wasPressed = true;
    }

    public void ButtonClicked() 
    {
        currentValue = OtherTimer;
        wasPressed = true;        
    }

    //Current value and current percent will either have to be duplicated or more gracefully handled
    private void BarTracker(Button button, float timer, Text text, Image barImg, int payoff)
    {
        if (currentValue > 0f)
        {
            button.enabled = false;
            currentValue -= Time.deltaTime;
            currentPercent = currentValue / timer;
            text.text = currentValue.ToString("F2");
            barImg.fillAmount = currentPercent;
        }
        else
        {
            button.enabled = true;
            text.text = timer.ToString("F2");
            barImg.fillAmount = 100;
            //Once the button has been pressed, wait for it to finish, then add the payoff
            if (wasPressed)
            {
                Debug.Log("In the loop");
                mainScriptButton.currentMoney += payoff;
                wasPressed = false;
            }
        }
    }

    //If there's time left, keep subtracting time and keep track of % bar should be full, display time left and change % filled on bar. Otherwise show full time and bar
    void Update()
    {
            
            BarTracker(WorkButton, WorkTimer, WorkText, WorkBarImg, WorkPayoff);
    }

}

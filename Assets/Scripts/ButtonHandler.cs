using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

    public float workTimer;
    public float secondTimer;
    private float workCurrentTime;
    private float workCurrentPercent;
    private bool workPressed;
    private int timesWorkPressed;
    private int timesSecondPressed;
    private int worksOwned;
    private float worksCost;

    public MainScript MainScriptButton;
    public Button WorkButton;
    public Button WorkBuyButton;
    public Image WorkBarImg;
    public Text WorkText;
    public Text WorkBuyText;
    //public Button SecondButton;
    //public Image SecondBarImg;
    //public Text SecondText;

    void Start()
    {
        worksOwned = 1;
        workCurrentTime = 3;
        //If you wanna do it the old-fashioned way, or create new buttons over the game:

        //mainScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainScript>();
        //WorkBar = GameObject.Find("WorkBar").GetComponent<WorkBar>();
    }

    //Add money to Main, start the timer, say you can't click
    public void WorkClicked()
    {
        workPressed = true;
        timesWorkPressed+=1;
    }
    public void BuyWorkClicked()
    {
            MainScriptButton.currentMoney -= worksCost;
            worksOwned += 1;
    }

    public void SecondClicked()
    {
        
        workPressed = true;
    }

    //Current value and current percent will either have to be duplicated or more gracefully handled inside the function
    //Note: Do you need pressed and currentValue to be references? Test it with and without the 'refs'.
    private void BarTracker(Button button, float timer, Text txt, Image barImg, int payoff, ref bool pressed, ref float currentTime)
    {
        if (pressed == true)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime < 3f && currentTime > 0f)
        {
            button.enabled = false;
            currentTime -= Time.deltaTime;
            float currentPercent = currentTime / timer;
            txt.text = currentTime.ToString("F2");
            barImg.fillAmount = currentPercent;
        }
        else if (currentTime == 3) //Keep the button enabled and the bar filled when not pressed
        {
            button.enabled = true;
            txt.text = timer.ToString("F2");
            barImg.fillAmount = 100;
            
        }
        else //Meaning it equals 0, this should only happen once and at the end
        {
            //The moneymaking line
            MainScriptButton.currentMoney += payoff * worksOwned;
            pressed = false;
            currentTime = timer;
        }
    }

    private void BuyTracker(Button button, Text txt, int baseCost, float rateGrowth, int numOwned)
    {
        worksCost =  baseCost * Mathf.Pow(rateGrowth, numOwned);
        if (MainScriptButton.currentMoney <= worksCost)
        {
            button.enabled = false;
        }
        else
        {
           button.enabled = true;
        }
        txt.text = "Have " + worksOwned + ", buy for $" + worksCost.ToString("F2");

    }

    //If there's time left, keep subtracting time and keep track of % bar should be full, display time left and change % filled on bar. Otherwise show full time and bar
    void Update()
    {
            //Running Work
            BarTracker(WorkButton, workTimer, WorkText, WorkBarImg, 1, ref workPressed, ref workCurrentTime);
            BuyTracker(WorkBuyButton, WorkBuyText, 3, (float) 1.05, worksOwned);
    }

}

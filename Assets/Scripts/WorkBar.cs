using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBar : MonoBehaviour {

    public Image ImgBar;
    public Text TxtNumber;
    public int Min;
    public int Max;
    private int mCurrentValue;
    private float mCurrentPercent;
    
    public void SetValue(int number)
    {
            if(Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = number;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            TxtNumber.text = "Work"; //Filler text, you want it to display time to completion

            ImgBar.fillAmount = mCurrentPercent;
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue;  }
    }

	// Use this for initialization
	void Start () {}

}

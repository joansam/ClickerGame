using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {

    public int currentMoney;
    public ButtonHandler buttonHandler;
    public Text MoneyText;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        MoneyText.text = "Money = " + currentMoney;
	}
}

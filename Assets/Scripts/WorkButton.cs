using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
        //WorkButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		//On buttonpressed:
        //currentMoney += 10;
	}
    public void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

}

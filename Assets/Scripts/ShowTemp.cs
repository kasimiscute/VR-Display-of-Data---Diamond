using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTemp : MonoBehaviour {

	public GameObject go;
	public Text myText;
	public Image[] images;

	// Use this for initialization
	void Start () {
		myText.color = Color.clear;
		images [0].enabled = false;
		images [1].enabled = false;
		images [2].enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void displayInfo(float temperature)
	{
		
		myText.text = "The current temperature of " + go.name + " is " + temperature;
		if (temperature < 20) {
				images [0].enabled = true;
				images [1].enabled = false;
				images [2].enabled = false;
		} else if (temperature < 26) {
				images [0].enabled = false;
				images [1].enabled = true;
				images [2].enabled = false;
			} else {
				images [0].enabled = false;
				images [1].enabled = false;
				images [2].enabled = true;
			}
	}

	void OnMouseOver(){
		myText.enabled = true;
		ChangeColor cc = go.GetComponent<ChangeColor> ();
		displayInfo (cc.temp);
	}

	void OnMouseExit(){
		myText.enabled = false;
		images [0].enabled = false;
		images [1].enabled = false;
		images [2].enabled = false;
	}
}

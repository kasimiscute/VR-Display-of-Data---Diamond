using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.IO;
using LitJson;

public class ChangeColor: MonoBehaviour {
	public Material[] meterial;
	Renderer renderer;
	public string roomID;
	public float temp;

	private string jsonString;
	private JsonData itemData;

	// Use this for initialization
	IEnumerator Start () {
		renderer = GetComponent<Renderer> ();
		renderer.enabled = true;
		renderer.sharedMaterial = meterial [0];


		WWW www = new WWW ("http://smartbms01.shef.ac.uk/sensor?id="+roomID);
		yield return www;
		jsonString = www.text;
		itemData = JsonMapper.ToObject (jsonString);
		string tem = itemData ["value"].ToString();
		double temperature = double.Parse(tem);

		temperature = System.Math.Round(temperature,2);
		temp = (float)temperature;
		//Debug.Log ("test: " + temp);
		Change (temp);
	}

	// Update is called once per frame
	void Update () {
	}

	public void Change (float temperature)
	{
		if (temperature < 18) 
		{
			renderer.sharedMaterial = meterial [0];
		}
		else if (temperature < 20) 
		{
			renderer.sharedMaterial = meterial [1];
		}
		else if (temperature < 22) 
		{
			renderer.sharedMaterial = meterial [2];
		}
		else if (temperature < 24) 
		{
			renderer.sharedMaterial = meterial [3];
		}
		else if (temperature < 26) 
		{
			renderer.sharedMaterial = meterial [4];
		}
		else if (temperature < 28) 
		{
			renderer.sharedMaterial = meterial [5];
		}
		else 
		{
			renderer.sharedMaterial = meterial [6];
		}
	}
}
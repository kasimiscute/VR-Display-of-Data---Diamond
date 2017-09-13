using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Selection : MonoBehaviour {

	public GameObject[] Floors;

	void OnGUI()
		{
		foreach (GameObject go in Floors) 
			{
				bool active = GUILayout.Toggle (go.activeSelf, go.name);
				if (active != go.activeSelf) 
				{
					go.SetActive (active);
				}
			}
		}
}

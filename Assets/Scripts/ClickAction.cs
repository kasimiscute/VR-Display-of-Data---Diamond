using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour {

	Camera playerObject;
	public Text temperatureText = null;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray toMouse = playerObject.ScreenPointToRay (Input.mousePosition);
			RaycastHit rhInfo;
			bool didHit = Physics.Raycast (toMouse, out rhInfo, 500.0f);
			if (didHit) {
				ChangeColor cc = rhInfo.collider.GetComponent<ChangeColor> ();
				if (cc) {
					temperatureText.text = ("The current temperature of " + rhInfo.collider.name + " is " + cc.temp + "C");
				}
			}
		}
	}
}

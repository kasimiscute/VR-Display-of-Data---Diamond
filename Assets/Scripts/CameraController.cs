﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//Movement
	public float panSpeed;

	//Rotator
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity;
	public float smoothing;
	public GameObject character;
	public Camera mainCamera;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	//void FixedUpdate ()
	void Update()
	{
		//float translation = Input.GetAxis ("Vertical") * panSpeed * Time.deltaTime;
		//float straffe = Input.GetAxis ("Horizontal") * panSpeed * Time.deltaTime;

		//transform.Translate (straffe, 0, translation);

		Vector3 pos = transform.position;
		if(Input.GetKey("w"))
		{
			pos += mainCamera.transform.forward * panSpeed * Time.deltaTime;
		}
		if(Input.GetKey("s"))
		{
			pos -= mainCamera.transform.forward * panSpeed * Time.deltaTime;
		}
		if(Input.GetKey("a"))
		{
			pos -= mainCamera.transform.right * panSpeed * Time.deltaTime;
		}
		if(Input.GetKey("d"))
		{
			pos += mainCamera.transform.right * panSpeed * Time.deltaTime;
		}
		if(Input.GetKey("q"))
		{
			pos.y -= panSpeed * Time.deltaTime;
		}
		if(Input.GetKey("e"))
		{
			pos.y += panSpeed * Time.deltaTime;
		}
		transform.position = pos;

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}


		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		//var md = new Vector2(mainCamera.transform.rotation.x, mainCamera.transform.rotation.y);

		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;

		mainCamera.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y,  Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
	}
}
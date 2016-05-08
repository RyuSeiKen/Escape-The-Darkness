﻿using UnityEngine;
using System.Collections;

public class Simple2DMoveController : MonoBehaviour {

  public KeyCode Left = KeyCode.LeftArrow;
  public KeyCode Right = KeyCode.RightArrow;

  public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
    Vector3 pos = transform.localPosition;
    if(Input.GetKey(Left)) pos -= transform.right * speed * Time.deltaTime;
    if(Input.GetKey(Right)) pos += transform.right * speed * Time.deltaTime;	
    transform.localPosition = pos;
	}
}

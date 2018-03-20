using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

	[Range(0, 10)]
	public int speed = 5;

	Rigidbody2D rb;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

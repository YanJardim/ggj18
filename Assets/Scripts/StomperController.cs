using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperController : MonoBehaviour {

	public List<Stompers> stomps;
	public int counter;
	// Use this for initialization
	void Start () {
		
		foreach(Transform child in transform) {
			Stompers stp = child.GetComponent<Stompers>();
			stomps.Add(stp);
			stp.OnTouchGround += OnStompTouchGround;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnStompTouchGround() {
		if (counter >= stomps.Count) counter = -1;
		counter++;
	}


}

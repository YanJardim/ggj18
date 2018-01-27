using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectByTime : MonoBehaviour {
    public GameObject obj;
    public float toggleTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (obj.active) {
            StartCoroutine(ToggleCoroutine());
        }
	}

    IEnumerator ToggleCoroutine() {
        obj.SetActive(false);
        yield return new WaitForSeconds(toggleTimer);
        obj.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPula : MonoBehaviour {
	public Animator anim;
	public float timer;
	CharacterControllerBase cont;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		timer = 0;
		cont = transform.parent.GetComponent<CharacterControllerBase>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cont.possessed) {
			if (Input.GetAxisRaw("Horizontal") != 0) {
				anim.SetBool("Walk", true);
			} else {
				timer += Time.deltaTime;
				if (timer >= 0.2f) {
					anim.SetBool("Walk", false);
					timer = 0;
				}
			}
		}
	}
}

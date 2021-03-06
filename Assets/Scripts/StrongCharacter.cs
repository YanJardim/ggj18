﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongCharacter : CharacterControllerBase {
    public float carringSpeed;
    public LayerMask rayLayer;
    public GameObject currentObject;
    public Vector2 objectCarriedPosition;
    public float rayLength = 1.0f;
    private bool isFirePressed;
    private Rigidbody2D currentRB;
	private bool isPushing;
	public AudioSource grab;

    new void Update() {
		isPushing = false;
        base.Update();

        if (!possessed) {
            return;
        }

        GetInput();
    }

    void FixedUpdate() {
        if (currentRB != null) {
            currentRB.velocity = rb.velocity;
        }
    }

    private void GetInput() {
        Debug.DrawLine(transform.position,
                      (Vector2)transform.position + ((Vector2)transform.right) * rayLength,
                      Color.yellow);

        if (Input.GetAxisRaw("Fire1") != 0) {
            if (isFirePressed == false) {
                CarryObject();
                Debug.Log(isFirePressed);
                isFirePressed = true;
				
			}
        }
        if (Input.GetAxisRaw("Fire1") == 0) {
            isFirePressed = false;
        }		
	}

    private RaycastHit2D GetObjectInFront() {
        return Physics2D.Raycast(transform.position,
                                ((Vector2)transform.right) * rayLength,
                                rayLength,
                                rayLayer);
    }

    private void CarryObject() {
        if (currentObject != null) {
            UnselectObject();
        } else {
			grab.Play();
            RaycastHit2D hit = GetObjectInFront();
            if (hit.collider != null) {
                SelectObject(hit.collider.gameObject);
            }
        }
    }

    private void UnselectObject() {
        //currentObject.GetComponent<Rigidbody2D>().isKinematic = false;
        currentObject.transform.SetParent(null);
        currentObject = null;

        currentRB.gravityScale = 1;
        currentRB.velocity = new Vector2(0, rb.velocity.y);
        currentRB = null;

		isPushing = !isPushing;
		SetPush(false);

		SpeedRevert();
    }

    private void SelectObject(GameObject obj) {
        currentObject = obj;
        currentObject.transform.SetParent(transform);
        currentObject.transform.localPosition = new Vector2(objectCarriedPosition.x,
                                                            objectCarriedPosition.y);
        currentRB = currentObject.GetComponent<Rigidbody2D>();
        currentRB.gravityScale = 0;
		//currentObject.GetComponent<Rigidbody2D>().isKinematic = true;

		isPushing = !isPushing;
		SetPush(true);

		SpeedChange(carringSpeed);
    }

	public void SetPush(bool push) {
		anim.SetBool("Walk", !push);
		anim.SetBool("Push", push);
	}


}

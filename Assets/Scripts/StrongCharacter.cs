using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongCharacter : CharacterControllerBase {
    public float carringSpeed;
    public LayerMask rayLayer;
    public GameObject currentObject;
    public float rayLength;
    private bool isFirePressed;
    private float oldSpeed;

    // Update is called once per frame
    new void FixedUpdate() {
        base.FixedUpdate();
        GetInput();
    }

    private void GetInput() {
        Debug.DrawLine(transform.position,
                      (Vector2)transform.position + (Vector2)transform.right * rayLength,
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
                                (Vector2)transform.right * rayLength,
                                rayLength,
                                rayLayer);
    }

    private void CarryObject() {
        if(currentObject != null) {
            currentObject.GetComponent<Rigidbody2D>().isKinematic = false;
            currentObject.transform.SetParent(null);
            currentObject = null;
            SpeedRevert();
        } else {
            RaycastHit2D hit = GetObjectInFront();
            if (hit.collider != null) {
                currentObject = hit.collider.gameObject;
                currentObject.transform.SetParent(transform);
                currentObject.transform.localPosition = new Vector2(1.2f, 0.1f);
                currentObject.GetComponent<Rigidbody2D>().isKinematic = true;
                SpeedChange(carringSpeed);
            }
        } 
    }

}

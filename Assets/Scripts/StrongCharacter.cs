using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongCharacter : CharacterControllerBase {
    public float carringSpeed;
    public LayerMask rayLayer = LayerMask.NameToLayer("Box");
    public GameObject currentObject;
    public Vector2 objectCarriedPosition;
    public float rayLength = 1.0f;
    private bool isFirePressed;
    
    // Update is called once per frame
    new void FixedUpdate() {
        base.FixedUpdate();

        if (!possessed) {
            return;
        }

        GetInput();
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
        if(currentObject != null) {
            UnselectObject();
        } else {
            RaycastHit2D hit = GetObjectInFront();
            if (hit.collider != null) {
                SelectObject(hit.collider.gameObject);
            }
        } 
    }

    private void UnselectObject() {
        currentObject.GetComponent<Rigidbody2D>().isKinematic = false;
        currentObject.transform.SetParent(null);
        currentObject = null;
        SpeedRevert();
    }

    private void SelectObject(GameObject obj) {
        currentObject = obj;
        currentObject.transform.SetParent(transform);
        currentObject.transform.localPosition = new Vector2(objectCarriedPosition.x, 
                                                            objectCarriedPosition.y);
        currentObject.GetComponent<Rigidbody2D>().isKinematic = true;
        SpeedChange(carringSpeed);
    }

}

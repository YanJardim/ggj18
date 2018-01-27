using UnityEngine;

public class SpiritController : CharacterControllerBase {

    public new void FixedUpdate() {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
                                          Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
    }
}
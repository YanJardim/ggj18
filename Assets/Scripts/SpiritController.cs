using UnityEngine;

public class SpiritController : Character {

    public void FixedUpdate() {

        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
                                          Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggablePlataform : Activatable {
    protected SpriteRenderer spriteR;

    protected Collider2D col;

    void Start() {
        spriteR = this.GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        Deactivate();
    }

    public override void Activate() {
        col.enabled = true;
        spriteR.color = spriteR.color + new Color(0,0,0,0.8f);
    }
    public override void Deactivate() {
        col.enabled = false;
        spriteR.color = spriteR.color - new Color(0, 0, 0, 0.8f);
    }
}

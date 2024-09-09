using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : Note
{
    public Transform noteWidth;

    protected override void Awake()
    {
        base.Awake();
        noteWidth = GetComponent<Transform>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.Log("[eq");
        //noteWidth.localScale += Vector3.up;
    }
}

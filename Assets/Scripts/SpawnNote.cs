using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteParameters : MonoBehaviour
{
    public Transform Position { get; private set;}
    public float Beat { get; private set; }
    public float Offset { get; private set; }
    public float Scale { get; private set; }
    public GameObject Type { get; private set; }


    public NoteParameters(Transform position, float beat, GameObject type, float offset = 0)
    {
        Position = position;
        Beat = beat;
        Type = type;
        Offset = offset - 0.5f;
        Scale = offset;
    }
}

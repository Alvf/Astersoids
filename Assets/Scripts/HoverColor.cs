using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverColor : MonoBehaviour
{
    TextMeshPro textmesh;
    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponent<TextMeshPro>();
    }

    void OnMouseEnter()
    {
        textmesh.faceColor = Color.blue;
    }

    void OnMouseExit()
    {
        textmesh.faceColor = Color.black;
    }
}

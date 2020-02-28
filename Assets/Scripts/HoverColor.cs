using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverColor : MonoBehaviour
{
    TextMeshPro textmesh;
    Floatie floatie;

    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponent<TextMeshPro>();
        floatie = GetComponent<Floatie>();
        floatie.active = false;
    }

    void OnMouseEnter()
    {
        textmesh.faceColor = Color.blue;
        floatie.active = true;
    }

    void OnMouseExit()
    {
        textmesh.faceColor = Color.white;
        floatie.active = false;
        floatie.memget();
    }
}

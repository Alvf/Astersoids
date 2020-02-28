using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatie : MonoBehaviour
{
    Vector2 p0;
    public Transform tf;
    public Vector2 wiggle;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        p0 = tf.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            tf.position = p0 + wiggle * Mathf.Sin(Time.time);
        }
    }

    public void memget()
    {
        tf.position = p0;
    }

 }


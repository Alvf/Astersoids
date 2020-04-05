using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float shotspeed;
    public float shotlife;
    public float disp;

    public Rigidbody2D rb;
    public GameObject shot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            var shut = Instantiate(shot,new Vector3(rb.position.x,rb.position.y,0) + new Vector3(-Mathf.Sin(rb.rotation * Mathf.Deg2Rad) * disp, disp * Mathf.Cos(rb.rotation * Mathf.Deg2Rad),0), Quaternion.identity);
            shut.GetComponent<Shot>().lifetime = shotlife;
            var shutrb = shut.GetComponent<Rigidbody2D>();
            shutrb.SetRotation(rb.rotation);
            shutrb.velocity = new Vector2(-Mathf.Sin(rb.rotation*Mathf.Deg2Rad)*shotspeed,shotspeed*Mathf.Cos(rb.rotation*Mathf.Deg2Rad));
        }
    }
}

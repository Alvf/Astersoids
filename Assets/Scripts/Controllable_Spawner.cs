using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable_Spawner : MonoBehaviour
{
    public GameObject thing_to_spawn;
    public Camera cam;
    public string tag;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            spawn();
        }
        if (Input.GetMouseButtonUp(1))
        {
            despawn();
        }
    }

    void spawn()
    {
        var spawnpos = new Vector3(Random.Range(0.0F, 1.0F), Random.Range(0.0F, 1.0F), 0);
        spawnpos = cam.ViewportToWorldPoint(spawnpos);
        spawnpos.Set(spawnpos.x, spawnpos.y, 0);

        Instantiate(thing_to_spawn, spawnpos, Quaternion.identity);
    }

    void despawn()
    {
        var things = GameObject.FindGameObjectsWithTag(tag);
        if (things.Length != 0)
        {
            GameObject.Destroy(things[things.Length - 1]);
        }
    }
}

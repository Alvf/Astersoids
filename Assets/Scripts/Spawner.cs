using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawn_frequency; //value between 0 and 1, where 1 just spawns every frame
    public GameObject thing_to_spawn; //the prefab that we spawn
    public float spawndelay;
    public int limit;
    public int count;
    public Camera cam;
    public bool withplayer;
    public float dangerzone;


    private float spawntime;

    void Start()
    {
        spawntime = Time.time;
        count = 0;
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0.0F, 1.0F) < spawn_frequency && Time.time-spawntime > spawndelay && count<limit)

        {

            var spawnpos = new Vector3(Random.Range(0.0F, 1.0F), Random.Range(0.0F, 1.0F), 0);
            spawnpos = cam.ViewportToWorldPoint(spawnpos);
            spawnpos.Set(spawnpos.x, spawnpos.y, 0);
            while (Vector3.Distance(spawnpos, GameObject.FindWithTag("BoidPredator").transform.position) <= dangerzone)
            {
                spawnpos = new Vector3(Random.Range(0.0F, 1.0F), Random.Range(0.0F, 1.0F), 0);
                spawnpos = cam.ViewportToWorldPoint(spawnpos);
                spawnpos.Set(spawnpos.x, spawnpos.y, 0);
            }

            Instantiate(thing_to_spawn, spawnpos, Quaternion.identity);
            count++;
            spawntime = Time.time;
        }
    }
}

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


    private float spawntime;

    void Start()
    {
        spawntime = Time.time;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1) < spawn_frequency && Time.time-spawntime > spawndelay && count<limit)

        {
            Instantiate(thing_to_spawn, new Vector3(0, 0, 0), Quaternion.identity);
            count++;
            spawntime = Time.time;
        }
    }
}

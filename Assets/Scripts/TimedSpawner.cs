using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject thing_to_spawn;
    public string tag;
    public float[] uptable;
    public float[] downtable;

    private float starttime;
    private int upmarker;
    private int downmarker;

    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
        upmarker = 0;
        downmarker = upmarker;
    }

    // Update is called once per frame
    void Update()
    {
        var t = Time.time - starttime;
        var obs = GameObject.FindGameObjectsWithTag(tag);

        if (upmarker < uptable.Length)
        {
            if (t > uptable[upmarker]) 
            {
                spawn();
                upmarker++;
            }

            
        }
        if (downmarker < downtable.Length)
        {
            if(t>downtable[downmarker])
            {
                destroy(obs);
                downmarker++;
            }

        }
     }
    void spawn()
    {
            var spawnpos = new Vector3(Random.Range(0.0F, 1.0F), Random.Range(0.0F, 1.0F), 0);
            spawnpos = Camera.main.ViewportToWorldPoint(spawnpos);
            spawnpos.Set(spawnpos.x, spawnpos.y, 0);

            Instantiate(thing_to_spawn, spawnpos, Quaternion.identity);
    }

    void destroy(GameObject[] things)
    {
        if (things.Length != 0)
        {
            GameObject.Destroy(things[things.Length - 1]);
        }
    }
}

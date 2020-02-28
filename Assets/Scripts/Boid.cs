using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxspeed;
    public Rigidbody2D rb;
    public float sightradius;
    public float avoidradius;
    public GameObject[] boids;
    public GameObject[] predators;

    public float vmatchbias;
    public float cohesionbias;
    public float avoidancebias;
    public float fear;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boids = GameObject.FindGameObjectsWithTag("Boid");
        predators = GameObject.FindGameObjectsWithTag("BoidPredator");
        Matchheading();

    }

    // Update is called once per frame
    void Update()
    {
        boids = GameObject.FindGameObjectsWithTag("Boid");
        Velocitymatch(boids,sightradius,vmatchbias);
        Cohesion(boids,sightradius,cohesionbias);
        Avoidance(boids,avoidradius,avoidancebias);
        Avoidance(predators,2*sightradius,fear);
        rb.velocity *= maxspeed / rb.velocity.magnitude;
        Matchheading();
    }

    void Velocitymatch(GameObject[] boids,float sight,float bias)
    {
        var netvelo = new Vector2(0, 0);
        var seenlength = 0;

        foreach(GameObject otherboid in boids)
        {
            var boidphys = otherboid.GetComponent<Rigidbody2D>();
            if ((rb.position - boidphys.position).magnitude<= sight){
                netvelo += boidphys.velocity;
                seenlength++;
            }
        }

        netvelo = netvelo / seenlength ;
        rb.AddForce(bias * (netvelo-rb.velocity));
       
    }
    void Cohesion(GameObject[] boids,float sight, float bias)
    {
        var netpos = new Vector2(0, 0);
        var seenlength = 0;

        foreach (GameObject otherboid in boids)
        {
            var boidphys = otherboid.GetComponent<Rigidbody2D>();
            var sd = (rb.position - boidphys.position).magnitude;
            if (sd <= sight)
            {
                netpos += boidphys.position;
                seenlength++;
            }
        }

        netpos = netpos / seenlength;
        rb.AddForce(bias*(netpos - rb.position));

    }
    void Avoidance(GameObject[] boids,float sight, float bias)
    {
        var netavo = new Vector2(0, 0);
        var seenlength = 0;

        foreach (GameObject otherboid in boids)
        {
            var boidphys = otherboid.GetComponent<Rigidbody2D>();
            var sd = (rb.position - boidphys.position).magnitude;
            
            if(sd<sight && sd != 0)
            {
                netavo += (rb.position - boidphys.position)/ Mathf.Pow((rb.position - boidphys.position).magnitude,2);
                seenlength++;
            }
        }

        rb.AddForce(bias * netavo);
    }

    void Matchheading()
    {
        rb.rotation = Vector2.SignedAngle(Vector2.up, rb.velocity);
    }
}

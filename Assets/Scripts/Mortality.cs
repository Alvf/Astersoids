using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mortality : MonoBehaviour
{
    public int lives;
    public float invin;
    public float oldhit;

    void start()
    {
        oldhit = -99;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time - oldhit >= invin && other.tag == "Boid")
        {
            lives--;
            Destroy(other.gameObject);
            if (lives == 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        oldhit = Time.time;
    }
}

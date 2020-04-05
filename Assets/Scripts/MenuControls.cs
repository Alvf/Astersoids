using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public bool EmptyRoids;
    public bool OnlyRoids;
    public bool DozerRoids;
    public bool AsterBoids;
    public bool Asteroids;

   void OnMouseUp()
    {
        if (EmptyRoids)
        {
            SceneManager.LoadScene("Asteroid1");
        }
        if (OnlyRoids)
        {
            SceneManager.LoadScene("Asteroid2");
        }
        if (DozerRoids)
        {
            SceneManager.LoadScene("Bulldozer");
        }
        if (AsterBoids)
        {
            SceneManager.LoadScene("AsterBoids");
        }
        if (Asteroids)
        {
            SceneManager.LoadScene("Mortal");
        }
    }
}

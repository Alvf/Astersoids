using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public bool EmptyRoids;
    public bool OnlyRoids;

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
    }
}

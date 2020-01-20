using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public bool EmptyRoids;

   void OnMouseUp()
    {
        if (EmptyRoids)
        {
            SceneManager.LoadScene("Asteroid1");
        }
    }
}

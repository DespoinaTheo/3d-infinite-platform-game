using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    void Update()
    {
        //Φορτώνει τη σκηνή menu (με χρήση του space)
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

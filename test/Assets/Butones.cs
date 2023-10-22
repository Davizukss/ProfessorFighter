using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butones : MonoBehaviour
{
   
    public void Home()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("play"); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2D : MonoBehaviour
{
    public string NombreEscena;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player2D")
        {
          
            SceneManager.LoadScene(NombreEscena, LoadSceneMode.Single);
        }
        
    }
}

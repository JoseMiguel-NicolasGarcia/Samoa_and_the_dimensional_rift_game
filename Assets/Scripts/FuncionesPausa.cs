using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuncionesPausa : MonoBehaviour
{
    public GameObject menuPausa;

    public void Continuar() 
    {
       
        menuPausa.GetComponent<Pause>().pause = !menuPausa.GetComponent<Pause>().pause;
      
        Time.timeScale = (menuPausa.GetComponent<Pause>().pause) ? 0 : 1f;
        menuPausa.GetComponentInChildren<Button>().enabled = true;

        if (menuPausa.GetComponent<Pause>().player.tag == "Player")
        {
            menuPausa.GetComponent<Pause>().player.GetComponent<LogicaProtagonista3D>().enabled = (menuPausa.GetComponent<Pause>().pause) ? false : true;
        }
    }
    public void Salir() {
        Application.Quit();
    }
}

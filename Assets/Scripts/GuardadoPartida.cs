using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardadoPartida : MonoBehaviour
{
    public GameObject player;


    private float coordenadaX;
    private float coordenadaY;
    private float coordenadaZ;
    private float vidaActual;

    public float coordenadaXInicial;
    public float coordenadaYInicial;
    public float coordenadaZInicial;
    

    public string nombreEscena;
    private string nombreEscenaInterno;

    private Vector3 vectorPosicion;
    private Vector2 vectorPosicion2D;

    void Start()
    {
       
        nombreEscenaInterno = PlayerPrefs.GetString("Escena", "SampleScene");

        if (PlayerPrefs.GetInt("MenuInicio", 0)==1) //Si venimos desde el menu de Inicio iniciamos en punto guardado
        {
            PlayerPrefs.SetInt("MenuInicio", 0);

            if (player.tag == "Player")
            {
                //Obtenemos variables

                coordenadaX = PlayerPrefs.GetFloat("X", coordenadaXInicial);
                coordenadaY = PlayerPrefs.GetFloat("Y", coordenadaYInicial);
                coordenadaZ = PlayerPrefs.GetFloat("Z", coordenadaZInicial);


                //situamos posicion correcta

                player.transform.position = new Vector3(coordenadaX, coordenadaY, coordenadaZ);

                //corregimos vida

                player.GetComponent<BarraVida>().actualHealth = PlayerPrefs.GetFloat("Vida");




            }

            if (player.tag == "Player2D")
            {
                coordenadaX = PlayerPrefs.GetFloat("X", coordenadaXInicial);
                coordenadaY = PlayerPrefs.GetFloat("Y", coordenadaYInicial);

                //situamos posicion correcta
                player.transform.position = new Vector2(coordenadaX, coordenadaY);

            }



        }



    
        Guardar();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.P))
        {
            Guardar();
        }
     
    }
    public void Guardar() 
    {

        coordenadaX = player.transform.position.x;
        coordenadaY = player.transform.position.y;
        coordenadaZ = player.transform.position.z;

        if (player.tag == "Player")
        {
            vidaActual = player.GetComponent<BarraVida>().actualHealth;
            PlayerPrefs.SetFloat("Vida", vidaActual);
        }

       PlayerPrefs.SetFloat("X", coordenadaX);
       PlayerPrefs.SetFloat("Y", coordenadaY);
       PlayerPrefs.SetFloat("Z", coordenadaZ);
       
       PlayerPrefs.SetString("Escena", nombreEscena);

       



    }
}

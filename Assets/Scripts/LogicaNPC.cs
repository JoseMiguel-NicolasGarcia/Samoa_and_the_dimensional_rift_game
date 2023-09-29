using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Specialized;
using System;

public class LogicaNPC : MonoBehaviour
{
    public GameObject player;
    public LogicaProtagonista3D protagonista;
    public GameObject panelNPC;
  
    public TextMeshProUGUI texto;

    public bool nearPlayer;
    public int numberQ;
    public List<String> dialogo;

    private AudioSource sonido;

    void Start()
    {
        nearPlayer = false;
        panelNPC.SetActive(false);
        numberQ = -1;
        sonido = GetComponent<AudioSource>();
        texto.text = "Presiona Q para hablar.";
        player = GameObject.FindGameObjectWithTag("Player");
        protagonista = player.GetComponent<LogicaProtagonista3D>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !protagonista.inAttack && !protagonista.inDeffend && !protagonista.inJump && nearPlayer) //miramos al que nos habla
        {
            Vector3 posicionProtagonista = new Vector3(transform.position.x, protagonista.gameObject.transform.position.y, transform.position.z);
            protagonista.gameObject.transform.LookAt(posicionProtagonista);

         
            numberQ++;
            Debug.Log(numberQ);
            Debug.Log(dialogo.Count);

            //paramos a nuestro protagonista
           
            if (numberQ >= 0 && numberQ < dialogo.Count)
            {
                protagonista.animator.SetFloat("VelX", 0);
                protagonista.animator.SetFloat("VelY", 0);
                protagonista.enabled = false;
             
                if (numberQ == 0)
                {
                    sonido.Play();
                }
                texto.text = dialogo[numberQ];
                
            }
            if (numberQ >= dialogo.Count)
            {

                protagonista.enabled = true;
             
                texto.text = "Presiona Q para hablar.";
                numberQ = -1;

            }

















        }
    }
    //Activar y desactivar panel por cercanía
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = true;
            panelNPC.SetActive(true);
            if (numberQ == -1)
            {
                texto.text = "Presiona Q para hablar.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = false;
            panelNPC.SetActive(false);
            texto.text = "Presiona Q para hablar.";
            numberQ = -1;
        }
    }
}

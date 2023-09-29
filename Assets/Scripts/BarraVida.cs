using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraVida : MonoBehaviour
{
    public int maxHealth;
    public float actualHealth;
    public Image barra;
    public Animator animator;

    void Start()
    {
       
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        barra.fillAmount = actualHealth / maxHealth;
        if (actualHealth <= 0)
        {


            //Activar animación de muerte
            animator.SetBool("Die", true);
           // GameObject.FindGameObjectWithTag("ExplosionFinal").SetActive(true);

            //acciones de muertes
            StartCoroutine ("retardoMuerte");
               
             
        }
    }
    IEnumerator retardoMuerte() 
    {
        yield return new WaitForSeconds(1.5f); //2s retardo de muerte

        //si no es el protagonista desaparece al morir
        if (gameObject.tag != "Player")
        {
            
            gameObject.SetActive(false);

            if (gameObject.tag == "FinalBoss")
            {

                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("YouWin", LoadSceneMode.Single);
            }

        }
        else //el prota se reinicia
        {
            //transform.position = new Vector3( 838f, 1.15f, 863f);


            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoV2 : MonoBehaviour
{

   private Animator animator;
   public float daño = 2.0f;
   public float dañoProta = 5.0f;
   public bool nearPlayer;
   public LogicaProtagonista3D protagonista;
   public BarraVida vidaProtagonista;
   public float esperaAtaque;
   private float tiempo;

    public float esperaAtaqueProta;
    private float tiempoProta;



    public bool ataco;

    void Start()
    {
        animator = GetComponent<Animator>();
        tiempo = 0;
        esperaAtaqueProta =0.5f;
        tiempoProta =0;

}


    void Update()
    {
        /* if (Input.GetKey(KeyCode.P))//daño de prueba
         {

            animator.SetBool("Hurt", true);
            GetComponent<BarraVida>().actualHealth -= daño;

         }
         else
         {
             animator.SetBool("Hurt", false);
         }*/


        //actualizamos tiempo transcurrido
        tiempo += Time.deltaTime;
        tiempoProta += Time.deltaTime;


        //daño hacia npc

        if (protagonista.inAttack && nearPlayer && GetComponent<BarraVida>().actualHealth >0)
        {
            if (tiempoProta > esperaAtaqueProta)
            {
                animator.SetBool("Hurt", true);
                GetComponent<BarraVida>().actualHealth -= dañoProta;
                tiempoProta = 0;
            }

        }
        else
        {
            animator.SetBool("Hurt", false);
        }

        //daño ejercido por npc
        if (!protagonista.inAttack && !protagonista.inDeffend && nearPlayer &&  GetComponent<BarraVida>().actualHealth > 0  ) //velocidad de ataque
        {
            if(tiempo > esperaAtaque) 
            {
                ataco = true;
                animator.SetBool("Attack", true);


                vidaProtagonista.actualHealth -= daño;

                tiempo = 0;
            }
            
        }
        else
        {
            ataco = false;
            animator.SetBool("Attack", false);
        }




    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = true;



        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearPlayer = false;

        }
    }

  
}
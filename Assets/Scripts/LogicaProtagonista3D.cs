using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaProtagonista3D : MonoBehaviour
{
    public float velocity = 5.0f;
    public float rotationVelocity = 200.0f;
    public float runVelocity = 10.0f;
    public Animator animator;
    public float x, y;

    public Rigidbody rb;
    public float JumpForce = 8f;
    public bool canJump;
    public bool inJump;

    public bool inAttack = false;
    public bool inDeffend = false;

    public float esperaAtaque;
    public float tiempoAtaque;

    public float esperaDefensa;
    public float tiempoDefensa;


    private AudioSource audioSource;
    public AudioClip swordSound;
    public AudioClip shieldSound;
   


    void Start()
    {
        canJump = false;
        animator = GetComponent<Animator>();
        tiempoAtaque = 0;
        tiempoDefensa = 0;
        esperaAtaque = 0.9f;
        esperaDefensa = 0.9f;

        audioSource = GetComponent<AudioSource>();

      

}



    void Update()
    {
        tiempoAtaque += Time.deltaTime;
        tiempoDefensa += Time.deltaTime;


        //Obtenemos información
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //animaciones de rotaciones y movimiento

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);


        //movimiento y rotacion
        if (!inAttack && !inDeffend)
        {
            transform.Rotate(0, x * Time.deltaTime * rotationVelocity, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocity);
        }
        //Movimiento si pulso shift
        if (Input.GetKey(KeyCode.LeftShift) && !inAttack && !inDeffend && !inJump)
        {
            if (y > 0)
            {
                velocity = runVelocity;
                animator.SetBool("Run", true);

            }
            else
            {
                animator.SetBool("Run", false);

            }
        }
        else
        {
            velocity = 5.0f;
            animator.SetBool("Run", false);
        }

        //animacion de salto
        // if (canJump)
        //{
        // animator.SetBool("Fall", false); //por si le meto caídas

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);

            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
        //        }
        else
        {
            //estoy cayendo
            animator.SetBool("Jump", false);
            inJump = false;

        }


        //Ataque
        if (Input.GetMouseButtonDown(0) && tiempoAtaque > esperaAtaque)
        {
            animator.SetBool("Attack", true);
            inAttack = true;
            tiempoAtaque = 0;
            audioSource.clip = swordSound;
            audioSource.Play();

        }
        else
        {
            animator.SetBool("Attack", false);
           
        }



        //Defensa
        if (Input.GetMouseButtonDown(1) && tiempoDefensa> esperaDefensa)
        {
            animator.SetBool("Defend", true);
            inDeffend = true;
            tiempoDefensa = 0;
            audioSource.clip = shieldSound;
            audioSource.Play();

        }
        else
        {
            animator.SetBool("Defend", false);
           
        }


    }
}

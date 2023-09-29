using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player2D_Controller : MonoBehaviour
{
    public float speed = 2f;
    public float maxSpeed = 4f;
    public bool grounded;
    public float jumpPower = 10f;
    public bool jump;
    public bool inAttack;
    public float esperaMuerte=100;

    public float esperaAtaque = 0;

    private Rigidbody2D rb2d;
    private Animator animator;

    public Vector3 respown;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        esperaMuerte += Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("Grounded", grounded);
       


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        
    }
    void FixedUpdate()
    {
        //Como hemoms desactivado friccion para no quedarnos pillados, la simulamos
        //hacemos que haya friccion en x pero no en y
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }

        //Iputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //Ojo en 3d cambiabas posicion y aqui usas una fuerza (es distinto)
        rb2d.AddForce(Vector2.right * speed * h); //Movimiento eje horizontal

        //que la fuerza no impulse mas que la velMax
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        //cambiar sprite en funcion a la direccion
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //salto
        if (jump && grounded) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0); //para que al atravesar un bloque no puedas saltar infinito
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
            grounded = false;
        }

        //Ataque
        esperaAtaque += Time.deltaTime;
        animator.SetBool("Attack", false);
        if (esperaAtaque >0.2) 
        {
            inAttack = false;
        }
        
       

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
            inAttack = true;
            esperaAtaque = 0;

        }
        



    }
    //Volver a la escena al salir de ella
   /* void OnBecameInvisible()
    {
        transform.position = new Vector3(-10, 0, 0);
    }*/
} 

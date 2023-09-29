using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 1f;

    private Rigidbody2D rb2d;
    private Animator animator;
   
    private bool touch= false;
  


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

  
    void Update()
    {
    
     

        //Velocidad de movimiento limitada
        rb2d.AddForce(Vector2.right * speed );

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed; 
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        //Darle la vuelta al sprite
        if (speed > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

       else if (speed < -0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player2D");

        if (touch && player.GetComponent<Player2D_Controller>().esperaMuerte >= 0.60f) 
        {
           
            player.GetComponent<Animator>().SetBool("Died", false);
            touch = false;
           
        }
        
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player2D" && !col.GetComponent<Player2D_Controller>().inAttack )
        {
            col.GetComponent<Player2D_Controller>().esperaMuerte = 0;
            col.GetComponent<Animator>().SetBool("Died", true);
            col.transform.position = col.GetComponent<Player2D_Controller>().respown;
            touch = true;
         

        }

        if (col.gameObject.tag == "Player2D" && (col.GetComponent<Player2D_Controller>().inAttack || col.GetComponentInParent<Player2D_Controller>().inAttack))
        {
            Destroy(gameObject);
        }


    }


  
}

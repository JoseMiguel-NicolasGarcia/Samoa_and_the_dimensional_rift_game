using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround2D : MonoBehaviour
{
   private Player2D_Controller player;
    private Rigidbody2D rb2d;
    
    void Start()
    {
        player = GetComponentInParent<Player2D_Controller>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {


        player.grounded = true;

        if (col.gameObject.tag == "PlataformaMovil") 
        {
            
            rb2d.velocity = Vector3.zero;
            player.transform.parent = col.transform;
            
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        player.grounded = true;
        if (col.gameObject.tag == "PlataformaMovil") {
            

            player.transform.parent = col.transform;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        player.grounded = false;
        player.transform.parent = null;
    }
}

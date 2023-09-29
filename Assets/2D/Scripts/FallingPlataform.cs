using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallDellay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private Vector3 posicionInicio;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        posicionInicio = transform.position;
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player2D")) 
        {
            Invoke("Fall", fallDellay);
            Invoke("Respown", fallDellay + respawnDelay);
        }
    }
    void Fall() 
    {
        rb2d.isKinematic = false;
        bc2d.isTrigger = true;
    }

    void Respown()
    {
        transform.position = posicionInicio;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        bc2d.isTrigger = false;
    }
}

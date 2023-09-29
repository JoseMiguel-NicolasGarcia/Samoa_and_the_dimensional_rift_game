using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRespown : MonoBehaviour
{
    private Vector3    ubicacionbandera;
    void Start()
    {
        ubicacionbandera = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player2D")
        {
            collision.GetComponent<Player2D_Controller>().respown = ubicacionbandera;
        }
    }
}

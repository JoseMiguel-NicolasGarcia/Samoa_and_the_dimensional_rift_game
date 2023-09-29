using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limite : MonoBehaviour
{
    public bool tocado= false;
    public GameObject protagonista;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player2D")
        {
            protagonista.GetComponent<Player2D_Controller>().esperaMuerte=0;
            tocado = true;
            col.transform.position = col.GetComponent<Player2D_Controller>().respown;

            protagonista.GetComponent<Animator>().SetBool("Died", true);

           


        }
    }
    void Update()
    {

        if (tocado && protagonista.GetComponent<Player2D_Controller>().esperaMuerte >= 0.45) {
            //animacion de muerte acabada
            protagonista.GetComponent<Animator>().SetBool("Died", false);

            


        }

    }


        void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player2D")
        {

            //col.GetComponent<Animator>().SetBool("Died", false);
        }
    }

}

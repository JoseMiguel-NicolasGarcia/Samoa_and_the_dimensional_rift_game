using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada2D : MonoBehaviour

{
   
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       if ( GetComponent<Player2D_Controller>().inAttack)
        {
          GetComponent<CapsuleCollider2D>().enabled =true;
          
        }
        else 
        {

            GetComponent<CapsuleCollider2D>().enabled = false;
        }

      
        
    }
/*void OnTriggerStay2D(Collider2D col)
    {
        print(gameObject.layer);
        if (col.gameObject.layer == 9 && player2D.GetComponent<Player2D_Controller>().inAttack)
        {
            Destroy(gameObject);

        }



    }*/
    }

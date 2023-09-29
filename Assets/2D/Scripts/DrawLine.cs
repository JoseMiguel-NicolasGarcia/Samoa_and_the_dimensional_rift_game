using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform from;
   public Transform to;
    void Start()
    {

        

    }


    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        if (to != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.2f);
            Gizmos.DrawSphere(to.position, 0.2f);
        
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class IAEnemiga : MonoBehaviour
{
    public GameObject target;
    private Animator animator;
    public float distance;
    private AudioSource sonido;
    private float sonidoEnable = 250f;
    public float tiempoSonidoEnable = 3f;
    void Start()
    {
      animator = GetComponent<Animator>();
       sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
        sonidoEnable += Time.deltaTime;
        if (GetComponent<BarraVida>().actualHealth > 0)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < distance)
            {
                GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
                GetComponent<NavMeshAgent>().speed = 5;
                animator.SetBool("Walk", true);
                if (!sonido.isPlaying && sonidoEnable> tiempoSonidoEnable)
                {
                    sonido.Play();
                    sonidoEnable = 0;
                    
                }
                
            }
            else
            {
                GetComponent<NavMeshAgent>().speed = 0;
                animator.SetBool("Walk", false);
              
            }
        }
    }
}

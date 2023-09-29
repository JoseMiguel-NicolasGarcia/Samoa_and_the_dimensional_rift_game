using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSound : MonoBehaviour
{
    private AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        if ((GetComponentInParent<LogicaProtagonista3D>().y > 0.01 || GetComponentInParent<LogicaProtagonista3D>().y < -0.01) && GetComponentInParent<LogicaProtagonista3D>().velocity >= 8 && !sonido.isPlaying)
        {
            sonido.Play();
            

        }
        if (sonido.isPlaying && (!(GetComponentInParent<LogicaProtagonista3D>().y > 0.01 || GetComponentInParent<LogicaProtagonista3D>().y < -0.0) || GetComponentInParent<LogicaProtagonista3D>().velocity < 8))
        {
           
            sonido.Stop();
        }

    }
}
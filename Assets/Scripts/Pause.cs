using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public  bool pause;
    private  Canvas canvas;
    public GameObject player;
    void Start()
    {
        pause = false;
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.enabled = pause;
        if (Input.GetKeyDown("escape")) {
            pause = !pause;
            Time.timeScale = (pause) ? 0 : 1f;

            if (player.tag=="Player")
            {
                player.GetComponent<LogicaProtagonista3D>().enabled = (pause) ? false : true;
            }
           

            

        }
    }
}

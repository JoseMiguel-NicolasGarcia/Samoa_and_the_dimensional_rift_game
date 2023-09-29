using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionSuelo : MonoBehaviour
{
    public LogicaProtagonista3D logicaProtagonista3D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) 
    {
        logicaProtagonista3D.canJump = true;
    }
    private void OnTriggerExit(Collider other)
    {
        logicaProtagonista3D.canJump = false;
    }
}

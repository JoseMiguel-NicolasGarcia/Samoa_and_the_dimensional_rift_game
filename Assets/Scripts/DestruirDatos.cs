using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDatos : MonoBehaviour
{
    public void Borrar() 
    {
        PlayerPrefs.DeleteAll();
    }
}

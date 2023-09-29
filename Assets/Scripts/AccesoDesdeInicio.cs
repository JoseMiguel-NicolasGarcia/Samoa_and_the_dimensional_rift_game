using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesoDesdeInicio : MonoBehaviour
{
 
    public void AccesoInicio()
    {
        PlayerPrefs.SetInt("MenuInicio", 1); //Accedemos desde Menu Inicio
    }

}

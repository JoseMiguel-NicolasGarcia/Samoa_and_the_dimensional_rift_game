using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{

    public Text jugar;
    public Text salir;
    public Text nuevaPartida;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseOverJugar(){

      Debug.Log("Entramos Jugar");
      jugar.GetComponent<Text> ().color = new Color(19, 85, 4, 255);
    }

    public void OnMouseOverSalir(){

      Debug.Log("Entramos Salir");
      salir.GetComponent<Text> ().color = new Color(161, 14, 14, 255);
    }
    public void OnMouseOverNueva()
    {

       
        nuevaPartida.GetComponent<Text>().color = new Color(161, 14, 14, 255);
    }
    public void OnMouseExitNueva()
    {
        
        nuevaPartida.GetComponent<Text>().color = new Color(0, 0, 0, 255);
    }

    public void OnMouseExitJugar(){
      Debug.Log("Salimos Jugar");
      jugar.GetComponent<Text> ().color = new Color(0, 0, 0, 255);
    }

    public void OnMouseExitSalir(){
      Debug.Log("Salimos Salir");
      salir.GetComponent<Text> ().color = new Color(0, 0, 0, 255);
    }

    public void EmpezarPartida() {
        SceneManager.LoadScene(PlayerPrefs.GetString("Escena", "SampleScene"));
    }

    public void SalirPartida() {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}

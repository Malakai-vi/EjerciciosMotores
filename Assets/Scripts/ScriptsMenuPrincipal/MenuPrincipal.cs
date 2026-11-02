using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void JugarNivel1()
    {
        SceneManager.LoadScene("Nivel1"); 
    }

    public void JugarNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

    public void JugarNivel3()
    {
        SceneManager.LoadScene("Nivel3");
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
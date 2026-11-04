using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //Ejercicio 20: Pausa (en vez de con ESC con botón
    //P ya que he usado ESC para los saltos)
    [SerializeField] private GameObject panelPausa;
    private bool juegoPausado = false;

    void Start()
    {
        // Asegura que el panel empiece cerrado y el tiempo corriendo
        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }
        Time.timeScale = 1f;
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("¡Tecla P detectada en Update!");

            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Continuar()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }
        Time.timeScale = 1f; // Reanuda físicas y tiempos
        juegoPausado = false;
    }

    public void Pausar()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
        }
        Time.timeScale = 0f; // Congela el juego
        juegoPausado = true;
    }

    public void SalirAlMenu()
    {
        Time.timeScale = 1f; // Renauda el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MenuPrincipal");
    }
}
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    [SerializeField] private TextMeshProUGUI textoMonedas;
    private int contadorMonedas = 0;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarMoneda()
    {
        //Ejercicio 5, primera parte: Contador de monedas
        //(segunda parte en el script Moneda)
        contadorMonedas++;
        textoMonedas.text = "Monedas: " + contadorMonedas;
    }
}
using UnityEngine;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instancia { get; private set; }

    [Header("UI Textos")]
    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private TextMeshProUGUI textoVidas;

    [Header("Paneles UI")]
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelVictoria;

    [Header("Configuracion")]
    [SerializeField] private int vidasMaximas = 3;
    [SerializeField] private int monedasParaGanar = 10;
    private int vidasActuales;
    private int contadorMonedas = 0;

    void Awake()
    {
        if (Instancia == null) Instancia = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        vidasActuales = vidasMaximas;
        ActualizarUIVidas();

        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

    public void SumarMoneda()
    {
        contadorMonedas++;
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + contadorMonedas;
        }
    }

    //Ejercicio 8: Sistema de vidas
    public void RestarVida()
    {
        vidasActuales--;
        ActualizarUIVidas();

        if (vidasActuales <= 0)
        {
            vidasActuales = 0;
            ActivarGameOver();
        }
    }

    private void ActualizarUIVidas()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidasActuales;
        }
    }

    private void ActivarGameOver()
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void IntentarGanar()
    {
        if (contadorMonedas >= monedasParaGanar)
        {
            if (panelVictoria != null) panelVictoria.SetActive(true);
        }
    }

    public int GetMonedas() => contadorMonedas;
    public int GetVidas() => vidasActuales;
}
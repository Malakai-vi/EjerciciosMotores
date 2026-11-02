using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaludPlayer : MonoBehaviour
{
    [Header("Configuracion de Vida (Ejercicio 18)")]
    [SerializeField] private float vidaMaxima = 100f;
    [SerializeField] private Slider barraVida;

    [Header("Invulnerabilidad (Ejercicio 19)")]
    [SerializeField] private float duracionInvulnerabilidad = 1.5f;
    [SerializeField] private float intervaloParpadeo = 0.15f;

    private float vidaActual;
    private bool esInvulnerable = false;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        vidaActual = vidaMaxima;
        if (barraVida != null)
        {
            barraVida.maxValue = vidaMaxima;
            barraVida.value = vidaActual;
        }
    }

    public void RecibirDanio(float cantidadDanio)
    {
        if (esInvulnerable) return;

        vidaActual -= cantidadDanio;
        if (barraVida != null) barraVida.value = vidaActual;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            if (GameManager3.Instancia != null)
            {
                GameManager3.Instancia.ActivarGameOver();
            }
        }
        else
        {
            StartCoroutine(RutinaInvulnerabilidad());
        }
    }

    private IEnumerator RutinaInvulnerabilidad()
    {
        esInvulnerable = true;
        float tiempoPasado = 0f;

        // Temporizador con Time.deltaTime y parpadeo
        while (tiempoPasado < duracionInvulnerabilidad)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(intervaloParpadeo);
            tiempoPasado += intervaloParpadeo;
        }

        spriteRenderer.enabled = true;
        esInvulnerable = false;
    }
}
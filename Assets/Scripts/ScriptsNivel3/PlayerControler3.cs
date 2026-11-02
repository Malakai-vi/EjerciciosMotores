using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 8f;
    [SerializeField] private float fuerzaSalto = 12f;

    [Header("Deteccion de Suelo")]
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector2 dimensionesCajaSuelo = new Vector2(0.8f, 0.2f);
    [SerializeField] private LayerMask capaSuelo;

    [Header("Configuracion Saltos (Nivel 3)")]
    [SerializeField] private int saltosMaximos = 2;
    [SerializeField] private float retardoEntreSaltos = 0.25f; // Tiempo mínimo entre saltos

    private int saltosRestantes;
    private float tiempoSiguienteSalto = 0f;
    private bool enSuelo;

    private Rigidbody2D rb;
    private float movimientoHorizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        // Ejercicio 14: Detectar si toca el suelo
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCajaSuelo, 0f, capaSuelo);

        // Si está en el suelo y no va subiendo, reiniciamos saltos
        if (enSuelo && rb.linearVelocity.y <= 0.1f)
        {
            saltosRestantes = saltosMaximos;
        }

        // Ejercicio 15 y 16: Salto y doble salto condicionado con temporizador
        if (Input.GetButtonDown("Jump") && saltosRestantes > 0 && Time.time >= tiempoSiguienteSalto)
        {
            EjecutarSalto();
        }
    }

    private void EjecutarSalto()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        saltosRestantes--;
        tiempoSiguienteSalto = Time.time + retardoEntreSaltos; // Ejercicio 16: retardo
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
    }

    public void RebotarEnemigo(float fuerzaRebote)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaRebote);
        saltosRestantes = 1; // Permite un salto extra en el aire tras pisar al enemigo
    }

    private void OnDrawGizmosSelected()
    {
        if (controladorSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCajaSuelo);
        }
    }
}

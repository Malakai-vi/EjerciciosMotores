using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuracion de Movimiento")]
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private float movimientoHorizontal;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Los ejercicios están hechos utilizando el sistema clásico
        //sin usar el Input System activado por defecto aún

        // Ejercicio 1: Movimiento horizontal
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        // Ejercicio 2: Salto básico
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
    }
}

using UnityEngine;

public class ZonaPeligro : MonoBehaviour
{
    [SerializeField] private Transform puntoAparicion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ejercicio 4: Zona de peligro. Aquí es donde devuelve al jugador al inicio
            // y detiene su inercia al colisionar
            collision.transform.position = puntoAparicion.position;

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}

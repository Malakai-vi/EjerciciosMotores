using UnityEngine;

public class ZonaPeligro2 : MonoBehaviour
{
    [SerializeField] private Transform puntoAparicion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Resta una vida en el GameManager
            if (GameManager2.Instancia != null)
            {
                GameManager2.Instancia.RestarVida();
            }

            /* Aquí queda la dinámica anterior del nivel 1
             * que devolvía al punto de aparición
             * 
            if (puntoAparicion != null)
            {
                collision.transform.position = puntoAparicion.position;
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                }
            }
            */
        }
    }
}

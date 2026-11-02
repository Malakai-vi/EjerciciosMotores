using UnityEngine;

public class CabezaEnemigo : MonoBehaviour
{
    //Ejercicio 17: eliminar enemigos saltando encima
    [SerializeField] private float impulsoRebote = 10f;
    [SerializeField] private GameObject enemigoPadre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rbPlayer = collision.GetComponent<Rigidbody2D>();
            if (rbPlayer != null && rbPlayer.linearVelocity.y <= 0f)
            {
                PlayerController3 controller = collision.GetComponent<PlayerController3>();
                if (controller != null)
                {
                    controller.RebotarEnemigo(impulsoRebote);
                }

                Destroy(enemigoPadre != null ? enemigoPadre : gameObject);
            }
        }
    }
}

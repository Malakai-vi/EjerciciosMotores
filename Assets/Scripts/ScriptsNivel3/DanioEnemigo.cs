using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{
    [SerializeField] private float cantidadDanio = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            SaludPlayer salud = collision.gameObject.GetComponent<SaludPlayer>();
            if (salud != null)
            {
                salud.RecibirDanio(cantidadDanio);
            }
        }
    }
}
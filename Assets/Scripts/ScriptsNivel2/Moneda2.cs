using UnityEngine;

public class Moneda2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager2.Instancia.SumarMoneda();
            Destroy(gameObject);
        }
    }
}
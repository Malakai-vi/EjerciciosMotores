using UnityEngine;

public class Llave : MonoBehaviour
{
    [SerializeField] private GameObject puertaADesactivar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (puertaADesactivar != null)
            {
                puertaADesactivar.SetActive(false); // Abre la puerta
                Debug.Log("Se desactiva la puerta");
            }
            Destroy(gameObject); // Desaparece la llave
        }
    }
}
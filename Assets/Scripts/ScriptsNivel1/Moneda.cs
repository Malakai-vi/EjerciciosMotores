using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Ejercicio 5, segunda parte: Las monedas se suman y desaparecen
            //(primera parte en el script GameManager)
            GameManager.Instancia.SumarMoneda();
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class CartelInformativo : MonoBehaviour
{
    [SerializeField] private GameObject textoUI;

    //Ejercicio 6: cartel informativo. En este caso he aprovechado
    //que he puesto la zona de peligro como lava para que el mensaje
    //sea "Cuidado con la lava" en vez de abismo.
    private void Start()
    {
        //Aquí dejo el texto desactivado para que
        //no aparezca nada más empezar la partida
        if (textoUI != null)
        {
            textoUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Aquí activo el colisionador del Game Object
        //vacío para que aparezca el texto cuando se aproxime
        if (collision.CompareTag("Player"))
        {
            textoUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Aquí desactivo el mensaje para desaparezca al alejarse
        if (collision.CompareTag("Player"))
        {
            textoUI.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class ControlAcelerador : MonoBehaviour
{
    [Header("Ejercicio 3: Acelerador Digital vs Analógico")]
    [SerializeField] private InputActionProperty acelerarAction;
    [SerializeField] private float velocidadMaxima = 8f;
    [SerializeField] private float valorActualLectura;

    private void OnEnable()
    {
        acelerarAction.action.Enable();
    }

    private void OnDisable()
    {
        acelerarAction.action.Disable();
    }

    private void Update()
    {
        // Lectura continua del float (0 o 1 en teclado | 0.0 a 1.0 progresivo en gatillo)
        valorActualLectura = acelerarAction.action.ReadValue<float>();

        if (valorActualLectura > 0f)
        {
            float velocidadActual = valorActualLectura * velocidadMaxima;

            // Mueve el objeto en 2D hacia la derecha según la aceleración
            transform.Translate(Vector2.right * (velocidadActual * Time.deltaTime));

            Debug.Log($"Aceleración: {valorActualLectura:F2} ({valorActualLectura * 100f:F0}%) | Velocidad: {velocidadActual:F2}");
        }
    }
}

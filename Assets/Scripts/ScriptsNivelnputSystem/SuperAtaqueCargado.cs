using UnityEngine;
using UnityEngine.InputSystem;

public class SuperAtaqueCargado : MonoBehaviour
{
    [Header("Ejercicio 4: Superataque (Hold 1.0s)")]
    [SerializeField] private InputActionProperty superAtaqueAction;

    private bool ataqueCompletado;

    private void OnEnable()
    {
        superAtaqueAction.action.Enable();

        superAtaqueAction.action.started += AlIniciarCarga;
        superAtaqueAction.action.performed += AlCompletarCarga;
        superAtaqueAction.action.canceled += AlCancelarCarga;
    }

    private void OnDisable()
    {
        superAtaqueAction.action.started -= AlIniciarCarga;
        superAtaqueAction.action.performed -= AlCompletarCarga;
        superAtaqueAction.action.canceled -= AlCancelarCarga;

        superAtaqueAction.action.Disable();
    }

    private void AlIniciarCarga(InputAction.CallbackContext context)
    {
        ataqueCompletado = false;
        Debug.Log("Cargando superataque...");
    }

    private void AlCompletarCarga(InputAction.CallbackContext context)
    {
        ataqueCompletado = true;
        Debug.Log("¡SUPERATAQUE EJECUTADO!");
    }

    private void AlCancelarCarga(InputAction.CallbackContext context)
    {
        // Avisa si el jugador suelta el botón antes de llegar a 1 segundo
        if (!ataqueCompletado)
        {
            Debug.Log("Carga interrumpida antes de 1 segundo.");
        }
    }
}

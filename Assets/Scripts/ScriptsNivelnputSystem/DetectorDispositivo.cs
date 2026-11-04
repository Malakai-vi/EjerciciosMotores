using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DetectorDispositivo : MonoBehaviour
{
    [Header("Referencias Ejercicio 2")]
    [SerializeField] private InputActionAsset controlesAsset;
    [SerializeField] private TextMeshProUGUI textoHUD;

    private string ultimoEsquema = "";

    private void OnEnable()
    {
        if (controlesAsset == null) return;

        // Activa el asset por seguridad y se suscribe a todas sus acciones
        controlesAsset.Enable();

        foreach (InputActionMap mapa in controlesAsset.actionMaps)
        {
            foreach (InputAction accion in mapa.actions)
            {
                accion.started += DetectarPeriferico;
                accion.performed += DetectarPeriferico;
            }
        }
    }

    private void OnDisable()
    {
        if (controlesAsset == null) return;

        foreach (InputActionMap mapa in controlesAsset.actionMaps)
        {
            foreach (InputAction accion in mapa.actions)
            {
                accion.started -= DetectarPeriferico;
                accion.performed -= DetectarPeriferico;
            }
        }
    }

    private void DetectarPeriferico(InputAction.CallbackContext context)
    {
        // Evalua la propiedad requerida por el enunciado: CallbackContext.control.device
        InputDevice dispositivo = context.control.device;

        if (dispositivo is Keyboard || dispositivo is Mouse)
        {
            ActualizarTexto("TECLADO Y RATÓN");
        }
        else if (dispositivo is Gamepad)
        {
            ActualizarTexto("GAMEPAD");
        }
    }

    private void ActualizarTexto(string nombreDispositivo)
    {
        // Solo actualiza el TextMeshPro cuando realmente cambia de periférico
        if (ultimoEsquema == nombreDispositivo) return;

        ultimoEsquema = nombreDispositivo;

        if (textoHUD != null)
        {
            textoHUD.text = "Control activo: " + nombreDispositivo;
        }
    }
}

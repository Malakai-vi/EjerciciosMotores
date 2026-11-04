using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo Input System

public class PlayerControllerInputSystem : MonoBehaviour
{
    [Header("Configuracion de Movimiento")]
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 7f;

    [Header("Ejercicio 1: Acciones (Input System)")]
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty jumpAction;
    [SerializeField] private InputActionProperty fireAction;

    private Rigidbody2D rb;
    private Vector2 inputMovimiento;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        fireAction.action.Enable();

        jumpAction.action.performed += AlSaltar;
        fireAction.action.performed += AlDisparar;
    }

    private void OnDisable()
    {
        // Los quitamos al desactivar el objeto
        jumpAction.action.performed -= AlSaltar;
        fireAction.action.performed -= AlDisparar;

        moveAction.action.Disable();
        jumpAction.action.Disable();
        fireAction.action.Disable();
    }

    void Update()
    {
        // Leemos el Vector2 tanto de WASD como del Left Stick sin distinguir periférico
        inputMovimiento = moveAction.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Aplicamos el eje X a tu física 2D original
        rb.linearVelocity = new Vector2(inputMovimiento.x * velocidad, rb.linearVelocity.y);
    }

    private void AlSaltar(InputAction.CallbackContext context)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }

    private void AlDisparar(InputAction.CallbackContext context)
    {
        Debug.Log("¡Disparo activado!");
    }
}
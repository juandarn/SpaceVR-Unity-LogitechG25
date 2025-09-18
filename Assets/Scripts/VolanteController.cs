using UnityEngine;
using UnityEngine.InputSystem; // <- Necesario para el nuevo Input System

public class VolanteController : MonoBehaviour
{
    [Header("Referencia al volante en el auto")]
    public Transform volanteMesh;

    [Header("Configuración del giro")]
    public float maxAngulo = 450f;   // cuanto puede girar el volante (450 = 1.25 vueltas)
    public float suavizado = 5f;     // qué tan rápido interpola

    private Controles controles;
    private float inputDireccion;
    private float anguloActual;

    void Awake()
    {
        // Inicializar el mapa de controles
        controles = new Controles();
    }

    void OnEnable()
    {
        controles.Enable();
    }

    void OnDisable()
    {
        controles.Disable();
    }

    void Update()
    {
        // Leer el valor del eje Direccion del volante real
        inputDireccion = controles.Wheel.Direccion.ReadValue<float>();

        // Calcular el ángulo deseado
        float anguloObjetivo = inputDireccion * maxAngulo;

        // Interpolar suavemente hacia ese ángulo
        anguloActual = Mathf.Lerp(anguloActual, anguloObjetivo, Time.deltaTime * suavizado);

        // Aplicar rotación (ajusta el eje según tu modelo)
        volanteMesh.localRotation = Quaternion.Euler(0f, 0f, -anguloActual);
    }
}

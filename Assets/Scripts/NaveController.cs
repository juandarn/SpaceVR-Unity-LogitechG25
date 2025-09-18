using UnityEngine;
using UnityEngine.InputSystem;

public class NaveController : MonoBehaviour, Controles.IWheelActions
{
    [Header("Parámetros de vuelo")]
    public float potenciaMotor = 40f;
    public float potenciaRotacion = 1f;
    public float velocidadMax = 40f;
    public float alturaMinima = 32.1f; // límite inferior
    public float distanciaVertical = 30f; // distancia fija por tick
    public float suavizadoVertical = 8f; // velocidad para suavizar el tick

    [Header("Proyectil")]
    public GameObject proyectilPrefab;
    public Transform puntoDisparo1; // cañón izquierdo
    public Transform puntoDisparo2; // cañón derecho
    public float velocidadProyectil = 20f;

    [Header("Disparo automático")]
    public float cadencia = 0.1f;
    private float tiempoSiguienteDisparo1 = 0f;
    private float tiempoSiguienteDisparo2 = 0f;

    [Header("Cooldown vertical")]
    public float cooldownVertical = 0.2f; // tiempo entre ticks
    private float tiempoUltimoTick = -1f;

    [Header("Sonido")]
    public AudioClip sonidoDisparo;   // asigna tu audio en el inspector
    private AudioSource audioSource;

    private Controles controles;
    private Rigidbody rb;

    // Entradas del volante
    private float direccion;
    private float acelerador;
    private float freno;

    // Vertical momentáneo
    private bool subir = false;
    private bool bajar = false;

    // Objetivo de altura al hacer tick
    private float alturaObjetivo;

    private bool colisionada = false;

    void Awake()
    {
        controles = new Controles();
        controles.Wheel.SetCallbacks(this);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnEnable() => controles.Enable();
    void OnDisable() => controles.Disable();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = 0.1f;
        rb.angularDamping = 0.2f;

        alturaObjetivo = transform.position.y;
    }

    void FixedUpdate()
    {
        if (colisionada) return;

        // Avance hacia adelante
        float fuerza = (acelerador - freno) * potenciaMotor;
        rb.AddForce(transform.forward * fuerza, ForceMode.Acceleration);

        // --- Subir con tick ---
        if (subir && Time.time - tiempoUltimoTick >= cooldownVertical)
        {
            alturaObjetivo += distanciaVertical;
            tiempoUltimoTick = Time.time;
            subir = false;
        }

        // --- Bajar con tick ---
        if (bajar && Time.time - tiempoUltimoTick >= cooldownVertical)
        {
            alturaObjetivo -= distanciaVertical;
            if (alturaObjetivo < alturaMinima)
                alturaObjetivo = alturaMinima;

            tiempoUltimoTick = Time.time;
            bajar = false;
        }

        // --- Interpolación suave hacia altura objetivo ---
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(pos.y, alturaObjetivo, Time.fixedDeltaTime * suavizadoVertical);
        transform.position = pos;

        // Evitar que se pase por debajo del límite
        if (transform.position.y < alturaMinima)
        {
            Vector3 p = transform.position;
            p.y = alturaMinima;
            transform.position = p;
            alturaObjetivo = alturaMinima;
        }

        // Giro
        float giro = direccion * potenciaRotacion;
        float giroSuave = Mathf.Lerp(rb.angularVelocity.y, giro, Time.fixedDeltaTime * 3f);
        rb.angularVelocity = new Vector3(0f, giroSuave, 0f);

        // Inclinación visual
        float inclinacionMax = 15f;
        float inclinacion = Mathf.LerpAngle(
            transform.localEulerAngles.z,
            -direccion * inclinacionMax,
            Time.fixedDeltaTime * 2f
        );
        transform.localRotation = Quaternion.Euler(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y,
            inclinacion
        );

        // Límite de velocidad
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, velocidadMax);
    }

    void Update()
    {
        // Disparo automático
        if (controles.Wheel.Disparar.IsPressed() && Time.time >= tiempoSiguienteDisparo2)
        {
            Disparar(puntoDisparo2);
            tiempoSiguienteDisparo2 = Time.time + cadencia;
        }

        if (controles.Wheel.Disparar2.IsPressed() && Time.time >= tiempoSiguienteDisparo1)
        {
            Disparar(puntoDisparo1);
            tiempoSiguienteDisparo1 = Time.time + cadencia;
        }
    }

    // ---------- Callbacks Input System ----------
    public void OnDireccion(InputAction.CallbackContext context) => direccion = context.ReadValue<float>();
    public void OnAcelerador(InputAction.CallbackContext context) => acelerador = context.ReadValue<float>();
    public void OnFreno(InputAction.CallbackContext context) => freno = context.ReadValue<float>();

    public void OnMarcha1(InputAction.CallbackContext context)
    {
        if (context.performed) subir = true;
    }

    public void OnMarcha2(InputAction.CallbackContext context)
    {
        if (context.performed) bajar = true;
    }

    public void OnEmbrague(InputAction.CallbackContext context) { }
    public void OnMovimiento(InputAction.CallbackContext context) { }
    public void OnDisparar(InputAction.CallbackContext context) { if (context.performed) Disparar(puntoDisparo2); }
    public void OnDisparar2(InputAction.CallbackContext context) { if (context.performed) Disparar(puntoDisparo1); }
    public void OnMarcha3(InputAction.CallbackContext context) { }
    public void OnSomeOtherAction(InputAction.CallbackContext context) { }

    // ---------- Disparo ----------
    private void Disparar(Transform cañon)
    {
        if (proyectilPrefab != null && cañon != null)
        {
            Vector3 direccionProyectil = transform.forward;
            Quaternion rotacion = Quaternion.LookRotation(direccionProyectil);
            rotacion *= Quaternion.Euler(0, 90f, 90f);

            GameObject proyectil = Instantiate(proyectilPrefab, cañon.position, rotacion);

            Rigidbody rbProy = proyectil.GetComponent<Rigidbody>();
            if (rbProy != null)
            {
                rbProy.linearVelocity = rb.linearVelocity + direccionProyectil * velocidadProyectil;
                rbProy.linearDamping = 0f;
                rbProy.angularDamping = 0f;
            }

            proyectil.transform.parent = null;
            Destroy(proyectil, 5f);

            // Sonido del disparo
            if (sonidoDisparo != null)
            {
                audioSource.PlayOneShot(sonidoDisparo);
            }
        }
    }

    // ---------- Colisiones ----------
    private void OnCollisionEnter(Collision collision)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        colisionada = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colisionada = false;
    }
}

using UnityEngine;
using TMPro;

public class NaveVidaTimer : MonoBehaviour
{
    [Header("UI Vida")]
    public TextMeshProUGUI textoVida;
    public GameObject panelVida;

    [Header("UI Puntos")]
    public GameObject panelPuntos;

    [Header("UI Game Over")]
    public GameObject panelGameOver;

    [Header("Pantalla de Instrucciones")]
    public GameObject panelInstrucciones; // panel con el texto de controles
    public float tiempoInstrucciones = 5f; // segundos que dura la pantalla inicial

    [Header("Configuración de Vida")]
    public int vidaMaxima = 100;
    private float vidaActual;
    public float vidaPorSegundo = 5f;

    private bool gameOver = false;
    private bool juegoIniciado = false;
    private float cuentaRegresiva;

    private void Start()
    {
        vidaActual = vidaMaxima;
        ActualizarUI();

        // ocultar paneles
        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (panelVida != null) panelVida.SetActive(false);
        if (panelPuntos != null) panelPuntos.SetActive(false);

        // mostrar instrucciones
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(true);
            cuentaRegresiva = tiempoInstrucciones;
        }
    }

    private void Update()
    {
        if (!juegoIniciado)
        {
            // cuenta atrás de instrucciones
            cuentaRegresiva -= Time.deltaTime;
            if (cuentaRegresiva <= 0f)
            {
                IniciarJuego();
            }
            return;
        }

        if (gameOver) return;

        // vida se reduce con el tiempo
        if (vidaActual > 0)
        {
            vidaActual -= vidaPorSegundo * Time.deltaTime;
            if (vidaActual < 0) vidaActual = 0;

            ActualizarUI();
        }

        if (vidaActual <= 0 && !gameOver)
        {
            GameOver();
        }
    }

    private void IniciarJuego()
    {
        juegoIniciado = true;

        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);

        if (panelVida != null)
            panelVida.SetActive(true);

        if (panelPuntos != null)
            panelPuntos.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameOver) return;

        if (other.CompareTag("Esfera"))
        {
            vidaActual += 20;
            if (vidaActual > vidaMaxima)
                vidaActual = vidaMaxima;

            ActualizarUI();
            Destroy(other.gameObject);
        }
    }

    private void ActualizarUI()
    {
        if (textoVida != null)
            textoVida.text = "Vida: " + Mathf.RoundToInt(vidaActual) + " / " + vidaMaxima;
    }

    private void GameOver()
    {
        gameOver = true;

        if (panelVida != null) panelVida.SetActive(false);
        if (panelPuntos != null) panelPuntos.SetActive(false);
        if (panelGameOver != null) panelGameOver.SetActive(true);
    }
}

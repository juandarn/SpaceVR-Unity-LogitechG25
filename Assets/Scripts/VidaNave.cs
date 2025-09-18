using UnityEngine;

public class VidaNave : MonoBehaviour
{
    [Header("Vida de la nave")]
    public float vidaMaxima = 100f;   // Vida máxima
    private float vida;               // Vida actual

    void Start()
    {
        vida = vidaMaxima;
    }

    // Método público para recibir daño
    public void RecibirDanio(float cantidad)
    {
        vida -= cantidad;

        if (vida <= 0f)
        {
            Explodir();
        }
    }

    // Método que destruye la nave
    private void Explodir()
    {
        // Aquí puedes agregar efectos visuales o sonido
        Destroy(gameObject);
    }

    // Método para obtener la vida actual
    public float ObtenerVidaActual()
    {
        return vida;
    }
}

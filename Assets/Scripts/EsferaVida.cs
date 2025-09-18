using UnityEngine;
using TMPro;

public class EsferaVida : MonoBehaviour
{
    public int vida = 100;        // Vida inicial
    public int dañoPorNave = 10;  // Daño por cada nave

    private TMP_Text textoContador;

    private void Start()
    {
        // Buscar automáticamente el objeto llamado "HealthText" en la escena
        GameObject textoObj = GameObject.Find("HealthText");
        if (textoObj != null)
        {
            textoContador = textoObj.GetComponent<TMP_Text>();
            textoContador.text = "Vida: " + vida;
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto llamado 'HealthText' en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nave"))
        {
            vida -= dañoPorNave;

            if (textoContador != null)
            {
                textoContador.text = "Vida: " + vida;
            }

            Debug.Log("Nave pasó por la esfera. Vida restante: " + vida);

            // Opcional: destruir la nave
            // Destroy(other.gameObject);
        }
    }
}

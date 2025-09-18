using UnityEngine;
using TMPro;
using System.Collections;

public class SpawnerAleatorio : MonoBehaviour
{
    [Header("Prefab a instanciar")]
    public GameObject esferaPrefab;

    [Header("Área de aparición")]
    public Vector3 centro = Vector3.zero;
    public Vector3 tamaño = new Vector3(10, 0, 10); // ancho y largo del área

    [Header("Temporizador")]
    public float intervalo = 3f;
    public int maxSpawns = 0; // 0 = infinito
    public TextMeshProUGUI textoTemporizador;

    float cuenta;
    int totalSpawns = 0;

    void Start()
    {
        if (esferaPrefab == null)
        {
            Debug.LogError("Asigna el prefab en el inspector.");
            enabled = false;
            return;
        }

        StartCoroutine(CicloSpawn());
    }

    IEnumerator CicloSpawn()
    {
        while (true)
        {
            // Cuenta atrás
            cuenta = intervalo;
            while (cuenta > 0f)
            {
                cuenta -= Time.deltaTime;
                if (textoTemporizador != null)
                    textoTemporizador.text = cuenta.ToString("0.0");
                yield return null;
            }

            // Generar spawn
            HacerSpawn();

            // Revisar límite
            if (maxSpawns > 0 && totalSpawns >= maxSpawns)
                break;
        }

        if (textoTemporizador != null) textoTemporizador.text = "0.0";
    }

    void HacerSpawn()
    {
        // Genera posición aleatoria dentro del área
        Vector3 pos = centro + new Vector3(
            Random.Range(-tamaño.x / 2, tamaño.x / 2),
            Random.Range(-tamaño.y / 2, tamaño.y / 2),
            Random.Range(-tamaño.z / 2, tamaño.z / 2)
        );

        Instantiate(esferaPrefab, pos, Quaternion.identity);
        totalSpawns++;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el área en el editor
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(centro, tamaño);
    }
}

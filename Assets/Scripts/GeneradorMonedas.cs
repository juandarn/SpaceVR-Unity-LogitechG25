using UnityEngine;

public class GeneradorMonedas : MonoBehaviour
{
    public GameObject monedaPrefab; // Prefab de tu moneda (una esfera aplastada)
    public int cantidadMonedas = 10; // Número de monedas a generar
    public float rangoHorizontal = 20f; // Distancia en X y Z desde la nave
    public float rangoVertical = 2f;    // Distancia en Y (arriba o abajo de la nave)

    private Vector3 posicionNave = new Vector3(-82.69021f, 32.1f, -90.56461f);

    void Start()
    {
        GenerarMonedas();
    }

    void GenerarMonedas()
    {
        for (int i = 0; i < cantidadMonedas; i++)
        {
            // Posición aleatoria alrededor de la nave
            float x = posicionNave.x + Random.Range(-rangoHorizontal, rangoHorizontal);
            float y = posicionNave.y + Random.Range(-rangoVertical, rangoVertical);
            float z = posicionNave.z + Random.Range(-rangoHorizontal, rangoHorizontal);

            Vector3 nuevaPos = new Vector3(x, y, z);

            // Instanciar la moneda
            Instantiate(monedaPrefab, nuevaPos, Quaternion.identity);
        }
    }
}

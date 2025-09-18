using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform puntoDisparo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // dispara con barra espaciadora
        {
            // Instancia como hija de la nave
            GameObject bala = Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation, transform);

            // Pero la "libera" para que no quede pegada al movimiento de la nave
            bala.transform.parent = null;
        }
    }
}

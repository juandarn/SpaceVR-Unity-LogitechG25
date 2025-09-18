using UnityEngine;

public class NaveRuta : MonoBehaviour
{
    public Transform[] waypoints; // lista de puntos a seguir
    public float velocidad = 10f;
    private int indiceActual = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform objetivo = waypoints[indiceActual];
        Vector3 direccion = (objetivo.position - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;

        // Rotar hacia el siguiente waypoint
        transform.rotation = Quaternion.LookRotation(direccion);

        // Si llega cerca del waypoint, pasar al siguiente
        if (Vector3.Distance(transform.position, objetivo.position) < 1f)
        {
            indiceActual = (indiceActual + 1) % waypoints.Length; // vuelve al inicio si quieres loop
        }
    }
}

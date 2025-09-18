using UnityEngine;

public class Target : MonoBehaviour
{
    public int puntos = 10;
    public bool destruirAlImpacto = true;        // destruye el target al recibir bala
    public bool destruirProyectil = false;      // si quieres que la bala se destruya al pasar
    public GameObject efectoImpactoPrefab;      // opcional: efecto al impacto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            // Sumar puntos
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(puntos);

            // Efecto visual
            if (efectoImpactoPrefab != null)
                Instantiate(efectoImpactoPrefab, transform.position, Quaternion.identity);

            // destruir target y/o proyectil según configuración
            if (destruirAlImpacto)
                Destroy(gameObject);

            if (destruirProyectil)
                Destroy(other.gameObject);
        }
    }
}

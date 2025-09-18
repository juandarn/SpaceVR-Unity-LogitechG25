using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f;
    public float danio = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * velocidad; // velocidad corregida
        rb.linearDamping = 0;
        rb.angularDamping = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        VidaNave vida = collision.gameObject.GetComponent<VidaNave>();
        if (vida != null)
        {
            vida.RecibirDanio(danio);
        }

        Destroy(gameObject);
    }
}

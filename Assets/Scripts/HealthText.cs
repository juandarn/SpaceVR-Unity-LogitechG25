using UnityEngine;
using UnityEngine.UI;

public class PickupHealthUI : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    private int currentHealth;

    private Text healthText;

    void Start()
    {
        currentHealth = maxHealth;

        // Buscar el Text de la UI automáticamente
        GameObject textObj = GameObject.Find("New Text");
        if (textObj != null)
            healthText = textObj.GetComponent<Text>();

        UpdateHealthText();

        // Asegurarse de que hay un Rigidbody para detectar triggers
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Para que no se mueva con la física
        }

        // Asegurarse de que el collider sea trigger
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage(50); // Cantidad de vida que quita al pasar
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Desaparece el prefab
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {currentHealth}/{maxHealth}";
        }
    }
}

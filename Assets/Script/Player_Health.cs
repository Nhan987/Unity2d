using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentHealth;
    public int maxHealth;

    // Update is called once per frame
    public void ChangeHealth(int amount)
       {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
   }
}

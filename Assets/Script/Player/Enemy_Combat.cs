using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player_Health>().ChangeHealth(-damage);
    }
}

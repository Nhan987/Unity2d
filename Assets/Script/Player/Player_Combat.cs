using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
  
    // Update is called once per frame
    public void Attack()
    {
        Debug.Log("Da vao ham Attack");
        if (anim == null)
        {
            Debug.LogError("anim trong Player_Combat dang bi NULL!");
            return;
        }
        anim.SetBool("isAttacking", true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    void TakeDamage(int damage);
}
public class Entity : MonoBehaviour, IDamageble
{
    public int Health = 3;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        Health -= damage;
        animator.SetTrigger("Hit");
        Debug.Log(this.ToString() + " has " + Health + " left");
        if(Health <= 0)
        {
            
            Destroy(this.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int MaxHealth = 3;
    public int CurrentHealth;

    public int coinCount = 0;
    public Text coinText;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
    }

    public void Update()
    {
        coinText.text = coinCount.ToString();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if(CurrentHealth <= 0)
        {
            //dead
            //play death animation
            animator.SetBool("isDead", true);
            //game over screen
        }
    }
}

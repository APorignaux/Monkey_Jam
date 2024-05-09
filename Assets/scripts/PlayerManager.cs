using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int MaxHealth = 3;
    public int CurrentHealth = 3;
    public Image Heart0;
    public Image Heart1;
    public Image Heart2;
    public Sprite EmptyHeart;
    public Image GameOverScreen;
    public Personnage player;

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
        if (AsFallen())
        {
            this.TakeDamage(1);
            player.Body.transform.position = new Vector3(player.Body.transform.position.x - 5, 0, 0);
        }
        if (CurrentHealth <= 0)
        {
            GameOverScreen.gameObject.SetActive(true);
            player.Mouvement(false);
        }
        else player.Mouvement(true); ;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log("damage");
        switch (CurrentHealth)
        {
            case 2:
                Heart2.sprite = EmptyHeart;
                break;
            case 1:
                Heart1.sprite = EmptyHeart;
                break;
            case 0:
                Heart0.sprite = EmptyHeart;
                break;
        }

        if(CurrentHealth <= 0)
        {
            //dead
            //play death animation
            animator.SetBool("isDead", true);
            //game over screen
        }
    }

    public bool AsFallen()
    {
        bool state;
        if (player.transform.position.y < -7) state = true;
        else state = false;
        return state;
    }
}

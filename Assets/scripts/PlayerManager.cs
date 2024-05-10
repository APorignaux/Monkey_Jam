using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool Alive;

    public int MaxHealth = 3;
    public int CurrentHealth = 3;
    public Image Heart0;
    public Image Heart1;
    public Image Heart2;
    public Sprite EmptyHeart;
    public Sprite FullFilledHeart;
    public Image GameOverScreen;
    public Text GameOverText;
    public Image WinnigScreen;
    public Personnage player;

    public PauseMenu pauseMenu;

    public int coinCount = 0;
    public Text coinText;

    public AudioManager audioManager;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
        Alive = true;
    }

    public void Update()
    {
        if (Alive)
        {

            coinText.text = coinCount.ToString();
            if (CurrentHealth > 0) player.Mouvement(true);

            if (AsFallen() && CurrentHealth > 0)
            {
                this.TakeDamage(1);
                player.Body.transform.position = new Vector3(player.Body.transform.position.x - 5, 0, 0);
            }

            //if (CurrentHealth <= 0)
            //{
            //    Lose();
            //}

            if (coinCount == 10 && CurrentHealth != MaxHealth)
            {
                CurrentHealth++;
                coinCount = 0;
            }

            switch (CurrentHealth)
            {
                case 2:
                    Heart2.sprite = EmptyHeart;
                    Heart0.sprite = FullFilledHeart;
                    Heart1.sprite = FullFilledHeart;
                    break;
                case 1:
                    Heart2.sprite = EmptyHeart;
                    Heart1.sprite = EmptyHeart;
                    Heart0.sprite = FullFilledHeart;
                    break;
                case 0:
                    audioManager.DeadSound();
                    Heart2.sprite = EmptyHeart;
                    Heart1.sprite = EmptyHeart;
                    Heart0.sprite = EmptyHeart;
                    Alive = false;
                    break;
                case 3:
                    Heart0.sprite = FullFilledHeart;
                    Heart1.sprite = FullFilledHeart;
                    Heart2.sprite = FullFilledHeart;
                    break;
            }
        }
        else Lose();
    }

    public void Lose()
    {
        player.Body.velocity = new Vector2(0,0);
        GameOverScreen.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        //Destroy(player.gameObject);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Win()
    {
        WinnigScreen.gameObject.SetActive(true);
        audioManager.LevelGoalSound();
        Invoke("LoadMainMenu", 5);
    }

    public void CollectCoin(Collider2D collider)
    {
        Destroy(collider.gameObject);
        coinCount++;
        audioManager.CollectACoinSound();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quitgame()
    {
        Application.Quit();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log("damage");
        

        //if(CurrentHealth <= 0)
        //{
        //    //dead
        //    //play death animation
        //    //animator.SetBool("isDead", true);
        //    //game over screen
        //}
    }

    public bool AsFallen()
    {
        bool state;
        if (player.transform.position.y < -7) state = true;
        else state = false;
        return state;
    }
}

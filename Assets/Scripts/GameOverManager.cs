using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public float restartDelay = 5f;

    private Animator animator;

    private float restartTimer;

    public GameObject gameOver;
    
    public GameObject winGame;
    
    public GameObject bed;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bed.active)
        {
            winGame.SetActive(true);

            animator.SetTrigger("WinGame");
        }

        if (playerHealth.currentHealth <= 0)
        {
            gameOver.SetActive(true);

            animator.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
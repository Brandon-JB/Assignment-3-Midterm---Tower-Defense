using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private float timePassed;
    public float timeToWin;

    public float health;
    public float maxHealth;

    public GameObject pauseMenu;
    private bool isPaused;

    public GameObject Health5;
    public GameObject Health4;
    public GameObject Health3;
    public GameObject Health2;

    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        timePassed = 0;
        pauseMenu.SetActive(false);
        Health5.SetActive(true);
        Health4.SetActive(true);
        Health3.SetActive(true);
        Health2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (timePassed >= timeToWin)
        {
            SceneManager.LoadScene("Win");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        timePassed += Time.deltaTime;

        HeartTracker();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            health--;
            AudioSource.Play();
        }
    }

    void HeartTracker()
    {
        if (health == 4)
        {
            Health5.SetActive(false);
        }

        if (health == 3)
        {
            Health4.SetActive(false);
        }

        if (health == 2)
        {
            Health3.SetActive(false);
        }

        if (health == 1)
        {
            Health2.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    [Header("Spawning")]
    public Transform spawn;
    public GameObject shooterTower;
    public GameObject AoETower;
    public bool spotTaken = false;
    public bool isPaused = false;

    [Header("Rebuilding")]
    public AudioSource AudioSource;
    public GameObject towerInstance;
    public float RebuildTimer;
    private float timePassed;

    [Header("Sprite")]
    public SpriteRenderer sr;
    public Sprite square;
    public Sprite shatter;

    private void Start()
    {
        spotTaken = false;
        isPaused = false;
    }

    private void Update()
    {
        if (towerInstance == null)
        {
            timePassed += Time.deltaTime;
            sr.sprite = shatter;

            if (timePassed >= RebuildTimer)
            {
                spotTaken = false;
                sr.sprite = square;
                towerInstance = GameObject.Find("Placeholder");
                timePassed = 0;
            }
        }

        if (Time.timeScale == 0)
        {
            isPaused = true;
        }
        
        if (Time.timeScale == 1)
        {
            isPaused = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && spotTaken == false && isPaused == false)
        {
            towerInstance = Instantiate(shooterTower, spawn.position, spawn.rotation);
            spotTaken = true;
        }

        if (Input.GetMouseButtonDown(1) && spotTaken == false && isPaused == false)
        {
            towerInstance = Instantiate(AoETower, spawn.position, spawn.rotation);
            spotTaken = true;
            
        }

        if (Input.GetKeyDown(KeyCode.D) && spotTaken == true && towerInstance != null && isPaused == false)
        {
            Destroy(towerInstance.gameObject);
            towerInstance = GameObject.Find("Placeholder");
            spotTaken = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject alienPrefab;
    public Sprite[] alienSprites;
    public TextMeshPro timerText;
    public TextMeshPro scoreText;
    private AudioSource audioSource;
    public AudioClip spawnClip;
    public AudioClip deadClip;
    private Vector3 xDirection;
    private Timer timer;
    public int urScore = 0;
    public int enemyScore = 10;




    //private float timeRemaining;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("SpawnAlien", 1.5f, 1.5f);
        timer = GetComponent<Timer>();
        


    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + urScore.ToString("000");
        if (timer.timerIsRunning)
        {
            timerText.text = timer.GetTimeForDisplay();
        }

        
    }
    void SpawnAlien()
    {
        audioSource.PlayOneShot(spawnClip);
        xDirection = new Vector3 (Random.Range(-8f,8f),5.5f,0);
        Instantiate(alienPrefab,xDirection,Quaternion.identity);
        int enemyIndex = Random.Range(0, 5);
        alienPrefab.GetComponent<SpriteRenderer>().sprite = alienSprites[enemyIndex];
        if (enemyIndex == 0)
        {
            alienPrefab.GetComponent<EnemyScript>()._alienSpeed = -1.5f;
            enemyScore = 10;
            
        }
        if (enemyIndex == 1)
        {
            alienPrefab.GetComponent<EnemyScript>()._alienSpeed = -3.5f;
            enemyScore = 30;
            
        }
        if (enemyIndex == 2)
        {
            alienPrefab.GetComponent<EnemyScript>()._alienSpeed = -5.5f;
            enemyScore = 50;
        }
        if (enemyIndex == 3)
        {
            alienPrefab.GetComponent<EnemyScript>()._alienSpeed = -6.5f;
            enemyScore = 80;
        }
        if (enemyIndex == 4)
        {
            alienPrefab.GetComponent<EnemyScript>()._alienSpeed = -8f;
            enemyScore = 100;
        }
        


    }

    public void addScore()
    {
        urScore = urScore + enemyScore;
        audioSource.PlayOneShot(deadClip);
    }

    public void decreaseScore()
    {
        urScore = urScore - enemyScore;
        audioSource.PlayOneShot(deadClip);
    }

}

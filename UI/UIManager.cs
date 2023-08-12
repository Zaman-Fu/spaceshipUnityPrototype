using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Singleton static
   public static UIManager Instance { get; private set; }
    [SerializeField]
    LivesCounter livesCounter;

    [SerializeField]
    ScoreCounter scoreCounter;

    [SerializeField]
    PowerCounter powerCounter;

    [SerializeField]
    GameObject gameOverMenu;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateLives(int lives)
    {
        Instance.livesCounter.SetLives(lives);
    }

    public static void UpdateScore(int points)
    {
        Instance.scoreCounter.SetScore(points);
    }

    public static void UpdatePower(int power)
    {
        Instance.powerCounter.SetPower(power);
    }

    public static void GameOver()
    {
       Instance.StartCoroutine("GameOverCoroutine");
        
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }


}

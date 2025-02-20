using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    UIManager uiManager;
    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private int CurrentScore = 0;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        StartCoroutine(DelayStart());
        uiManager.UpdateScore(0);
    }

    void Update()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetGameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int _Score)
    {
        CurrentScore += _Score;
        uiManager.UpdateScore(CurrentScore);
        Debug.Log("Score: " + CurrentScore);
    }

    private IEnumerator DelayStart()
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(3.0f);

        Time.timeScale = 1;
    }
}

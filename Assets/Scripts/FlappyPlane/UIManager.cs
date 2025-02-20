using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;
    public Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        if (GameOverText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (ScoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        GameOverText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }

    public void UpdateScore(int _Score)
    {
        ScoreText.text = _Score.ToString();
    }
}

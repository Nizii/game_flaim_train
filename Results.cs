using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


    public class Results : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    public void OpenStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void Start()
    {
        score.text = "Hit Score: " + PlayerPrefs.GetInt("HitScore").ToString();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();

        if (PlayerPrefs.GetInt("HitScore") > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HitScore"));
            highScore.text = "new High Score: " + PlayerPrefs.GetInt("HitScore").ToString();
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        score.text = "Hit Score: 0";
    }

}

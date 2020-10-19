using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Highscore");
        scoreText = GetComponent<Text>();
        scoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score += 1;
        PlayerPrefs.SetInt("Highscore", score);
        scoreText.text = score.ToString();
    }
}

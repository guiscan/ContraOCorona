using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    Text scoreText;

    float timer;
    float maxTime;

    public GameObject backgroundSun;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime) {
            score++;
            scoreText.text = score.ToString("Score: 0");
            timer = 0;
        }
        
        if (score%100==0) {
            backgroundSun.SetActive(false);
        } 

        if (score%300==0) {
            backgroundSun.SetActive(true);
        }
    }
}

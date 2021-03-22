using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreDisplay;

    public int score = 0;
    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score :" + " " + score.ToString();
        currentScore = score;

    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score :" + " " + currentScore.ToString();
    }

    public void Add(int ammount)
    {
        currentScore += ammount;
    }
}

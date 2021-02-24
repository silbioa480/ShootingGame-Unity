using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;
    public Text BestScoreUI;
    private int bestScore;
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        BestScoreUI.text = "최고점수 : " + bestScore;
    }

    public static ScoreManager Instance = null;

    void Awake()
    {
        if(Instance == null) Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
        currentScore = value;
        currentScoreUI.text = "현재점수 : " + currentScore;

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            BestScoreUI.text = "최고점수 : " + bestScore;

            PlayerPrefs.SetInt("Best Score", bestScore);
        }
        }
    }

    public int BestScore
    {
        get
        {
            return bestScore;
        }
        set
        {
            
        }
    }
}

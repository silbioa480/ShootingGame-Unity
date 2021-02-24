using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour
{
    public Text resultCurrentScoreUI;
    private int resultCurrentScore;
    public Text resultBestScoreUI;
    private int resultBestScore;
    public Text resultLevelUI;
    private int resultLevel;
    // Start is called before the first frame update
    void Start()
    {
        resultCurrentScore = ScoreManager.Instance.Score;
        resultCurrentScoreUI.text = "현재점수 : " + resultCurrentScore;
        
        resultBestScore = ScoreManager.Instance.BestScore;
        resultBestScoreUI.text = "최고점수 : " + resultBestScore;

        resultLevel = LevelManager.Instance.Level;
        resultLevelUI.text = "Level " + resultLevel;
    }
}

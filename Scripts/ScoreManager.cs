using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance { get; set; }

    public Text ScoreText;
    public Text BestScoreText;

    private int _scoreValue;
    private int _bestScoreValue;

    private void Awake()
    {
        Instance = this;
    }

    private void Start () {
        _scoreValue = 0;
        _bestScoreValue = PlayerPrefs.GetInt("BestScore");

        ScoreText.text = _scoreValue.ToString();
        BestScoreText.text = "Best score: " + _bestScoreValue;
    }

    public void AddScore()
    {
        _scoreValue++;
        ScoreText.text = _scoreValue.ToString();
    }
	
    public void SetBestScore()
    {
        if (_scoreValue > _bestScoreValue)
        {
            _bestScoreValue = _scoreValue;
            PlayerPrefs.SetInt("BestScore", _bestScoreValue);
        }
    }
}

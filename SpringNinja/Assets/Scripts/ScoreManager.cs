using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public float currentScore;
    public bool isBestScore;
    private float totalCoins;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(Constant.ScoreInfo.TOTALCOINS))
        {
           totalCoins = PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALCOINS);
        }
    }
    public void AddScore(int combo)
    {
        if (combo ==1)
        {
            currentScore++;
        }

        else if(combo >1)
        {
            currentScore = currentScore + combo*2;
        }       
        UIManager.Instance.AddScoreUI(currentScore);
        if (currentScore > PlayerPrefs.GetFloat(Constant.ScoreInfo.BESTSCORE))
        {
            PlayerPrefs.SetFloat(Constant.ScoreInfo.BESTSCORE,currentScore);
            isBestScore = true;

        }
    }

    public void AddCoin()
    {
        totalCoins++;
        UIManager.Instance.AddCoinUI(totalCoins);
        AudioManager.Instance.PlayCoinSound();
        PlayerPrefs.SetFloat(Constant.ScoreInfo.TOTALCOINS,totalCoins);
    }
}

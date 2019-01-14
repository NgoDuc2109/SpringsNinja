using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private Text currentScoreTxt;
    [SerializeField]
    private Text lastScoreTxt;
    [SerializeField]
    private Text bestScoreTxt;
    [SerializeField]
    private Text totalCoinTxt;
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameoverPanel;
    [SerializeField]
    private GameObject starBestScore;
    [SerializeField]
    private Animator anim;
    private int temp;
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
            totalCoinTxt.text = PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALCOINS).ToString();
        }
        temp = (int)Random.Range(1, 5.9f);
    }
    public void AddScoreUI(float currentScore)
    {
        currentScoreTxt.text = currentScore.ToString();
        lastScoreTxt.text = currentScore.ToString();
        anim.Play("TextAnim");
    }

    public void AddCoinUI(float totalCoin)
    {
        totalCoinTxt.text = totalCoin.ToString();
    }
    public void OnClickPauseBtn()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        inGamePanel.SetActive(false);
        AudioManager.Instance.PlayButtonClip();
    }

    public void OnClickContinueBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        inGamePanel.SetActive(true);
    }

    public void OnClickHomeBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        SceneManager.LoadScene(Constant.SceneName.STARTSCENE,LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void RandomScene()
    {
        switch (temp)
        {
            case 1:
                SceneManager.LoadScene(Constant.SceneName.MAINSCENE, LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene(Constant.SceneName.VOLCANO, LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene(Constant.SceneName.OCEAN, LoadSceneMode.Single);
                break;
            case 4:
                SceneManager.LoadScene(Constant.SceneName.WINTER, LoadSceneMode.Single);
                break;
            case 5:
                SceneManager.LoadScene(Constant.SceneName.DESERT, LoadSceneMode.Single);
                break;
        }
    }
    public void ShowGameOverUI()
    {
        inGamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
        bestScoreTxt.text = PlayerPrefs.GetFloat(Constant.ScoreInfo.BESTSCORE).ToString();
        if (ScoreManager.Instance.isBestScore == true)
        {
            ScoreManager.Instance.isBestScore = false;
            starBestScore.SetActive(true);

        }
    }

    public void OnClickRePlayBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        RandomScene();
        starBestScore.SetActive(false);
    }
}

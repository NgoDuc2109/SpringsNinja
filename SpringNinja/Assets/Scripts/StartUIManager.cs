using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartUIManager : MonoBehaviour
{
    public static StartUIManager Instance;
    [SerializeField]
    private GameObject topPanel;
    [SerializeField]
    private GameObject bottomPanel;
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private Text totalCoinsTxt;
    [SerializeField]
    private GameObject audioOffBtn;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey(Constant.ScoreInfo.TOTALCOINS))
        {
            totalCoinsTxt.text = PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALCOINS).ToString();
        }
        if (PlayerPrefs.GetInt(Constant.AudioInfo.ISAUDIO) == 1)
        {
            audioOffBtn.SetActive(true);
            AudioManager.Instance.TurnOffAudio();
        }
        else if (PlayerPrefs.GetInt(Constant.AudioInfo.ISAUDIO) == 0)
        {
            audioOffBtn.SetActive(false);
            AudioManager.Instance.TurnOnAudio();
        }
    }
    public void OnClickStartBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        PlayerPrefs.SetInt(Constant.PlayerInfo.CURRENTPLAYER, ShopManager.CurrentPlayer);
        RandomScene();
    }

    private void RandomScene()
    {
        switch (BackgroundManager.temp)
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

    public void OnClickShopBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        topPanel.SetActive(false);
        bottomPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void OnClickAudioOnBtnUI()
    {
        AudioManager.Instance.PlayButtonClip();
        audioOffBtn.SetActive(true);
        AudioManager.Instance.TurnOffAudio();
    }

    public void OnClickAudioOffBtnUI()
    {
        AudioManager.Instance.PlayButtonClip();
        audioOffBtn.SetActive(false);
        AudioManager.Instance.TurnOnAudio();
    }
    public void OnClickBackBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        shopPanel.SetActive(false);
        topPanel.SetActive(true);
        bottomPanel.SetActive(true);
    }
    public void OnClickBuyCharacterUI()
    {
        AudioManager.Instance.PlayButtonClip();
        ShopManager.Instance.BuyCharacter();
    }

    public void OnClickStartUI()
    {
        AudioManager.Instance.PlayButtonClip();
        RandomScene();
    }
}

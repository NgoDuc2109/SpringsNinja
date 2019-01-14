using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;
    [SerializeField]
    private ScrollSnapRect listCharacters;
    [SerializeField]
    private List<float> costOfCharacter;
    [SerializeField]
    private Text costTxt;
    [SerializeField]
    private Text totalCoinTxt;
    [SerializeField]
    private GameObject buyBtn;
    [SerializeField]
    private GameObject PlayBtn;
    [SerializeField]
    private GameObject NotEnoughMoneyPanel;
    [SerializeField]
    private GameObject ShopPanel;
    [SerializeField]
    private GameObject UnlockPanel;
    [SerializeField]
    private List<GameObject> listCharacterImg;

    public static int CurrentPlayer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        PlayerPrefs.SetInt(Constant.PlayerInfo.LISTPLAYER[0], 1);
        SetCostCharater();
        ControlUIShop();
    }
    public void SetCostCharater()
    {
        if (listCharacters._currentPage == 0)
        {
            costTxt.gameObject.SetActive(false);
        }
        else if (listCharacters._currentPage > 0)
        {
            costTxt.gameObject.SetActive(true);
            costTxt.text = costOfCharacter[listCharacters._currentPage].ToString();
        }
    }
    public void OnClickOKBtn()
    {
        AudioManager.Instance.PlayButtonClip();
        NotEnoughMoneyPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }

    public void BuyCharacter()
    {
        if (PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALCOINS) < costOfCharacter[listCharacters._currentPage])
        {
            NotEnoughMoneyPanel.SetActive(true);
            ShopPanel.SetActive(false);
            return;
        }
        else
        {
            float temp = PlayerPrefs.GetFloat(Constant.ScoreInfo.TOTALCOINS) - costOfCharacter[listCharacters._currentPage];
            PlayerPrefs.SetFloat(Constant.ScoreInfo.TOTALCOINS, temp);
            totalCoinTxt.text = temp.ToString();
            costTxt.gameObject.SetActive(false);
            buyBtn.SetActive(false);
            PlayBtn.SetActive(true);
            UnlockPanel.SetActive(true);
            AudioManager.Instance.OnBuySuccess();
            SetActiveCharacterImg();
            listCharacterImg[listCharacters._currentPage -1].SetActive(true);
            PlayerPrefs.SetInt(Constant.PlayerInfo.LISTPLAYER[listCharacters._currentPage], 1);
            CurrentPlayer = listCharacters._currentPage;
        }
    }

    private void SetActiveCharacterImg()
    {
        for (int i = 0; i < listCharacterImg.Count; i++)
        {
            listCharacterImg[i].SetActive(false);
        }
    }
    public void ControlUIShop()
    {
        if (PlayerPrefs.GetInt(Constant.PlayerInfo.LISTPLAYER[listCharacters._currentPage]) == 1)
        {
            costTxt.gameObject.SetActive(false);
            buyBtn.SetActive(false);
            PlayBtn.SetActive(true);
            CurrentPlayer = listCharacters._currentPage;
        }
        else
        {
            costTxt.gameObject.SetActive(true);
            buyBtn.SetActive(true);
            PlayBtn.SetActive(false);
        }
    }
}

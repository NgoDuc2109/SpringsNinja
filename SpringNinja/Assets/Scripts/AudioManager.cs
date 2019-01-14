using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;
    [SerializeField]
    AudioSource backgroundAudio;
    [SerializeField]
    AudioClip jumpClip;
    [SerializeField]
    AudioClip fallClip;
    [SerializeField]
    AudioClip coinClip;
    [SerializeField]
    AudioClip buttonClip;
    [SerializeField]
    AudioClip buySuccessClip;
    private int isAudio;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayJumpSound()
    {
        audioSource.clip = jumpClip;
        audioSource.Play();
    }

    public void PlayCoinSound()
    {
        audioSource.clip = coinClip;
        audioSource.Play();
    }

    public void PlayFallClip()
    {
        audioSource.clip = fallClip;
        audioSource.Play();
    }

    public void PlayButtonClip()
    {
        audioSource.clip = buttonClip;
        audioSource.Play();
    }

    public void TurnOnAudio()
    {
        audioSource.mute = false;
        backgroundAudio.mute = false;
        PlayerPrefs.SetInt(Constant.AudioInfo.ISAUDIO,0);
    }

    public void OnBuySuccess()
    {
        audioSource.PlayOneShot(buySuccessClip);
    }
    public void TurnOffAudio()
    {
        audioSource.mute = true;
        backgroundAudio.mute = true;
        PlayerPrefs.SetInt(Constant.AudioInfo.ISAUDIO, 1);
    }
}

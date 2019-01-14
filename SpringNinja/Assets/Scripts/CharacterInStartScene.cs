using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInStartScene : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> character;
    private void Start()
    {
        SetActiveCharacter();
        character[PlayerPrefs.GetInt(Constant.PlayerInfo.CURRENTPLAYER)].SetActive(true);
    }

    private void SetActiveCharacter()
    {
        for (int i = 0; i < character.Count; i++)
        {
            character[i].SetActive(false);
        }
    }
}

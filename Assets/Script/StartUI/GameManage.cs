using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button gameStartButton;

    private void Start()
    {
        gameStartButton.onClick.AddListener(OnGameStartButtonClicked);
    }

    private void OnGameStartButtonClicked()
    {
        string playername = inputField.text;
        if(string.IsNullOrEmpty(playername))
        {
            Debug.Log("플레이어 이름을 입력하세요");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playername);
        PlayerPrefs.Save();

        Debug.Log("플레이어 이름 저장됨: " + playername);

        SceneManager.LoadScene("Stage_1");
    }

}

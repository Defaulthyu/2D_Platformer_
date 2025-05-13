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
            Debug.Log("�÷��̾� �̸��� �Է��ϼ���");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playername);
        PlayerPrefs.Save();

        Debug.Log("�÷��̾� �̸� �����: " + playername);

        SceneManager.LoadScene("Stage_1");
    }

}

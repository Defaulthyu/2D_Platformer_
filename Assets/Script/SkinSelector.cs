using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinSelector : MonoBehaviour
{
    public SkinDatabase skinDatabase; // 인스펙터 할당
    public Image skinDisplayImage; // 스킨 아이콘을 보여줄 UI 이미지
    public TMP_Text skinNameText;  // 스킨 이름을 보여줄 UI 텍스트

    private int currentSkinIndex = 0;

    private void Start()
    {
        // 이전에 저장된 선택 불러오기
        currentSkinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        UpdateUI();
    }

    public void DefaultSkin()
    {
        currentSkinIndex = 0;

        SaveAndUpdate();
    }

    public void SuitSkin()
    {
        currentSkinIndex = 1;

        SaveAndUpdate();
    }

    private void SaveAndUpdate()
    {
        // 선택한 스킨 인덱스 저장
        PlayerPrefs.SetInt("SelectedSkin", currentSkinIndex);
        PlayerPrefs.Save();
        UpdateUI();
    }

    private void UpdateUI()
    {
        SkinData skin = skinDatabase.GetSkin(currentSkinIndex);
        if (skin != null)
        {
            if(skinDisplayImage != null) skinDisplayImage.sprite = skin.displayIcon;
            if (skinNameText != null) skinNameText.text = skin.skinName;
        }
    }
}
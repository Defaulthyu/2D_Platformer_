using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    public Animator myAnimator;
    public SkinDatabase skinDatabase;

    private void Awake()
    {
        ApplySelectedSkin();
    }

    public void ApplySelectedSkin()
    {
        if (skinDatabase == null)
        {
            Debug.LogWarning("PlayerController에 SkinDatabase가 연결되지 않았습니다! 인스펙터를 확인하세요.");
            return;
        }

        int skinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);

        SkinData selectedSkin = skinDatabase.GetSkin(skinIndex);
        if (selectedSkin != null && selectedSkin.animatorController != null)
        {
            myAnimator.runtimeAnimatorController = selectedSkin.animatorController;
        }
    }
}

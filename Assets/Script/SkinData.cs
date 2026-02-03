using UnityEngine;

[CreateAssetMenu(fileName = "NewSkin", menuName = "Game/Skin Data")]
public class SkinData : ScriptableObject
{
    public string skinName;
    public Sprite displayIcon;
    public RuntimeAnimatorController animatorController;
}
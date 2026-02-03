using UnityEngine;

[CreateAssetMenu(fileName = "SkinDatabase", menuName = "Game/Skin Database")]
public class SkinDatabase : ScriptableObject
{
    public SkinData[] skins; // 인스펙터에서 모든 스킨 데이터를 드래그해서 넣어주세요.

    public int Count => skins.Length;

    public SkinData GetSkin(int index)
    {
        if (index < 0 || index >= skins.Length) return null;
        return skins[index];
    }
}
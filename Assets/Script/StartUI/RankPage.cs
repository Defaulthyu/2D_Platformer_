using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;
    [SerializeField] GameObject rowprefeb;

    StageResultList allData;

    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        //������ ��� �ڽ� ������Ʈ ����
        foreach(Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }
        //��ũ ������ ����
        var sortedData1 = allData.results.Where(r => r.stage == 1).OrderByDescending(x => x.score).ToList();
        var sortedData2 = allData.results.Where(r => r.stage == 2).OrderByDescending(x => x.score).ToList();
        var sortedData3 = allData.results.Where(r => r.stage == 3).OrderByDescending(x => x.score).ToList();
        var sortedData4 = allData.results.Where(r => r.stage == 4).OrderByDescending(x => x.score).ToList();
        var sortedData5 = allData.results.Where(r => r.stage == 5).OrderByDescending(x => x.score).ToList();

        //��ũ ������ ����
        for (int i = 0; i < sortedData1.Count; i++)
        {
            GameObject row = Instantiate(rowprefeb, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"Stage 1 - {i + 1}. {sortedData1[i].playerName} - {sortedData1[i].score}";
        }

        for (int i = 0; i < sortedData2.Count; i++)
        {
            GameObject row = Instantiate(rowprefeb, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"Stage 2 - {i + 1}. {sortedData2[i].playerName} - {sortedData2[i].score}";
        }
        for (int i = 0; i < sortedData3.Count; i++)
        {
            GameObject row = Instantiate(rowprefeb, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"Stage 3 - {i + 1}. {sortedData3[i].playerName} - {sortedData3[i].score}";
        }
        for (int i = 0; i < sortedData4.Count; i++)
        {
            GameObject row = Instantiate(rowprefeb, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"Stage 4 - {i + 1}. {sortedData4[i].playerName} - {sortedData4[i].score}";
        }
        for (int i = 0; i < sortedData5.Count; i++)
        {
            GameObject row = Instantiate(rowprefeb, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"Stage 5 - {i + 1}. {sortedData5[i].playerName} - {sortedData5[i].score}";
        }
    }
}

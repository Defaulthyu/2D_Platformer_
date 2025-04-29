using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public TextMeshProUGUI stage1;
    public TextMeshProUGUI stage2;
    public TextMeshProUGUI stage3;
    public TextMeshProUGUI stage4;
    public TextMeshProUGUI stage5;
    // Start is called before the first frame update
    void Start()
    {
        stage1.text = "Stage 1 :" + ScoreSys.Load(1).ToString();
        stage2.text = "Stage 2 :" + ScoreSys.Load(2).ToString();
        stage3.text = "Stage 3 :" + ScoreSys.Load(3).ToString();
        stage4.text = "Stage 4 :" + ScoreSys.Load(4).ToString();
        stage5.text = "Stage 5 :" + ScoreSys.Load(5).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFunctions : MonoBehaviour
{
    public TMP_Text TimeText, ScoreText, KillText;
    void Start()
    {

    }


    void Update()
    {
        Timetext();
        Score();
        Kills();
    }
    void Timetext() //Tiempo
    {
        TimeText.text = " Time " + Mathf.Round(GameManager.instance.gm_time * 100) * 0.01f;
    }

    void Score() //Puntos
    {
        ScoreText.text = "Score " + GameManager.instance.gm_score;
    }

    void Kills() //Puntos
    {
        KillText.text = "Kills " + GameManager.instance.gm_kills;
    }
}

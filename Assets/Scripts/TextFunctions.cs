using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFunctions : MonoBehaviour
{
    public TMP_Text TimeText, ScoreText;
    void Start()
    {
        
    }


    void Update()
    {
        Timetext();
        Score();

        void Timetext() //Tiempo
        {
            TimeText.text = " Time " + Mathf.Round(GameManager.instance.gm_time * 100) * 0.01f;
        }

        void Score() //Puntos
        {
            ScoreText.text = "Score " + GameManager.instance.gm_score;
        }
    }

}

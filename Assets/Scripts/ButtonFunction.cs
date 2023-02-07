using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    //Cambia de escena
    public void ChangeScene(string kk)
    {
        SceneManager.LoadScene(kk);
    }

    //El boton Exit te saca del jugeo
    public void Exit ()
    {
        Application.Quit();
    }

}

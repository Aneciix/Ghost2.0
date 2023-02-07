using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioClip sound;

    [Range(0, 1)]
    public float soundVolume;

    private int score = 0;
    private float time = 0;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene (string name)
    {
        SceneManager.LoadScene(name);
        AudioManager.instance.ClearAudioList();
    }

    public int gm_score
    {
        get { return score; }
        set { score += value; }
    }

    public float gm_time
    {
        get { return time; }
    }

    private void Update()
    {
        time += Time.deltaTime;
    }
}

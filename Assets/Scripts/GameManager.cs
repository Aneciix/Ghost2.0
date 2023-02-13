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

    public AudioClip MenuSong, LevelSong;
    [Range(0, 1)]
    public float ambientVolume;
    
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

    private void Start() //Se reproduce la canción del menú
    {
        AudioManager.instance.PlayAudioOnLoop(MenuSong, ambientVolume);
    }
    public void ChangeScene (string name) 
    {
        time = 0; // Empieza en 0 cuando cambia de escena
        score = 0;
        SceneManager.LoadScene(name);
        AudioManager.instance.ClearAudioList();
        if(name == "Start")
        {
            AudioManager.instance.PlayAudioOnLoop(MenuSong, ambientVolume);
        }
        else
        {
            AudioManager.instance.PlayAudioOnLoop(LevelSong, ambientVolume);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    AudioSource audioSource;
    public GameObject[] ObstacleWallPrefab;//ステージの障害壁

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//もしエスケープキーを押したら
        {
            Invoke("AppQuit", 1.5f);//1.5秒後にゲーム終了
        }
    }

    public void SoundSE(string name)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Sounds/SE/" + name);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogError("AudioClip not found: " + name);
        }
    }
    //音量設定
    private void SoundSetting()
    {
        //BGM設定
        //SE設定
    }

    //振動オンオフ設定
    private void Vibrationsetting()
    {

    }

    //ゲームシーンに遷移
    public void GameSceneTransition()
    {
        SceneManager.LoadScene("GameScene");
    }

    //チュートリアルシーンに遷移
    public void TutorialSceneTransition()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    //ゲーム終了
    public void AppQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();　
#endif
    }
}

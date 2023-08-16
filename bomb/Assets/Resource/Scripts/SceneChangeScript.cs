using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip LetsStartSE;　//スタートボタンが押された際に鳴らす
    public AudioClip QuitSE;　//Quitボタンが押された際に鳴らす
    private float count = 0.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//もしエスケープキーを押したら
        {
            QuitButtonDown();//ゲーム終了に遷移
        }

        if (Input.GetKeyDown(KeyCode.Return)) //もしエンターキーを押したら
        {
            StartButtonDown();//ゲームシーンに遷移
        }

        //10秒後にチュートリアルシーンに遷移
        count += Time.deltaTime;
        if (count > 10.0f)
        {
            TutorialStart();
        }
    }

    //1.5秒後にゲームシーンに遷移
    public void StartButtonDown()
    {
        audioSource.PlayOneShot(LetsStartSE);
        Invoke("GameStart", 1.5f);
    }

    //1.5秒後にゲーム終了
    public void QuitButtonDown()
    {
        audioSource.PlayOneShot(QuitSE);
        Invoke("AppQuit", 1.5f);
    }

    //ゲームシーンに遷移
    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    //チュートリアルシーンに遷移
    private void TutorialStart()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip LetsStartSE;
    public AudioClip QuitSE;
    private float count = 0.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//もしエスケープキーを押したら
        {
            QuitButtonDown();
        }

        if (Input.GetKeyDown(KeyCode.Return)) //もしエンターキーを押したら
        {
            StartButtonDown();
        }

        //10秒後にチュートリアルシーンに遷移
        count += Time.deltaTime;
        if (count > 10.0f)
        {
            TutorialStart();
        }
    }

    public void StartButtonDown()
    {
        audioSource.PlayOneShot(LetsStartSE);
        Invoke("GameStart", 1.5f);
    }
    public void QuitButtonDown()
    {
        audioSource.PlayOneShot(QuitSE);
        Invoke("AppQuit", 1.5f);
    }

    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
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

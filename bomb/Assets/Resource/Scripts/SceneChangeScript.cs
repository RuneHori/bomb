using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//もしエスケープキーを押したら
        {
            AppQuit();
        }

        if (Input.GetKeyDown(KeyCode.Return)) //もしエンターキーを押したら
        {
            StartButtonDown();
        }

    }
    public void StartButtonDown()
    {
        Invoke("GameStart", 1.0f);
    }
    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
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

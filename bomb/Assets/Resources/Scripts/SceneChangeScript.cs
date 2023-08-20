using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    GameManager gameManager;
    
    private float count = 0.0f;

    private void Start()
    {
        gameManager = GameManager.instance;
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
            gameManager.TutorialSceneTransition();
        }
    }

    //1.5秒後にゲームシーンに遷移
    public void StartButtonDown()
    {
        gameManager.SoundSE("StartSE");
        gameManager.Invoke("GameSceneTransition", 1.5f);
    }

    //1.5秒後にゲーム終了
    public void QuitButtonDown()
    {
        gameManager.SoundSE("QuitSE");
        gameManager.Invoke("AppQuit", 1.5f);
    }
}

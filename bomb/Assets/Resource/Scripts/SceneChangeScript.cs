using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//�����G�X�P�[�v�L�[����������
        {
            AppQuit();
        }

        if (Input.GetKeyDown(KeyCode.Return)) //�����G���^�[�L�[����������
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

    //�Q�[���I��
    public void AppQuit() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();�@
#endif
    }
}

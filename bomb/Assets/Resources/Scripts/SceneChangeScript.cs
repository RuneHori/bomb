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
        if (Input.GetKeyDown(KeyCode.Escape))//�����G�X�P�[�v�L�[����������
        {
            QuitButtonDown();//�Q�[���I���ɑJ��
        }

        if (Input.GetKeyDown(KeyCode.Return)) //�����G���^�[�L�[����������
        {
            StartButtonDown();//�Q�[���V�[���ɑJ��
        }

        //10�b��Ƀ`���[�g���A���V�[���ɑJ��
        count += Time.deltaTime;
        if (count > 10.0f)
        {
            gameManager.TutorialSceneTransition();
        }
    }

    //1.5�b��ɃQ�[���V�[���ɑJ��
    public void StartButtonDown()
    {
        gameManager.SoundSE("StartSE");
        gameManager.Invoke("GameSceneTransition", 1.5f);
    }

    //1.5�b��ɃQ�[���I��
    public void QuitButtonDown()
    {
        gameManager.SoundSE("QuitSE");
        gameManager.Invoke("AppQuit", 1.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip LetsStartSE;�@//�X�^�[�g�{�^���������ꂽ�ۂɖ炷
    public AudioClip QuitSE;�@//Quit�{�^���������ꂽ�ۂɖ炷
    private float count = 0.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            TutorialStart();
        }
    }

    //1.5�b��ɃQ�[���V�[���ɑJ��
    public void StartButtonDown()
    {
        audioSource.PlayOneShot(LetsStartSE);
        Invoke("GameStart", 1.5f);
    }

    //1.5�b��ɃQ�[���I��
    public void QuitButtonDown()
    {
        audioSource.PlayOneShot(QuitSE);
        Invoke("AppQuit", 1.5f);
    }

    //�Q�[���V�[���ɑJ��
    private void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    //�`���[�g���A���V�[���ɑJ��
    private void TutorialStart()
    {
        SceneManager.LoadScene("TutorialScene");
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

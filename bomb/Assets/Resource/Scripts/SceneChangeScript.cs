using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip LetsStartSE;
    public AudioClip QuitSE;
   
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//�����G�X�P�[�v�L�[����������
        {
            QuitButtonDown();
        }

        if (Input.GetKeyDown(KeyCode.Return)) //�����G���^�[�L�[����������
        {
            StartButtonDown();
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

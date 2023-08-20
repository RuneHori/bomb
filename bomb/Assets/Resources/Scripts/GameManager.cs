using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    AudioSource audioSource;
    public GameObject[] ObstacleWallPrefab;//�X�e�[�W�̏�Q��

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
        if (Input.GetKeyDown(KeyCode.Escape))//�����G�X�P�[�v�L�[����������
        {
            Invoke("AppQuit", 1.5f);//1.5�b��ɃQ�[���I��
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
    //���ʐݒ�
    private void SoundSetting()
    {
        //BGM�ݒ�
        //SE�ݒ�
    }

    //�U���I���I�t�ݒ�
    private void Vibrationsetting()
    {

    }

    //�Q�[���V�[���ɑJ��
    public void GameSceneTransition()
    {
        SceneManager.LoadScene("GameScene");
    }

    //�`���[�g���A���V�[���ɑJ��
    public void TutorialSceneTransition()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameSceneScript : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;

    public Transform parent; //�����ꏊ�w��
    public GameObject wall;//��Q�ǃ����_���i�[�ϐ�

    //�p�l��
    //�|�[�Y�{�^�����������ۂɔ�������p�l��
    [SerializeField] private GameObject pausePanel;
    //�ݒ�{�^�����������ۂɔ�������p�l��
    [SerializeField] private GameObject settingPanel;


    //�{�^��
    //�Q�[���ꎞ��~�{�^��
    [SerializeField] private Button pauseButton;
    //�Q�[���ĊJ����{�^��
    [SerializeField] private Button resumeButton;
    //�Q�[���I���{�^��
    [SerializeField] private Button quitButton;
    //�ݒ�{�^��
    [SerializeField] private Button settingButton;
    //�ݒ聨���ʒ��߃{�^��
    [SerializeField] private Button soundButton;
    //�ݒ聨�U�����߃{�^��
    [SerializeField] private Button vibrationButton;
    //�`���[�g���A���\���{�^��
    [SerializeField] private Button tutorialButton;


    private void Start()
    {
        //�����_���ɃX�e�[�W�̕Ǎ쐬
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //�p�l��
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        //�{�^��
        pauseButton.gameObject.SetActive(true);

        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        vibrationButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        //�ꎞ��~
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }

        //�Q�[���ĊJ
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
    }

    public void PauseGame()//�ꎞ��~
    {
        Time.timeScale = 0f;

        pauseButton.gameObject.SetActive(false);
        pausePanel.SetActive(true);

        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);
    }

    public void ResumeGame()//�Q�[���ĊJ
    {
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);

        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()//�Q�[���I��
    {
        gameManager.AppQuit();
    }


    public void GameSetting()
    {
        //�p�l��
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);

        //�{�^��
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        vibrationButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    public void Tutorial()
    {

    }
}

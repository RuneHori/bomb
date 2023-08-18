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
    //�`���[�g���A���i�A�C�e���������j�{�^�����������ۂɔ�������p�l��
    [SerializeField] private GameObject tutorialPanel;
    //���ʒ����iSound�j�{�^�����������ۂɔ�������p�l��
    [SerializeField] private GameObject soundPanel;


    //�{�^��
    //�Q�[�����ꎞ��~����{�^��
    [SerializeField] private Button pauseButton;
    //�Q�[�����ĊJ����{�^��
    [SerializeField] private Button resumeButton;
    //�Q�[���I���{�^��
    [SerializeField] private Button quitButton;
    //�ݒ�{�^��
    [SerializeField] private Button settingButton;
    //�ݒ聨���ʒ��߃{�^��
    [SerializeField] private Button soundButton;
    //�ݒ聨�U�����߃{�^��
    [SerializeField] private Button vibrationButton;
    //�`���[�g���A���i�A�C�e���������j�\���{�^��
    [SerializeField] private Button tutorialButton;
    //Pause��ʂɖ߂�{�^��
    [SerializeField] private Button backButton;


    private void Start()
    {
        //�����_���ɃX�e�[�W�̕Ǎ쐬
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //�p�l���i���ׂĔ�\���j
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        soundPanel.SetActive(false);

        //�{�^��
        //TRUE�i�\���j
        pauseButton.gameObject.SetActive(false);
        Invoke("ShowButtonWithDelay", 3.0f);//�Q�[���X�^�[�g����R�b���Pause�{�^����\��

        //FALSE�i��\���j
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        vibrationButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        //�ꎞ��~
        if (pauseButton.gameObject.activeSelf && Input.GetKey(KeyCode.Q))
        {
            PauseButtonDown();
        }

        //�Q�[���ĊJ
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeButtonDown();
        }
    }
    
    private void ShowButtonWithDelay()
    {
        pauseButton.gameObject.SetActive(true);
    }
    public void PauseButtonDown()//�ꎞ��~
    {
       // if (canPlayPause == true)
        {
            Time.timeScale = 0f;

            pauseButton.gameObject.SetActive(false);
            pausePanel.SetActive(true);

            resumeButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            settingButton.gameObject.SetActive(true);
            tutorialButton.gameObject.SetActive(true);
        }
    }

    public void ResumeButtonDown()//�Q�[���ĊJ
    {
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);

        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButtonDown()//�Q�[���I��
    {
        gameManager.AppQuit();
    }


    public void SettingButtonDown()
    {
        //�p�l��
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);

        //�{�^��
        // pauseButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        vibrationButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);

        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        // vibrationButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    public void TutorialButtonDown()
    {

    }

    public void BackButtonDown()
    {
        pausePanel.SetActive(true);
        settingPanel.SetActive(false);

        backButton.gameObject.SetActive(false);
        vibrationButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);

        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);
    }

    public void SoundButtonDown()
    {

    }

    public void VibrationButtonDown()
    {

    }
}

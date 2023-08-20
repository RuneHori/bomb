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
        //�Q�[���X�^�[�g�J�E���g�_�E��SE
        gameManager.SoundSE("CountDownSE");
        //�����_���ɃX�e�[�W�̕Ǎ쐬
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //�p�l���i���ׂĔ�\���j
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        tutorialPanel.SetActive(false);

        //�{�^��
        //TRUE�i�\���j
        pauseButton.gameObject.SetActive(false);//�ŏ��i�J�E���g�_�E�����I���܂Łj�|�[�Y�{�^����\��
        Invoke("ShowButtonWithDelay", 3.0f);//�Q�[���X�^�[�g����R�b��Ƀ|�[�Y�{�^����\������֐��Ɉڍs

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
        //�|�[�Y�{�^�����\������Ă���@���@Q�L�[�������ꂽ�ꍇ
        if (pauseButton.gameObject.activeSelf && Input.GetKey(KeyCode.Q))
        {
            PauseButtonDown();
        }

        //�Q�[���ĊJ
        //�Q�[���ĊJ�{�^�����\������Ă���@���@R�L�[�������ꂽ�ꍇ
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeButtonDown();
        }
    }

    private void ShowButtonWithDelay()//�R�b��Pause��ʏo��
    {
        pauseButton.gameObject.SetActive(true);
    }

    public void PauseButtonDown()//�ꎞ��~
    {
        gameManager.SoundSE("ButtonDownSE");//���ʉ�

        //�ꎞ��~
        Time.timeScale = 0f;

        //�|�[�Y�ɂ���
        pauseButton.gameObject.SetActive(false);
        pausePanel.SetActive(true);

        //�{�^���Etrue�i�\���j
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);

    }

    public void ResumeButtonDown()//�Q�[���ĊJ
    {
        gameManager.SoundSE("ButtonDownSE"); //���ʉ�

        //�|�[�Y�ɂ���
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);

        //�{�^���Efalse�i��\���j
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);

        //�ꎞ��~����
        Time.timeScale = 1f;
    }

    public void QuitButtonDown()//�Q�[���I��
    {
        gameManager.SoundSE("QuitSE");//���ʉ�

        Time.timeScale = 1f;//�ꎞ��~����

        gameManager.Invoke("AppQuit", 1.0f);//1.0�b��ɃQ�[���I���֐��iAppQuit�j�Ɉڍs
    }


    public void SettingButtonDown()//�ݒ�{�^������������
    {
        gameManager.SoundSE("ButtonDownSE"); //���ʉ�

        //�p�l���ɂ���
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);

        //�{�^��
        //true�i�\���j
        backButton.gameObject.SetActive(true);
        vibrationButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);

        //false�i��\���j
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    public void TutorialButtonDown()//�`���[�g���A���{�^������������
    {
        gameManager.SoundSE("ButtonDownSE"); //���ʉ�

        //�p�l���ɂ���
        tutorialPanel.SetActive(true);
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);

        //�{�^��
        //true�i�\���j
        backButton.gameObject.SetActive(true);

        //false�i��\���j
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    public void BackButtonDown()//���ǂ�{�^������������
    {
        gameManager.SoundSE("ButtonDownSE"); //���ʉ�

        //�p�l���ɂ���
        pausePanel.SetActive(true);
        settingPanel.SetActive(false);
        tutorialPanel.SetActive(false);

        //�{�^��
        //true�i�\���j
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);

        //false�i��\���j
        backButton.gameObject.SetActive(false);
        vibrationButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
    }

    public void SoundButtonDown()//�T�E���h�{�^������������
    {

    }

    public void VibrationButtonDown()//�U���ݒ�{�^������������
    {

    }
}

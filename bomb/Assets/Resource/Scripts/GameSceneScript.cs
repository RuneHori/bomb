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


    //�{�^��
    //�Q�[���ꎞ��~�{�^��
    [SerializeField] private Button pauseButton;
    //�Q�[���ĊJ����{�^��
    [SerializeField] private Button resumeButton;
    //�Q�[���I���{�^��
    [SerializeField] private Button quitButton;
    //���ʒ����{�^��
    [SerializeField] private Button soundButton;
    //�`���[�g���A���\���{�^��
    [SerializeField] private Button tutorialButton;


    private void Start()
    {
        //�����_���ɃX�e�[�W�̕Ǎ쐬
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //�{�^��
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
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
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);
    }

    public void ResumeGame()//�Q�[���ĊJ
    {
        resumeButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {

    }


    public void SoundGame()
    {

    }

    public void TutorialGame()
    {

    }
}

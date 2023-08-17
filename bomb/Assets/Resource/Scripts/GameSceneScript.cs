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


    //�|�[�Y�����ۂɕ\������Prefab
    [SerializeField] private Button resumeButton;


    private void Start()
    {
        //�����_���ɃX�e�[�W�̕Ǎ쐬
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //�{�^��
        resumeButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        //�ꎞ��~
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
    }

    public void PauseGame()//�ꎞ��~
    {
        Time.timeScale = 0f;
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGame()//�Q�[���ĊJ
    {
        resumeButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

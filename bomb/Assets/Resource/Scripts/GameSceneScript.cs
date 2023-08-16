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
    [SerializeField] private GameObject resumeButton;

    private void Start()
    {
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);
        resumeButton.SetActive(false);
    }
    private void Update()
    {
        //�ꎞ��~
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }
        if (resumeButton == true && Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
    }

    public void PauseGame()//�ꎞ��~
    {
        Time.timeScale = 0f;
        resumeButton.SetActive(true);
    }

    public void ResumeGame()//�Q�[���ĊJ
    {
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;
   
    public Transform parent; //�����ꏊ�w��
    public GameObject wall;//��Q�ǃ����_���i�[�ϐ�

    private void Start()
    {
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);
    }
    private void Update()
    {
        //�ꎞ��~
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

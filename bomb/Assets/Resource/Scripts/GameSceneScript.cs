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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameSceneScript : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;

    public Transform parent; //生成場所指定
    public GameObject wall;//障害壁ランダム格納変数


    //ポーズした際に表示するPrefab
    [SerializeField] private Button resumeButton;


    private void Start()
    {
        //ランダムにステージの壁作成
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //ボタン
        resumeButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        //一時停止
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
    }

    public void PauseGame()//一時停止
    {
        Time.timeScale = 0f;
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGame()//ゲーム再開
    {
        resumeButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

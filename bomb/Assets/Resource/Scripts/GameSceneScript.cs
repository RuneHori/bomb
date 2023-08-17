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

    //パネル
    //ポーズボタンを押した際に発現するパネル
    [SerializeField] private GameObject pausePanel;
    //設定ボタンを押した際に発現するパネル
    [SerializeField] private GameObject settingPanel;


    //ボタン
    //ゲーム一時停止ボタン
    [SerializeField] private Button pauseButton;
    //ゲーム再開するボタン
    [SerializeField] private Button resumeButton;
    //ゲーム終了ボタン
    [SerializeField] private Button quitButton;
    //設定ボタン
    [SerializeField] private Button settingButton;
    //設定→音量調節ボタン
    [SerializeField] private Button soundButton;
    //設定→振動調節ボタン
    [SerializeField] private Button vibrationButton;
    //チュートリアル表示ボタン
    [SerializeField] private Button tutorialButton;


    private void Start()
    {
        //ランダムにステージの壁作成
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //パネル
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        //ボタン
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
        //一時停止
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }

        //ゲーム再開
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
    }

    public void PauseGame()//一時停止
    {
        Time.timeScale = 0f;

        pauseButton.gameObject.SetActive(false);
        pausePanel.SetActive(true);

        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);
    }

    public void ResumeGame()//ゲーム再開
    {
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);

        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()//ゲーム終了
    {
        gameManager.AppQuit();
    }


    public void GameSetting()
    {
        //パネル
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);

        //ボタン
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

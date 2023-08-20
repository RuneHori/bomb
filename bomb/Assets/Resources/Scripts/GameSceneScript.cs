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
    //チュートリアル（アイテム等説明）ボタンを押した際に発現するパネル
    [SerializeField] private GameObject tutorialPanel;
    //音量調整（Sound）ボタンを押した際に発現するパネル
    [SerializeField] private GameObject soundPanel;


    //ボタン
    //ゲームを一時停止するボタン
    [SerializeField] private Button pauseButton;
    //ゲームを再開するボタン
    [SerializeField] private Button resumeButton;
    //ゲーム終了ボタン
    [SerializeField] private Button quitButton;
    //設定ボタン
    [SerializeField] private Button settingButton;
    //設定→音量調節ボタン
    [SerializeField] private Button soundButton;
    //設定→振動調節ボタン
    [SerializeField] private Button vibrationButton;
    //チュートリアル（アイテム等説明）表示ボタン
    [SerializeField] private Button tutorialButton;
    //Pause画面に戻るボタン
    [SerializeField] private Button backButton;


    private void Start()
    {
        //ランダムにステージの壁作成
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //パネル（すべて非表示）
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        soundPanel.SetActive(false);

        //ボタン
        //TRUE（表示）
        pauseButton.gameObject.SetActive(false);
        Invoke("ShowButtonWithDelay", 3.0f);//ゲームスタートから３秒後にPauseボタンを表示

        //FALSE（非表示）
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
        //一時停止
        if (pauseButton.gameObject.activeSelf && Input.GetKey(KeyCode.Q))
        {
            PauseButtonDown();
        }

        //ゲーム再開
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeButtonDown();
        }
    }
    
    private void ShowButtonWithDelay()
    {
        pauseButton.gameObject.SetActive(true);
    }
    public void PauseButtonDown()//一時停止
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

    public void ResumeButtonDown()//ゲーム再開
    {
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);

        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButtonDown()//ゲーム終了
    {
        gameManager.AppQuit();
    }


    public void SettingButtonDown()
    {
        //パネル
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);

        //ボタン
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

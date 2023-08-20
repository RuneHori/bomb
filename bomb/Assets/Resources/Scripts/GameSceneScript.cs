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
        //ゲームスタートカウントダウンSE
        gameManager.SoundSE("CountDownSE");
        //ランダムにステージの壁作成
        int random = UnityEngine.Random.Range(0, 3);
        wall = gameManager.ObstacleWallPrefab[random];
        Instantiate(wall, parent);

        //パネル（すべて非表示）
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
        tutorialPanel.SetActive(false);

        //ボタン
        //TRUE（表示）
        pauseButton.gameObject.SetActive(false);//最初（カウントダウンが終わるまで）ポーズボタン非表示
        Invoke("ShowButtonWithDelay", 3.0f);//ゲームスタートから３秒後にポーズボタンを表示する関数に移行

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
        //ポーズボタンが表示されている　かつ　Qキーが押された場合
        if (pauseButton.gameObject.activeSelf && Input.GetKey(KeyCode.Q))
        {
            PauseButtonDown();
        }

        //ゲーム再開
        //ゲーム再開ボタンが表示されている　かつ　Rキーが押された場合
        if (resumeButton.gameObject.activeSelf && Input.GetKey(KeyCode.R))
        {
            ResumeButtonDown();
        }
    }

    private void ShowButtonWithDelay()//３秒後Pause画面出現
    {
        pauseButton.gameObject.SetActive(true);
    }

    public void PauseButtonDown()//一時停止
    {
        gameManager.SoundSE("ButtonDownSE");//効果音

        //一時停止
        Time.timeScale = 0f;

        //ポーズについて
        pauseButton.gameObject.SetActive(false);
        pausePanel.SetActive(true);

        //ボタン・true（表示）
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);

    }

    public void ResumeButtonDown()//ゲーム再開
    {
        gameManager.SoundSE("ButtonDownSE"); //効果音

        //ポーズについて
        pauseButton.gameObject.SetActive(true);
        pausePanel.SetActive(false);

        //ボタン・false（非表示）
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);

        //一時停止解除
        Time.timeScale = 1f;
    }

    public void QuitButtonDown()//ゲーム終了
    {
        gameManager.SoundSE("QuitSE");//効果音

        Time.timeScale = 1f;//一時停止解除

        gameManager.Invoke("AppQuit", 1.0f);//1.0秒後にゲーム終了関数（AppQuit）に移行
    }


    public void SettingButtonDown()//設定ボタンを押した際
    {
        gameManager.SoundSE("ButtonDownSE"); //効果音

        //パネルについて
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);

        //ボタン
        //true（表示）
        backButton.gameObject.SetActive(true);
        vibrationButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);

        //false（非表示）
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    public void TutorialButtonDown()//チュートリアルボタンを押した際
    {
        gameManager.SoundSE("ButtonDownSE"); //効果音

        //パネルについて
        tutorialPanel.SetActive(true);
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);

        //ボタン
        //true（表示）
        backButton.gameObject.SetActive(true);

        //false（非表示）
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        tutorialButton.gameObject.SetActive(false);
    }

    public void BackButtonDown()//もどるボタンを押した際
    {
        gameManager.SoundSE("ButtonDownSE"); //効果音

        //パネルについて
        pausePanel.SetActive(true);
        settingPanel.SetActive(false);
        tutorialPanel.SetActive(false);

        //ボタン
        //true（表示）
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        tutorialButton.gameObject.SetActive(true);

        //false（非表示）
        backButton.gameObject.SetActive(false);
        vibrationButton.gameObject.SetActive(false);
        soundButton.gameObject.SetActive(false);
    }

    public void SoundButtonDown()//サウンドボタンを押した際
    {

    }

    public void VibrationButtonDown()//振動設定ボタンを押した際
    {

    }
}

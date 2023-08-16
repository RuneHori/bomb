using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameSceneScript : MonoBehaviour
{
    GameManager gameManager = GameManager.instance;

    public Transform parent; //¶¬êŠw’è
    public GameObject wall;//áŠQ•Çƒ‰ƒ“ƒ_ƒ€Ši”[•Ï”

    //ƒ|[ƒY‚µ‚½Û‚É•\¦‚·‚éPrefab
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
        //ˆê’â~
        if (Input.GetKey(KeyCode.Q))
        {
            PauseGame();
        }
        if (resumeButton == true && Input.GetKey(KeyCode.R))
        {
            ResumeGame();
        }
    }

    public void PauseGame()//ˆê’â~
    {
        Time.timeScale = 0f;
        resumeButton.SetActive(true);
    }

    public void ResumeGame()//ƒQ[ƒ€ÄŠJ
    {
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }
}

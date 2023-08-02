using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool canPlayGame = false;
    private Transform playerTransform;
    public float movementSpeed = 5.0f; // 移動速度
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        Invoke("GameStart", .0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayGame == true)
        { // WASDキーと→キーの入力を取得
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // 入力に基づいて移動ベクトルを作成
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;

            // 現在位置に移動ベクトルを加算して移動させる
            playerTransform.Translate(movement);
        }
    }

    private void GameStart()
    {
        canPlayGame = true;
    }
}

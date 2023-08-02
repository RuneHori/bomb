using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool canPlayGame = false;
    private Transform playerTransform;
    public float movementSpeed = 5.0f; // �ړ����x
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        Invoke("GameStart", .0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayGame == true)
        { // WASD�L�[�Ɓ��L�[�̓��͂��擾
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // ���͂Ɋ�Â��Ĉړ��x�N�g�����쐬
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;

            // ���݈ʒu�Ɉړ��x�N�g�������Z���Ĉړ�������
            playerTransform.Translate(movement);
        }
    }

    private void GameStart()
    {
        canPlayGame = true;
    }
}

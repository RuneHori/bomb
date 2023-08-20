using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool canPlayGame = false;
    private Transform playerTransform;
    public float movementSpeed = 15.0f; // �ړ����x
    private int bombCount = 0;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        Invoke("StartGame", 3.0f);
    }

    void Update()
    {

        if (canPlayGame == true)
        {
            //�ړ�
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) MovePlayer(0.0f);
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) MovePlayer(180f);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) MovePlayer(-90f);
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) MovePlayer(90f);
            
            //�{������
            if(Input.GetKey(KeyCode.Z))
            {
                bombCount++;
                if(bombCount>2)
                {

                }
            }
        }
    }

    private void StartGame()
    {
        canPlayGame = true;//�s���i�ړ��j�\
    }

    private void MovePlayer(float direction)
    {
        playerTransform.localPosition += transform.forward * movementSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0.0f, direction, 0.0f);
    }

   
    
}

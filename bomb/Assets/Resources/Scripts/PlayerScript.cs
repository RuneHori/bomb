using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private bool canPlayGame = false;
    private bool isEffectActive = false;
    private Transform playerTransform;
    public float movementSpeed = 15.0f; // �ړ����x
    private float originalSpeed; // ������ʂ�K�p����O�̑��x
    //private int bombCount = 0;
    BombScript bombScript;

    public GameObject speedEffectPrefab; // speedUP���ʂ̃v���n�u

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        bombScript = FindObjectOfType<BombScript>();
        if (bombScript == null)
        {
            Debug.LogError("BombScript not found!");
        }
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
            if (bombScript != null && Input.GetKeyDown(KeyCode.Z))
            {
                //if (bombCount <= 1)
                {
                    bombScript.CreateBomb(playerTransform);
                    // bombCount++;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!isEffectActive && collision.gameObject.tag == "Speed")
        {
            GameObject effect = Instantiate(speedEffectPrefab, transform.position, Quaternion.identity);
            originalSpeed = movementSpeed; // ������ʂ�K�p����O�̑��x��ۑ�
            movementSpeed += 10.0f;

            isEffectActive = true;

            //10�b���Effect�������A���x��߂�
            Destroy(effect, 10.0f);
            Invoke("ResetSpeed", 10.0f);
        }
    }

    //������ʂ��؂ꂽ�ۂɑ��x�����ɖ߂�
    private void ResetSpeed()
    {
        movementSpeed = originalSpeed;
    }
}

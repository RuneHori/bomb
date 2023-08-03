using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool canPlayGame = false;
    private Transform playerTransform;
    public float movementSpeed = 15.0f; // ˆÚ“®‘¬“x

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        Invoke("GameStart", .0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayGame == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                playerTransform.localPosition += transform.forward * movementSpeed*Time.deltaTime;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                playerTransform.localPosition += transform.forward * movementSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                playerTransform.localPosition += transform.forward * movementSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, -90, 0);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                playerTransform.localPosition += transform.forward * movementSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }
    }

    private void GameStart()
    {
        canPlayGame = true;
    }
}

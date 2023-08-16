using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] ObstacleWallPrefab;//�X�e�[�W�̏�Q��

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//�����G�X�P�[�v�L�[����������
        {
            Invoke("AppQuit", 1.5f);//1.5�b��ɃQ�[���I��
        }
    }


    //�Q�[���I��
    public void AppQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();�@
#endif
    }
}

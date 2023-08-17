using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneScript : MonoBehaviour
{
    private void Update()
    {
        //何かしらのキーが押された場合　かつ　左右中マウスボタンクリックじゃない場合
        if(Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}

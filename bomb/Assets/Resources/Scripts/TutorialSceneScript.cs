using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneScript : MonoBehaviour
{
    private void Update()
    {
        //��������̃L�[�������ꂽ�ꍇ�@���@���E���}�E�X�{�^���N���b�N����Ȃ��ꍇ
        if(Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}

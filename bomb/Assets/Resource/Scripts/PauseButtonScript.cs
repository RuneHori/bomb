using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseButtonScript : MonoBehaviour
{
    public UnityAction buttonAction; //UnityAction��p�ӂ���

    private void Start()
    {
        Button button = GetComponent<Button>(); //button�R���|�[�l���g���擾
        button.onClick.AddListener(buttonAction);�@//UnityAction��o�^
    }
}

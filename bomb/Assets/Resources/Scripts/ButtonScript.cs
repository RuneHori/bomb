using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public UnityAction buttonAction;

    // Start is called before the first frame update
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(buttonAction);
    }
}

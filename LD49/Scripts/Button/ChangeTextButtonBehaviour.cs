using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextButtonBehaviour : MonoBehaviour
{
    [SerializeField] StartMenuManager startMenuManager;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(changeText);
    }

    private void changeText()
    {
        startMenuManager.changeDisplayedText();
    }
}

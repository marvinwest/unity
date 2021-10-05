using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButtonBehaviour : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}

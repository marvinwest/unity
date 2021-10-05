using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishedGameButtonBehaviour : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("WonEnd");
    }
}

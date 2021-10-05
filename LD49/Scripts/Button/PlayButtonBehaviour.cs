using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonBehaviour : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameLoop");
    }

}

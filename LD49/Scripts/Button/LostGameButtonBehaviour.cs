using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostGameButtonBehaviour : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LostGame);
    }

    private void LostGame()
    {
        SceneManager.LoadScene("LostEnd");
    }
}

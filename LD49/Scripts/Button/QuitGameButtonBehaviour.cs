using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGameButtonBehaviour : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitGameLoop);
    }

    private void QuitGameLoop()
    {
        SceneManager.LoadScene("QuitEnd");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToMenu);
    }

    private void ToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

}

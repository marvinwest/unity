using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    private static string introductionText = "Dear Traveller\n" +
        "\n" +
        "Our Timeline is out of control.\n" +
        "The Past has been changed.\n" +
        "The Present is declining.\n" +
        "The Future is uncertain.\n" +
        "\n" +
        "Step into the consciousness of historical persons.\n" +
        "Persuade them to follow their fate to stabilize our timeline.\n" +
        "\n" +
        "The stability of our future is shown in the upper area of the screen.\n" +
        "If the stability runs out, we are lost in time.";

    private static string disclaimerText = "This Game was made for the purpose of fun and entertainment.\n" +
        "Non of the Dialogues displayed in this Game have actually happened.\n" +
        "Any political views you may recognize in the context of this Game are not necessarily the political views of its creator.\n" +
        "This Game ist not meant to offend any person or group.\n" +
        "\n" +
        "Say no to racism.\n" +
        "Say no to fascism.\n" +
        "Say no to sexism.\n";

    [SerializeField] private Text displayedText;
    [SerializeField] private Button changeTextButton;
    private bool introductionShown;

    void Start()
    {
        displayedText.text = introductionText;
        changeTextButton.GetComponentInChildren<Text>().text = "Disclaimer";
        introductionShown = true;
    }

    public void changeDisplayedText()
    {
        if (introductionShown)
        {
            displayedText.text = disclaimerText;
            changeTextButton.GetComponentInChildren<Text>().text = "Intro";
            introductionShown = false;
        }
        else
        {
            displayedText.text = introductionText;
            changeTextButton.GetComponentInChildren<Text>().text = "Disclaimer";
            introductionShown = true;
        }
    }

}

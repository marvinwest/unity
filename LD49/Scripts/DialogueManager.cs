using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private StabilityBar stabilityBar;
    [SerializeField] private GameObject choicesButtonPrefab;
    [SerializeField] private List<GameObject> currentChoiceButtons;

    [SerializeField] private List<Dialogue> dialogues;

    [SerializeField] private Text speakerText;
    public Text SpeakerText => speakerText;

    [SerializeField] private Image speakerTextBackground;
    public Image SpeakerTextBackground => speakerTextBackground;

    [SerializeField] private Text speakerNameText;
    public Text SpeakerNameText => speakerNameText;

    [SerializeField] private NextDialogueButtonBehaviour nextButton;
    [SerializeField] private QuitGameButtonBehaviour quitButton;
    [SerializeField] private FinishedGameButtonBehaviour finishedButton;
    [SerializeField] private LostGameButtonBehaviour lostButton;

    [SerializeField] private AudioSource audioSource;

    private Dialogue currentDialogue;
    private DialogueNode currentDialogueNode;

    private float stability;

    void Start()
    {
        stabilityBar.SetMaxStability(100);
        stability = 60;
        stabilityBar.setStartStability(60);
        nextButton.gameObject.SetActive(false);
        finishedButton.gameObject.SetActive(false);
        lostButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
        NewRandomDialogue();
    }

    public void NewRandomDialogue()
    {
        if (stability <= 0f)
        {
            gameLost();
            return;
        }
        if (dialogues.Count <= 0)
        {
            SpeakerNameText.text = "";
            gameFinished();
        }
        else
        {
            int index = Random.Range(0, dialogues.Count);
            currentDialogue = dialogues[index];
            currentDialogueNode = currentDialogue.FirstNode;
            dialogues.RemoveAt(index);
            SpeakerNameText.text = currentDialogue.SpeakerName;
            setSpeakerText();
            instantiateChoices();
        }
    }

    public void ChoiceClicked(DialogueChoice[] nodes)
    {
        if (nodes.Length == 0)
        {
            destroyCurrentChoiceButtons();
            StopAllCoroutines();
            audioSource.Pause();
            speakerText.text = "";
            speakerNameText.text = "";
            if (dialogues.Count > 0 && stability > 0)
            {
                speakerTextBackground.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
            }
            else if (dialogues.Count <= 0 && stability > 0)
            {
                speakerTextBackground.gameObject.SetActive(false);
                gameFinished();
            }
        }
        else
        {
            destroyCurrentChoiceButtons();
            int index = Random.Range(0, nodes.Length);
            currentDialogueNode = nodes[index].ChoiceNode;
            UpdateStabilityBar(currentDialogueNode.StabilityChange);
            if (stability <= 0)
            {
                gameLost();
                return;
            }
            setSpeakerText();
            if (currentDialogueNode.Choices.Length <= 0 && dialogues.Count > 0 && stability > 0)
            {
                nextButton.gameObject.SetActive(true);
            }
            instantiateChoices();
        }
    }

    private void setSpeakerText()
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentDialogueNode.DialogueLine));
    }

    IEnumerator TypeSentence(string sentence)
    {
        if (currentDialogueNode.Choices.Length <= 0 && dialogues.Count <= 0)
        {
            gameFinished();
        }
        audioSource.Play();
        speakerText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            speakerText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.Pause();
    }

    public void UpdateStabilityBar(int stabilityChange)
    {
        if (stabilityChange + stabilityBar.getStability() >= 100)
        {
            stability = 100;
        }
        else
        {
            stability += stabilityChange;
        }
        stabilityBar.ChangeStability(stabilityChange);
        if (stability <= 0)
        {
            gameLost();
        }
    }

    private void instantiateChoices()
    {
        DialogueChoice[] choices = currentDialogueNode.Choices;

        int startPositionY = -175;
        foreach(DialogueChoice choice in choices)
        {
            //why is this button not instantiated?? Try RectTransform?
            GameObject newChoice = Instantiate(choicesButtonPrefab, new Vector3(0, startPositionY, 0), Quaternion.identity);
            newChoice.GetComponentInChildren<DialogueChoiceController>().Choice = choice;
            newChoice.transform.SetParent(canvas.transform, false);
            startPositionY -= 105;
            currentChoiceButtons.Add(newChoice);
        }
    }

    private void destroyCurrentChoiceButtons()
    {
        foreach(GameObject choiceButton in currentChoiceButtons)
        {
            GameObject.Destroy(choiceButton);
        }
        currentChoiceButtons.Clear();
    }

    private void gameFinished()
    {
        quitButton.gameObject.SetActive(false);
        finishedButton.gameObject.SetActive(true);
    }

    private void gameLost()
    {
        StopAllCoroutines();
        audioSource.Pause();
        destroyCurrentChoiceButtons();
        speakerText.text = "";
        speakerNameText.text = "";
        speakerTextBackground.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        lostButton.gameObject.SetActive(true);
    }

}

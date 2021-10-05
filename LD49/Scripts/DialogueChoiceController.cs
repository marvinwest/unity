using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoiceController : MonoBehaviour
{
    [SerializeField] private string choiceText;
    [SerializeField] private DialogueChoice choice;

    public DialogueChoice Choice
    {
        set
        {
            choiceText = value.ChoiceNode.DialogueLine;
            choice = value;
        }
    }

    void Start()
    {
        this.gameObject.SetActive(true);
        GetComponent<Button>().onClick.AddListener(OnClick);
        GetComponent<Button>().GetComponentInChildren<Text>().text = choiceText;
    }

    private void OnClick()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        dialogueManager.UpdateStabilityBar(choice.ChoiceNode.StabilityChange);
        dialogueManager.ChoiceClicked(choice.ChoiceNode.Choices);
    }

}

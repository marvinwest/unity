using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogueButtonBehaviour : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(NextDialogue);
    }

    private void NextDialogue()
    {
        this.gameObject.SetActive(false);
        dialogueManager.NewRandomDialogue();
        dialogueManager.SpeakerTextBackground.gameObject.SetActive(true);
    }

}

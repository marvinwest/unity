using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DialogueChoice
{
    [SerializeField] private string choicePreview;
    [SerializeField] private DialogueNode choiceNode;

    public string ChoicePreview => choicePreview;
    public DialogueNode ChoiceNode => choiceNode;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    [SerializeField] private string dialogueLine;
    public string DialogueLine => dialogueLine;

    [SerializeField] private DialogueChoice[] choices;
    public DialogueChoice[] Choices => choices;

    [SerializeField] private int stabilityChange;
    public int StabilityChange => stabilityChange;



    public bool CanBeFollowedByNode(DialogueNode node)
    {
        return choices.Any(x => x.ChoiceNode == node);
    }
    
}

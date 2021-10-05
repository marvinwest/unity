using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] DialogueNode firstNode;
    public DialogueNode FirstNode => firstNode;

    [SerializeField] string speakerName;
    public string SpeakerName => speakerName;


}

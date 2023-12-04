using UnityEngine;

[CreateAssetMenu(fileName = "new DialogNode", menuName = "Dialogue/Dialog", order = 0)]
public class DialogNode : BaseNode, iHaveNextNode {

    [Header("Speaker:")]
    public string keyName;
    public string keyMessage;

    [Header("Speakers:")]
    public DialogSpeaker[] speakers;

    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }

}

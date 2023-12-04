
using UnityEngine;

// Si queremos que el Trigger Node tenga un nodo a continuación, descomentamos lo relacionado a iHaveNextNode
// De lo contrario, un trigger node es un end node por defecto
[CreateAssetMenu(fileName = "new TriggerNode", menuName = "Dialogue/Triggers/TRIGGER_CUSTOM_NAME", order = 0)]
public class TriggerNodeTemplate : TriggerNode /**, iHaveNextNode */ {
    public override void Trigger() {
        // Código para ejecutar en el momento en el que el trigger entra en juego
    }

    /** iHavveNextNode
    [SerializeField, Header("Next Node: (null) => EndNode")]
    private BaseNode nextDialogNode;
    public BaseNode nextNode { get => nextDialogNode; set { value = nextDialogNode; } }
    */

}

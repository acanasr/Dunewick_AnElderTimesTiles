using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new OptionsNode", menuName = "Dialogue/Options", order = 0)]
public class OptionsNode : BaseNode {

    [Header("Player Options")]
    public List<DialogOption> options;

}

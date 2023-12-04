using UnityEngine;

/** class GameManager
 * ------------------
 * 
 * @see uCore
 * 
 * @author: Nosink Ð (Ricard Ruiz)
 * @version: v2.0 (04/2023)
 * 
 */

public class GameManager : MonoBehaviour {

    [SerializeField]
    private BaseNode _node;

    public BaseNode getDialog() {
        return _node;
    }

    public void setDialog(BaseNode node) {
        _node = node;
    }

}

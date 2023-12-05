using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    public BaseNode _node;

    // Start is called before the first frame update
    void Start()
    {
        DialogManager.instance.startDialog(_node);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNode(BaseNode node)
    {
        DialogManager.instance.startDialog(node);
    }
}

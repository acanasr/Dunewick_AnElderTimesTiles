using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

    /** Singleton Instance */
    private static DialogManager _intance = null;
    public static DialogManager instance {
        get {
            if (_intance == null)
                _intance = new GameObject(typeof(DialogManager).ToString()).AddComponent<DialogManager>();

            return _intance;
        }
    }

    /** Callbacks */
    public Action onEndDialog;
    public Action<BaseNode> onNextDialog;

    /** Current Node */
    [SerializeField, Header("Dialogs:")]
    private BaseNode _current = null;
    [SerializeField]
    private List<BaseNode> _history = new List<BaseNode>();

    /** Special Nodes */
    private BaseNode _lastOptionsNode;
    public BaseNode LastOptions() {
        return _lastOptionsNode;
    }

    private BaseNode _lastTriggerNode;
    public BaseNode LastTrigger() {
        return _lastTriggerNode;
    }

    // Unity Awake
    private void Awake() {
        // Singleton stuff
        DontDestroyOnLoad(gameObject);
    }

    /** Inicia el dialogo desde un nodo concreto */
    public void startDialog(BaseNode node) {
        _current = node;
        onNextDialog?.Invoke(_current);
    }

    /** Control del siguietne dialogo */
    public void nextDialog() {
        //If you have delegate function for when passing the node
        if (_current.nextNodeDelegate != null)
        {
            // Call the assigned function
            _current.nextNodeDelegate.Invoke();
        }
        nextDialog(((iHaveNextNode)_current).nextNode);
    }

    /** Control del siguietne dialogo, pero especificando cual ;3 */
    public void nextDialog(BaseNode node) {
        onEndDialog?.Invoke();

        _history.Add(_current);
        _current = node;

        // NextDialog
        onNextDialog?.Invoke(_current);

        // Exit si vamos null
        if (_current == null)
            return;

        // Trigger DialogNode
        if (_current is TriggerNode) {
            _lastTriggerNode = _current;
            ((TriggerNode)_current).Trigger();
            nextDialog((_current is iHaveNextNode ? ((iHaveNextNode)_current).nextNode : null));
        }
        // Options DialogNode
        else if (_current is OptionsNode) {
            _lastOptionsNode = _current;
        }
    }

}

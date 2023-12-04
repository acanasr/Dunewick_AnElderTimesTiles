using UnityEngine;
using UnityEditor;

public delegate void OnNextNodeDelegate();
public abstract class BaseNode : ScriptableObject {

    [Header("Background:")]
    public Sprite background;

    public OnNextNodeDelegate nextNodeDelegate;

}

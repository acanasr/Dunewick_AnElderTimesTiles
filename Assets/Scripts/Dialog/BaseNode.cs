using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

public abstract class BaseNode : ScriptableObject {

    [Header("Background:")]
    public Sprite background;

    public List<NodeFunctionsEnum> startNodeFunctionID;
    public List<NodeFunctionsEnum> endNodeFunctionID;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNodeFunctions : MonoBehaviour
{
    void Start()
    {
        SwordSound();
    }

    public void SwordSound()
    {
        uCore.Audio.PlaySFX("SwordSoundEffect");
    }
}

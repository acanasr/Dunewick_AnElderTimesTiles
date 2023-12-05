using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum NodeFunctionsEnum { NONE, FADE_IN, FADE_OUT, FADE_IN_OUT, LOAD_PAPER_BUTTON, INTERACTABLE_PAPER_BUTTON, SWORD_SOUND,
MUSIC_ACT1, MUSIC_ACT2, MUSIC_ACT3, MUSIC_ACT4, MUSIC_ACT5,
DRINK_TEA_PUZZLE
};
public class EndNodeFunctions : MonoBehaviour
{
    FadeFX fade;
    public Button paperButton;

    [SerializeField] GameObject textTeaPuzzle;
    [SerializeField] GameObject objTeaPuzzle;
    [SerializeField] Image backgroundImg;
    [SerializeField] Sprite casa;
    private void Start()
    {
        fade = FindObjectOfType<FadeFX>();
    }
    public void MyFunction(NodeFunctionsEnum NodeFunc)
    {
        switch (NodeFunc)
        {
            case NodeFunctionsEnum.NONE:
                break;
            case NodeFunctionsEnum.FADE_IN:
                FadeIn();
                break;
            case NodeFunctionsEnum.FADE_OUT:
                FadeOut();
                break;
            case NodeFunctionsEnum.FADE_IN_OUT:
                FadeInAndOut();
                break;
            case NodeFunctionsEnum.LOAD_PAPER_BUTTON:
                LoadPaperButton();
                break;
            case NodeFunctionsEnum.INTERACTABLE_PAPER_BUTTON:
                InteractablePaperButton();
                break;
            case NodeFunctionsEnum.SWORD_SOUND:
                SwordSound();
                break;
            case NodeFunctionsEnum.MUSIC_ACT1:
                MusicThemeActI();
                break;
            case NodeFunctionsEnum.MUSIC_ACT2:
                MusicThemeActII();
                break;
            case NodeFunctionsEnum.MUSIC_ACT3:
                MusicThemeActIII();
                break;
            case NodeFunctionsEnum.MUSIC_ACT4:
                MusicThemeActIV();
                break;
            case NodeFunctionsEnum.MUSIC_ACT5:
                MusicThemeActV();
                break;
            case NodeFunctionsEnum.DRINK_TEA_PUZZLE:
                DrinkTeaPuzzle();
                break;
        }
    }
    void SwordSound()
    {
        uCore.Audio.PlaySFX("SwordSoundEffect");
    }
    void MusicThemeActI()
    {
        uCore.Audio.PlaySoundtrack("ActIPartIIMusicTheme");
    }
    void MusicThemeActII()
    {
        uCore.Audio.PlaySoundtrack("ActIIMusicTheme");
    }
    void MusicThemeActIII()
    {
        uCore.Audio.PlaySoundtrack("ActIIIMusicTheme");
    }
    void MusicThemeActIV()
    {
        uCore.Audio.PlaySoundtrack("ActIVMusicTheme");
    }
    void MusicThemeActV()
    {
        uCore.Audio.PlaySoundtrack("ActVMusicTheme");
    }

    void FadeIn()
    {
        fade.FadeIn();
    }
    void FadeOut()
    {
        fade.FadeOut();
    }
    void FadeInAndOut()
    {
        fade.FadeInAndOut();
    }
    void FadeInChangeScene()
    {
        fade.FadeIn(()=> NextScene());
        
    }
    void NextScene()
    {
        uCore.Director.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void LoadPaperButton()
    {
        paperButton.gameObject.SetActive(true);
    }
    void InteractablePaperButton() {
        paperButton.interactable = true;
    }
    void DrinkTeaPuzzle()
    {
        objTeaPuzzle.SetActive(true);
        textTeaPuzzle.SetActive(true);
        backgroundImg.sprite = casa;
    }
}

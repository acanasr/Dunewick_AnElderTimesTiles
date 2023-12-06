using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum NodeFunctionsEnum { NONE, FADE_IN, FADE_OUT, FADE_IN_OUT, LOAD_PAPER_BUTTON, INTERACTABLE_PAPER_BUTTON, SWORD_SOUND,
MUSIC_ACT1, MUSIC_ACT2, MUSIC_ACT3, MUSIC_ACT4, MUSIC_ACT5,
DRINK_TEA_PUZZLE, FORGE_SWORD_PUZZLE,
TRANSITION_ACTI_ACTII, TRANSITION_ACTII_ACTIII, TRANSITION_ACTIII_ACTIV, TRANSITION_ACTIV_ACTV, FINAL
};
public class EndNodeFunctions : MonoBehaviour
{
    FadeFX fade;
    public Button paperButton;

    [SerializeField] GameObject textTeaPuzzle;
    [SerializeField] GameObject objTeaPuzzle;
    [SerializeField] Image backgroundImg;
    [SerializeField] Sprite casa;

    [SerializeField] TextMeshProUGUI ActText;
    [SerializeField] BaseNode ActIStartNode;
    [SerializeField] BaseNode ActIIStartNode;
    [SerializeField] BaseNode ActIIIStartNode;
    [SerializeField] BaseNode ActIVStartNode;
    [SerializeField] BaseNode ActVStartNode;
    DialogManager dialogManager;


    [SerializeField] GameObject textSwordPuzzle;
    [SerializeField] GameObject objSwordPuzzle;

    private void Start()
    {
        fade = FindObjectOfType<FadeFX>();
        dialogManager = FindObjectOfType<DialogManager>();
        fade._alpha = 1.0f;
        ActText.text = "Dunewick: An Elder Times Tiles";
        Invoke("ActITextFadeOut",3.0f);
    }
    void ActITextFadeOut()
    {
        ActText.text = "";
        fade.FadeOut(() => dialogManager.startDialog(ActIStartNode));
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
            case NodeFunctionsEnum.FORGE_SWORD_PUZZLE:
                ForgeSwordPuzzle();
                break;
            case NodeFunctionsEnum.TRANSITION_ACTI_ACTII:
                TransitionActIActII();
                break;
            case NodeFunctionsEnum.TRANSITION_ACTII_ACTIII:
                TransitionActIIActIII();
                break;
            case NodeFunctionsEnum.TRANSITION_ACTIII_ACTIV:
                TransitionActIIIActIV();
                break;
            case NodeFunctionsEnum.FINAL:
                Invoke("End", 3.0f);
                break;

        }
    }
    void End()
    {
        fade.FadeIn(() => ActText.text = "THE END.   Done by Albert Cañas");
        Invoke("Close", 10.0f);
    }
    void Close()
    {
        Application.Quit();
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

    void ForgeSwordPuzzle()
    {
        textSwordPuzzle.SetActive(true);
        objSwordPuzzle.SetActive(true);
        backgroundImg.sprite = casa;
    }
    void TransitionActIActII()
    {
        fade.FadeIn(() => ActText.text = "Dos semanas más tarde");
        uCore.Audio.StopAllSoundtracks();
        MusicThemeActII();
        Invoke("EndTransitionActI", 5.0f);
    }
    void EndTransitionActI()
    {
        ActText.text = ""; 
        dialogManager.startDialog(ActIIStartNode);
        fade.FadeOut();
    }


    void TransitionActIIActIII()
    {
        fade.FadeIn(() => ActText.text = "Dos meses más tarde");
        uCore.Audio.StopAllSoundtracks();
        MusicThemeActIII();
        Invoke("EndTransitionActII", 5.0f);
    }
    void EndTransitionActII()
    {
        ActText.text = "";
        dialogManager.startDialog(ActIIIStartNode);
        fade.FadeOut();
    }
    void TransitionActIIIActIV()
    {
        fade.FadeIn(() => ActText.text = "Un mes más tarde");
        uCore.Audio.StopAllSoundtracks();
        MusicThemeActIV();
        Invoke("EndTransitionActIII", 5.0f);
    }
    void EndTransitionActIII()
    {
        ActText.text = "";
        dialogManager.startDialog(ActIVStartNode);
        fade.FadeOut();
    }

    public void TransitionActIVActV()
    {
        textSwordPuzzle.SetActive(false);
        objSwordPuzzle.SetActive(false);
        fade.FadeIn(() => ActText.text = "Tres meses más tarde");
        uCore.Audio.StopAllSoundtracks();
        MusicThemeActV();
        Invoke("EndTransitionActIV", 5.0f);
    }
    void EndTransitionActIV()
    {
        ActText.text = "";
        dialogManager.startDialog(ActVStartNode);
        fade.FadeOut();
    }
}

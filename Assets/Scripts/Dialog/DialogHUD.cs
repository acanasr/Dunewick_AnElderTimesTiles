using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogHUD : MonoBehaviour {

    private BaseNode _currentDialog;

    /** Option Prefab */
    private GameObject _optionPrefab = null;

    [SerializeField, Header("Speakers:")]
    private GameObject _panelSpeaker;
    private GameObject _speakerPrefab = null;

    [SerializeField, Header("Options:")]
    private GameObject _panelOptions;

    [SerializeField, Header("Texts:")]
    private GameObject _panelText;
    [SerializeField]
    private UIText _txtSpeakerName;
    [SerializeField]
    private UIText _txtSpeakerText;

    [SerializeField, Header("Background:")]
    private Image _panelBackground;

    // Control
    private progress _dialogProgress = progress.ready;

    [SerializeField, Header("Timing:")]
    private float _textSpeed = 0.05f;

    // Unity OnEnable
    void OnEnable() {
        DialogManager.instance.onEndDialog += Clear;
        DialogManager.instance.onNextDialog += UpdateDialog;
    }

    // Unity OnDisable
    void OnDisable() {
        DialogManager.instance.onEndDialog += Clear;
        DialogManager.instance.onNextDialog += UpdateDialog;
    }

    // Unity Awake
    void Awake() {
        _optionPrefab = Resources.Load<GameObject>("Prefabs/Interface/OptionUI");
        _speakerPrefab = Resources.Load<GameObject>("Prefabs/Interface/SpeakerUI");
    }

    // Limpia y actualiza el flow de dialogos
    // También se encarga de la interfaz
    public void UpdateDialog(BaseNode current) {

        _currentDialog = current;

        // Desactivamos dialogo
        _panelText.SetActive(false);
        _panelOptions.SetActive(false);
        _panelSpeaker.SetActive(false);

        // Last Dialogue Node
        if (_currentDialog == null) {
            return;
        }

        // Background for nodes
        if (_currentDialog.background != null) {
            _panelBackground.sprite = _currentDialog.background;
        }

        // Node with Options
        if (current is OptionsNode) {
            _panelOptions.SetActive(true);
            foreach (DialogOption op in ((OptionsNode)_currentDialog).options) {
                GameObject option = GameObject.Instantiate(_optionPrefab, _panelOptions.transform);
                option.GetComponentInChildren<UIText>().SetKey(op.keyText);
                option.GetComponent<Button>().onClick.AddListener(() => {
                    DialogManager.instance.nextDialog(op.next);
                });
            }
            return;
        }

        // Node with Dialog
        if (current is DialogNode) {
            _dialogProgress = progress.doing;
            _panelText.SetActive(true);
            _panelSpeaker.SetActive(true);
            DialogNode currentDialog = (DialogNode)_currentDialog;
            if (currentDialog.speakers.Length != 0) {
                foreach (Transform child in _panelSpeaker.transform) {
                    GameObject.Destroy(child.gameObject);
                }
                foreach (DialogSpeaker dp in currentDialog.speakers) {
                    GameObject speaker = GameObject.Instantiate(_speakerPrefab, _panelSpeaker.transform);
                    speaker.GetComponent<Image>().sprite = dp.speaker;
                    speaker.GetComponent<Image>().color = new Color(1f, 1f, 1f, (dp.active ? 1f : 0.3f));
                }
            }
            _txtSpeakerName.SetKey(currentDialog.keyName);
            StartCoroutine(C_DisplayText(uCore.Localization.GetText(currentDialog.keyMessage)));
        }
    }


    // Coroutine para mostrar el texto timeado por _speed
    private IEnumerator C_DisplayText(string text, int pos = 0) {
        if (pos == text.Length) {
            _dialogProgress = progress.done;
        } else {
            _txtSpeakerText.UpdateText(text.Substring(0, pos + 1));
            yield return new WaitForSeconds(_textSpeed);
            StartCoroutine(C_DisplayText(text, pos + 1));
        }
    }

    // Limpia todos los elementos del dialogo y borra las opciones
    private void Clear() {
        _txtSpeakerName.Clear();
        _txtSpeakerText.Clear();
        foreach (Transform child in _panelOptions.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    // Clickar en el texto del dialogo
    public void EVENT_OnClickDialogue() {
        if (_dialogProgress.Equals(progress.doing)) {
            StopAllCoroutines();
            _txtSpeakerText.SetKey(((DialogNode)_currentDialog).keyMessage);
            _dialogProgress = progress.done;
        } else {
            DialogManager.instance.nextDialog();
        }
    }

}


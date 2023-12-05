using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class FadeFX : MonoBehaviour {

    /** Singleton Instance */
    private static FadeFX _instance;
    public static FadeFX Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<FadeFX>();

            return _instance;
        }

    }

    private Image _image;
    private float _alpha;
    [SerializeField]
    private float _duration = 2.5f;
    private float _baseDuration;

    [SerializeField]
    private bool _isFading = false;
    public bool isFading() { return _isFading; }

    // Unity Awake
    void Awake() {
        _instance = this;
        _baseDuration = _duration;
        _image = GetComponent<Image>();
    }

    /** FadeIn */
    public void FadeIn(Action callback = null) {
        if (_isFading)
            return;

        _alpha = 0f;
        _isFading = true;
        StartCoroutine(CFade(1f, callback));
    }

    /** Fade Out */
    public void FadeOut(Action callback = null) {
        if (_isFading)
            return;

        _alpha = 1f;
        _isFading = true;
        StartCoroutine(CFade(-1f, callback));
    }

    /** Duration sets */
    public void SetTemporalDuration(float duration) {
        _duration = duration;
    }

    /** Coroutine para hacer el fade */
    public IEnumerator CFade(float target, Action callback = null) {

        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _alpha);

        float speed = target / _duration;

        while (!Mathf.Approximately(_image.color.a, Mathf.Clamp(target, 0f, 1f))) {
            _alpha += speed * Time.deltaTime;
            _alpha = Mathf.Clamp01(_alpha);
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _alpha);
            yield return null;
        }

        _isFading = false;
        _duration = _baseDuration;
        callback?.Invoke();
    }

    public void FadeInAndOut(Action callback = null)
    {
        if (_isFading)
            return;

        _isFading = true;
        StartCoroutine(CFade(1f, () =>
        {
            // Fade In complete, now initiate Fade Out
            StartCoroutine(CFade(-1f, callback));
        }));
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

/** class uCore
 * ------------
 * 
 * Set de herramientas y utilizades que he creado para
 * facilitar el desarrollo de proyectos
 * muchas de sus funcionalidades est�n pensadas para facilitar el uso
 * de no programadores a interactuar  con el c�digo directamente
 * funciona con un objeto singleton que tiene como hijos todos los dem�s
 * su principal uso es haciendo acceso al uCore desde cualquier lugar dle �codigo
 * todas est�s herramientas son totalmente independientes y aunque funcionen en base a uCore
 * la inicializaci�n es automatica y no hay dependencias de escenas, exceptuando el GameManager
 * que es cosa del desarrollador del proyecto, uCore solo lo pone a disposici�n
 * 
 * @author: Nosink � (Ricard Ruiz)
 * @version: v6.3 (04/2023)
 * 
 */

public class uCore : MonoBehaviour {

    /** Prefijo y Sufijo de uCore */
    private static string _preFix = "-->  ";
    private static string _suFix = " -|";

    /** Singleton Instances */
    private static EffectsManager _effects = null;
    private static GameManager _gameManager = null;
    private static AudioManager _audioManager = null;
    private static ActionManager _actionManager = null;
    private static SceneDirector _sceneDirector = null;
    private static ParticleInstancer _particleInstancer = null;
    private static LocalizationManager _localizationManager = null;

    /** Singleton Getters */
    public static AudioManager Audio {
        get {
            if (_audioManager != null)
                return _audioManager;

            _audioManager = GameObject.FindObjectOfType<AudioManager>();
            if (_audioManager != null)
                return _audioManager;

            _audioManager = new GameObject(_preFix + "Audio" + _suFix).AddComponent<AudioManager>();
            _audioManager.transform.SetParent(uCore.GameManager.transform);

            return _audioManager;
        }
    }
    public static ActionManager Action {
        get {
            if (_actionManager != null)
                return _actionManager;

            _actionManager = GameObject.FindObjectOfType<ActionManager>();
            if (_actionManager != null)
                return _actionManager;

            // MUST NEED del PlayerInput para funcionar de forma correcta
            _actionManager = new GameObject(_preFix + "InputActions" + _suFix).AddComponent<ActionManager>();
            PlayerInput l_playerInput = _actionManager.GetComponent<PlayerInput>();
            l_playerInput.actions = Resources.Load<InputActionAsset>("Settings/InputActions");
            l_playerInput.currentActionMap = l_playerInput.actions.actionMaps[0];
            // \ MUST NEED \

            _actionManager.transform.SetParent(uCore.GameManager.transform);

            return _actionManager;
        }
    }
    public static EffectsManager Effects {
        get {
            if (_effects != null)
                return _effects;

            _effects = GameObject.FindObjectOfType<EffectsManager>();
            if (_effects != null)
                return _effects;

            _effects = new GameObject(_preFix + "Effects" + _suFix).AddComponent<EffectsManager>();
            _effects.transform.SetParent(uCore.GameManager.transform);

            return _effects;
        }
    }
    public static SceneDirector Director {
        get {
            if (_sceneDirector != null)
                return _sceneDirector;

            _sceneDirector = GameObject.FindObjectOfType<SceneDirector>();
            if (_sceneDirector != null)
                return _sceneDirector;

            _sceneDirector = new GameObject(_preFix + "Director" + _suFix).AddComponent<SceneDirector>();
            _sceneDirector.transform.SetParent(uCore.GameManager.transform);

            return _sceneDirector;
        }
    }
    public static GameManager GameManager {
        get {
            if (_gameManager != null)
                return _gameManager;

            _gameManager = GameObject.FindObjectOfType<GameManager>();
            if (_gameManager != null)
                return _gameManager;

            _gameManager = new GameObject(_preFix + "uCore" + _suFix).AddComponent<uCore>().gameObject.AddComponent<GameManager>();

            return _gameManager;
        }
    }
    public static ParticleInstancer Particles {
        get {
            if (_particleInstancer != null)
                return _particleInstancer;

            _particleInstancer = GameObject.FindObjectOfType<ParticleInstancer>();
            if (_particleInstancer != null)
                return _particleInstancer;

            _particleInstancer = new GameObject(_preFix + "Particles").AddComponent<ParticleInstancer>();
            _actionManager.transform.SetParent(uCore.GameManager.transform);

            return _particleInstancer;
        }
    }
    public static LocalizationManager Localization {
        get {
            if (_localizationManager != null)
                return _localizationManager;

            _localizationManager = GameObject.FindObjectOfType<LocalizationManager>();
            if (_localizationManager != null)
                return _localizationManager;

            _localizationManager = new GameObject(_preFix + "Localization" + _suFix).AddComponent<LocalizationManager>();
            _localizationManager.transform.SetParent(uCore.GameManager.transform);

            return _localizationManager;
        }
    }

    // Unity Awake
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

}

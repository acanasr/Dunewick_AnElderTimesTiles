using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour {

    /** Observer para indicar cuanod la escena a cargado */
    public static event Action OnSceneLoaded;
    /** AsyncOperation de LoadAsync */
    private AsyncOperation _asyncOp;

    /** M�todo LoadScene
     * Carga una escena de forma inmediatea
     * @param gameScenes scene Escena referencia creada en el enum */
    public void LoadScene(gameScenes scene) {
        SceneManager.LoadScene(scene.ToString());
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    /** M�todo LoadScene
     * Carga una escena de forma aditiva
     * @param gameScenes scene Escena referencia creada en el enum */
    public void LoadAdditiveScene(gameScenes scene) {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }

    /** M�todo LoadScene
     * Carga una escena de forma aditiva
     * @param gameScenes scene Escena referencia creada en el enum */
    public void UnloadSceneAsync(gameScenes scene) {
        SceneManager.UnloadSceneAsync(scene.ToString());
    }

    /** M�todo LoadSceneAsync
     * Carga una escena de forma asyncrona
     * @param gameScenes scene Escena referencia creada en el enum
     * @param bool allow Indicador si esta escena carga automaticamente al estar cargada o espera aviso */
    public void LoadSceneAsync(gameScenes scene, bool allow = true) {
        StartCoroutine(C_LoadSceneAsync(scene, allow));
    }

    /** M�todo C_LoadSceneAsync
     * M�todo coroutine para la carga asyncrona
     * @param gameScenes scene Escena referencia creada en el enum
     * @param bool allow Indicador si esta escena carga automaticamente al estar cargada o espera aviso */
    private IEnumerator C_LoadSceneAsync(gameScenes scene, bool allow) {
        yield return null;
        _asyncOp = SceneManager.LoadSceneAsync(scene.ToString());
        _asyncOp.allowSceneActivation = allow;
        while (!_asyncOp.isDone && _asyncOp.progress < 0.9f) {
            yield return null;
        }
        OnSceneLoaded?.Invoke();
    }

    /** M�todo AllowScene */
    public void AllowScene() {
        StartCoroutine(C_AllowScene());
    }

    /** M�todo C_AllowScene
     * M�todo de Coroutine para permitir la escena */
    private IEnumerator C_AllowScene() {
        while (_asyncOp == null) {
            yield return null;
        }
        _asyncOp.allowSceneActivation = true;
    }

    /** M�todo isSceneLoaded
     * Comprueba si ha cargado la escena totalmetne
     * @return bool true -> ha cargado false -> no ha cargado */
    public bool isSceneLoaded() {
        return (_asyncOp != null ? (_asyncOp.isDone || _asyncOp.progress >= 0.9f) : false);
    }

    /** M�todo LoadingPorgress
     * Comprueba el porcentaje de cargado qeu lleva la escena
     * @return float porentaje de cargado [0 .. 1] */
    public float LoadingProgress() {
        return (_asyncOp != null ? _asyncOp.progress : 0f);
    }

}

using System.Collections;
using UnityEngine;

/** class AudioElement
 * -------------------
 * 
 * Clase que controla los objeto de audio
 * Encargado de los efectos de sonido 2D y 3D
 * Tambi�n controla el Soundtrack y m�sica del juego
 * 
 * @see BasicElement
 * @see audioType
 * 
 * @author: Nosink � (Ricard Ruiz)
 * @version: v2.0 (04/2023)
 * 
 */

[RequireComponent(typeof(AudioSource))]
public class AudioElement : BasicElement<AudioElement> {

    /** AudioSource */
    public AudioSource Source {
        get {
            return GetComponent<AudioSource>();
        }
    }

    /** M�todo Reset
     * Reinicia el audio
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement Reset() {
        Stop();
        Play(Source.volume);
        return this;
    }

    /** M�todo Play
     * Reproduce un audio con volume o m�x volumen
     * @param float volume Volumen del sonido
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement Play(float volume = -1f) {
        Source.volume = (volume == -1f ? Source.volume : volume);
        Source.Play();
        return this;
    }

    /** M�todo Stop
     * Para el audio
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement Stop() {
        Source.Pause();
        return this;
    }

    /** M�todo FadeOut
     * Efecto de FadeOut en el sonido
     * @param float time Duraci�n del efecto
     * @param delay Delay del para el inicio del tiempo
     * @param max Volumen m�ximo que queremos alcanzar
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement FadeOut(float time, float delay = 0f, float min = 0f) {
        if (Source.isPlaying) {
            StartCoroutine(C_FadeAudio(time, delay, Source.volume, min));
        }
        return this;
    }

    /** M�todo FadeIn
     * Inicia un efecto de FadeIn en el udio
     * @param float time Duraci�n del efecto
     * @param delay Delay del para el inicio del tiempo
     * @param max Volumen m�ximo que queremos alcanzar
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement FadeIn(float time, float delay = 0f, float max = 1f) {
        if (!Source.isPlaying) {
            Play(0f);
        }
        StartCoroutine(C_FadeAudio(time, delay, Source.volume, max));
        return this;
    }

    /** M�todo C_FadeAudio
     * M�todo de Coroutine para controlar el fade del audio
     * @param float time Duraci�n total del efecto
     * @param float delay Delay del efecto
     * @param float start Volumen origen
     * @param float end Volumen destino
     * @return AudioElement Se devuevle a si mismo */
    private IEnumerator C_FadeAudio(float time, float delay, float start, float end) {
        yield return new WaitForSeconds(delay);
        float startTime = Time.time;
        while (Time.time < startTime + time) {
            Source.volume = Mathf.Lerp(start, end, (Time.time - startTime) / time);
            yield return null;
        }
        Source.volume = end;
    }

    /** M�todo PlayDelayed
     * Reproduce un audio con delay
     * @param float delay Tiempo de delay
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement PlayDelayed(float delay) {
        Source.PlayDelayed(delay);
        return this;
    }

    /** M�todo PlayScheduled
     * Reproduce un tiempo en un momento concreto
     * @param double time Tiempo en el que se ejeecutara
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement PlayScheduled(double time) {
        Source.PlayScheduled(time);
        return this;
    }

    /** M�todo Mute
     * Mutea el AudioSource
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement Mute() {
        Source.mute = true;
        return this;
    }

    /** M�todo UnMute
     * Desmutea el AudioSource
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement UnMute() {
        Source.mute = false;
        return this;
    }

    /** M�todo EnableByPassEffects
     * Habilita los efectos
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement EnableByPassEffects() {
        Source.bypassEffects = true;
        return this;
    }

    /** M�todo DisableByPassEffects
     * Desabilita los effectdos
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement DisableByPassEffects() {
        Source.bypassEffects = false;
        return this;
    }

    /** M�todo looped
     * Asiga el valor de loop al AudioSource
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement looped() {
        Source.loop = true;
        return this;
    }

    /** M�todo noLoop
     * Deshabilita la opci�n de lopear del AudioSource
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement noLoop() {
        Source.loop = false;
        return this;
    }

    /** M�todo destroyAtEnd
     * Override de destroyAtEnd, destruye el audio al final de su reproducci�n
     * @return AudioElement Se devuevle a si mismo */
    public override AudioElement destroyAtEnd() {
        destroyOnTime(Source.clip.length - Source.time);
        return this;
    }

    /** M�todo withVolumeEq
     * Establece el volumen del audio
     * @param float volume Volumen
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement withVolumeEq(float volume) {
        Source.volume = volume;
        return this;
    }

    /** M�todo withPitchEq
     * Establece el pitch al audio
     * @param float value Valor de pitch
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement withPitchEq(float value) {
        Source.pitch = value;
        return this;
    }

    /** M�todo withPanningEq
     * Establece el valor del panning del audio
     * @param float pan Valor de Panning
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement withPanningEq(float pan) {
        Source.panStereo = pan;
        return this;
    }

    /** M�todo with3D
     * Declara el CustomRollOff a modo 3D
     * @param float value la cantidad de "3D" que es el audio
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement with3D(float value = 1f) {
        Source.spatialBlend = value;
        return this;
    }

    /** M�todo with2D
     * Declara el CustomRollOff a modo 2D
     * @param float value la cantidad de "2D" que es el audio
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement with2D(float value = 0f) {
        with3D(value);
        return this;
    }

    /** M�todo onMinMaxDistance
     * Estasblece las distancias minima y m�xima que se escucha el audio
     * @param float min Distancia minima
     * @param float max Distancia m�xima
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement onMinMaxDistance(float min = 0f, float max = 12f) {
        Source.maxDistance = max;
        Source.minDistance = min;
        return this;
    }

    /** M�todo rollOfType
     * Configura un audio, asigando el RollOff y las distnacias
     * @param AudioRolloffMode type Tipo de RollOff para la gesti�n del 2D-3D del audio
     * @param float min Distancia minima
     * @param float max Distancia m�xima
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement rollOfType(AudioRolloffMode type, float min = 0f, float max = 12f) {
        Source.rolloffMode = type;
        onMinMaxDistance(min, max);
        return this;
    }

    /** M�todo randomPitch
     * Establece un valor random al pitch
     * @param float min Valor minimo
     * @param float max Valor m�ximo
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement randomPitch(float min, float max) {
        return withPitchEq(Random.Range(min, max));
    }

    /** M�todo randomVolume
     * Establece un valor random al volumen
     * @param float min Valor minimo
     * @param float max Valor m�ximo
     * @return AudioElement Se devuevle a si mismo */
    public AudioElement randomVolume(float min, float max) {
        return withVolumeEq(Random.Range(min, max));
    }

}

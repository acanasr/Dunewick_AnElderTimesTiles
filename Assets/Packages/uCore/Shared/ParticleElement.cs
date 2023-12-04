using UnityEngine;

/** class ParticleElement
 * ----------------------
 * 
 * Clase que controla los objeto de particulas
 * 
 * @see BasicElement
 * 
 * @author: Nosink � (Ricard Ruiz)
 * @version: v1.0 (04/2023)
 * 
 */

public class ParticleElement : BasicElement<ParticleElement> {

    /** ParticleSystem */
    public ParticleSystem System {
        get {
            return GetComponent<ParticleSystem>();
        }
    }

    /** M�todo Play
     * Reproduce el sistema de particulas completo
     * @return ParticleElement se devuelve a si mismo */
    public ParticleElement Play() {
        System.Play();
        return this;
    }

    /** M�todo destroyAtEnd
     * Override de la destrucci�n, lo destruye cuando acaba la duraci�n de todo el sistema
     * @return ParticleElement se devuelve a si mismo */
    public override ParticleElement destroyAtEnd() {
        destroyOnTime(System.main.duration);
        return this;
    }

}

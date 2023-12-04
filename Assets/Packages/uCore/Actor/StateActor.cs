using UnityEngine;

/** abstract class StateActor
 * --------------------------
 * 
 * Estructura para gestionar los Actores de un juego
 * Pensada para ser el "contenedor" de la FStateMachine
 * Puede crear transiciones y añadirlas a la maquina principal
 * Gestiona el Awake, Start y Update de unity
 * 
 * @see FStateMachine
 * @see StateTransition
 * 
 * @author: Nosink Ð (Ricard Ruiz)
 * @version: v4.0 (04/2023)
 * 
 */

[RequireComponent(typeof(FStateMachine))]
public abstract class StateActor : MonoBehaviour {

    /** FSM */
    protected FStateMachine StateMachine;

    /** Método abstracto ConstructMachine
     * Inicializa todo lo relacionado con la FSM */
    protected abstract void ConstructMachine();

    // Unity Awake
    protected virtual void Awake() {
        StateMachine = GetComponent<FStateMachine>();
        ConstructMachine();
    }

    // Unity Start
    protected virtual void Start() {
        StateMachine.StartMachine();
    }

    // Unity Update
    protected virtual void Update() {
        StateMachine.UpdateMachine();
    }

    /** Método AddTransition
     * Añadire directamente la la transición a la FSM
     * @param BasicState from Estado origen
     * @param StateTransition transition Transición ya creada y configurada, solo lista para añadirse al estado
     * @param BasicState to Estado destino */
    protected void AddTransition(BasicState from, StateTransition transition, BasicState to) {
        from.AddTransition(transition, to);
    }

    protected void AddTransitionFromAnyStateTo(BasicState to, StateTransition transition) {
        AddTransition(to, transition, to);
    }

}

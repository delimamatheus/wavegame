using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum STATES
    {
        IDLE,
        FALLING,
        MOVING,
        DEAD
    }

    public Dictionary<STATES, StateBase> dictionaryStates;

    private StateBase _currentState;
    public Player player;
    public float startTime = 1f;

    private void Awake()
    {
        dictionaryStates = new Dictionary<STATES, StateBase>();
        dictionaryStates.Add(STATES.IDLE, new StateBase());
        dictionaryStates.Add(STATES.MOVING, new StateMoving());
        dictionaryStates.Add(STATES.FALLING, new StateBase());
        dictionaryStates.Add(STATES.DEAD, new StateBase());

        SwitchState(STATES.IDLE);

        Invoke(nameof(StartGame), startTime);
    }

    private void StartGame()
    {
        SwitchState(STATES.MOVING);
    }

    private void SwitchState(STATES state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryStates[state];

        _currentState.OnStateEnter(player);
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }

}

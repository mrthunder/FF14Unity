using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachineComponent))]
public class AIEnemyController : MonoBehaviour
{
    [SerializeField]
    private Enemy _controlledEnemy = null;
    private StateMachineComponent _stateMachine = null;
    private List<Vector3> _destinations = null;
    // Whom the AI will try to engage with.
    private Character _target = null;

    public void AssignControlledEnemy(Enemy enemy)
    {
        if (_controlledEnemy == null)
        {
            _controlledEnemy = enemy;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _destinations = _controlledEnemy.Information.Settings.Destinations;
        _stateMachine = GetComponent<StateMachineComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controlledEnemy)
        {
            transform.position = _controlledEnemy.transform.position;

            // Patrol until you find someone
            if (_target == null && _stateMachine.CurrentState == StateMachineComponent.State.Patrol)
            {
                _stateMachine.Patrol(_destinations, _controlledEnemy.Agent, _controlledEnemy.InitialPosition);
                // I am just saving the layer mask where the player / character is.
                const int CHARACTER_LAYER_MASK = (1 << 8);
                // This long if is just because the information comes from the controlled enemy
                // but as it reads I am just trying to detect the player.
                if (_stateMachine.DidDetectATarget<Character>(_controlledEnemy.transform.position, // AI Position
                    _controlledEnemy.transform.forward, // Where the AI is facing
                    _controlledEnemy.Information.AI.PerceptionSphereRadius, // How big the perception sphere of the AI
                    _controlledEnemy.Information.AI.PerceptionConeAngle, // The angle of the AI field of view
                    CHARACTER_LAYER_MASK, // The character layer mask, so the function only looks at the character on scene.
                    out Character character))
                {
                    _target = character; // Now the player is the target.
                    _controlledEnemy.Agent.ResetPath(); //This is so once you catch up to the player, the AI doesn't goes back to patrolling the path.
                    _stateMachine.Pursuit(_target, _controlledEnemy.Agent); // I start the chase here, so the current state changes to pursuit.
                }
            } //When you find someone pursuit
            else if (_target != null && _stateMachine.CurrentState == StateMachineComponent.State.Pursuit)
            {
                // The AI will chase the character
                _stateMachine.Pursuit(_target, _controlledEnemy.Agent);
            }
            // Just checking if the player went to far from its initial position.
            // Pursuit -> Fallback
            if (_stateMachine.CurrentState == StateMachineComponent.State.Pursuit &&
                _stateMachine.IsTooFarFromInit(_controlledEnemy.transform.position, // AI current position
                _controlledEnemy.InitialPosition, // AI initial position
                _controlledEnemy.Information.AI.MaxTravelDistance)) // How far can the AI go from its initial position
            {
                _stateMachine.FallBack(_controlledEnemy.InitialPosition, _controlledEnemy.Agent);
            }
            // If the AI returned to the initial position then the AI should return to pursuit the target if the target still exist.
            // Else just return to patrol
            //            -> Pursuit
            // Fallback -|
            //            -> Patrol
            if (_stateMachine.CurrentState == StateMachineComponent.State.Fallback && _stateMachine.DidReturnedToInitPos(_controlledEnemy.InitialPosition, _controlledEnemy.Agent))
            {
                if (_target != null)
                {
                    _stateMachine.Pursuit(_target, _controlledEnemy.Agent);
                }
                else
                {
                    _stateMachine.Patrol(_destinations, _controlledEnemy.Agent, _controlledEnemy.InitialPosition);
                }
            }
            //If the AI reach the target, then attack
            // Pursuit -> Engage
            if (_stateMachine.CurrentState == StateMachineComponent.State.Pursuit && _controlledEnemy.Agent.velocity.magnitude == 0)
            {
                if(_target)
                {
                    _stateMachine.Engage(_target.Stats, _controlledEnemy.Agent, _controlledEnemy);
                }
            }
            // If the target starts to move away then, starts to pursuit
            // Engage -> Pursuit
            if (_stateMachine.CurrentState == StateMachineComponent.State.Engage && _controlledEnemy.IsFarFromTheTarget(_target.transform.position))
            {
                if (_target)
                {
                    _stateMachine.Pursuit(_target, _controlledEnemy.Agent);
                }
            }


        }

    }

    private void OnDestroy()
    {
        _target = null;
        _controlledEnemy = null;
    }

}

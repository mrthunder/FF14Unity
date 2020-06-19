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
    

    public void AssignControlledEnemy(Enemy enemy)
    {
        if(_controlledEnemy ==null)
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
        if(_controlledEnemy)
        {
            transform.position = _controlledEnemy.transform.position;
            _stateMachine.Patrol(_destinations, _controlledEnemy.Agent, _controlledEnemy.InitialPosition);

            const int CHARACTER_LAYER_MASK = (1 << 8);
            if(_stateMachine.DidDetectATarget<Character>(_controlledEnemy.transform.position,
                _controlledEnemy.transform.forward,
                _controlledEnemy.Information.AI.PerceptionSphereRadius,
                _controlledEnemy.Information.AI.PerceptionConeAngle,
                CHARACTER_LAYER_MASK,
                out Character character))
            {
                Debug.Log($"I found you {character.name}");
            }
        }
        
    }
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
    } 
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Debug;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public EnemyInformation Information = null;
    private NavMeshAgent _agent = null;

    /// <summary>
    /// The enemy needs to know its initial position to go back as soon as it goes to far from it.
    /// </summary>
    private Vector3 _initialPosition = Vector3.zero;

    public float DistanceFromStart => Vector3.Distance(transform.position, _initialPosition);
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        SetAgentInformation(_agent, Information);
    }

    private void SetAgentInformation(NavMeshAgent agent, EnemyInformation information)
    {
        agent.stoppingDistance = information.AI.StopDistance;
        agent.speed = information.AI.Speed;
        agent.height = information.AI.Height;
        agent.radius = information.AI.Radius;
    }

    public void Follow(Vector3 destination)
    {
        if(!_agent.SetDestination(destination))
        {
            _agent.isStopped = true;
        }else if (_agent.isStopped)
        {
            _agent.isStopped = false;
        }
    }

    public void StopMoving()
    {
        _agent.isStopped = true;
    }

    public void Attack(Character target)
    {
        //Will be reducing the damage
        Log("Attack!!!");
    }

    public float DistanceFromTarget(Vector3 targetPosition) => Vector3.Distance(transform.position, targetPosition);

}

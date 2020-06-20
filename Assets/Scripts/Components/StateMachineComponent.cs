using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineComponent : MonoBehaviour
{
    public enum State { Patrol, Pursuit, Engage, Fallback };
    private int _currentDestinationIndex = 0;
    private float _timer = 0;
    private State _currentState = State.Patrol;
    public State CurrentState => _currentState;

    /// <summary>
    /// This is just so I can keep an eye on the current state.
    /// </summary>
    private void SetCurrentState(State newState)
    {
        if (CurrentState != newState)
        {
            _currentState = newState;
        }
    }

    /// <summary>
    /// The character will walk following a path in a loop.
    /// </summary>
    public void Patrol(in List<Vector3> patrolDestinations, in NavMeshAgent agent, in Vector3 initialPosition)
    {
        if (agent)
        {
            if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.velocity.magnitude == 0 && _timer + 2f < Time.time)
            {
                SetCurrentState(State.Patrol);
                var worldPosition = initialPosition + patrolDestinations[_currentDestinationIndex];
                if (agent.SetDestination(worldPosition))
                {
                    _currentDestinationIndex = (_currentDestinationIndex + 1) % patrolDestinations.Count;
                    _timer = Time.time;
                }
                else
                {
                    Debug.Log("Fail");
                }

            }
        }
    }

    /// <summary>
    /// The AI starts following the target
    /// </summary>
    /// <param name="targetLocation">the target's location</param>
    /// <param name="agent">the agent that moves the ai</param>
    public void Pursuit<T>(in T target, in NavMeshAgent agent) where T: Component
    {
        if (agent)
        {
            SetCurrentState(State.Pursuit);
            agent.SetDestination(target.transform.position);
        }
    }

    /// <summary>
    /// Attacks the target
    /// </summary>
    /// <param name="target">Who are you attacking?</param>
    public void Engage<T>(T target)
    {
        SetCurrentState(State.Engage);
        // while the nav mesh agent is stop
        // Attack target 
        // The attack should tell if it can attack or not based on the distance
    }

    /// <summary>
    /// When you are too far you need to return to its initial position
    /// </summary>
    public void FallBack(Vector3 initialPosition, in NavMeshAgent agent)
    {
        if (agent && agent.destination != initialPosition)
        {
            SetCurrentState(State.Fallback);
            agent.SetDestination(initialPosition);
        }
    }

    /// <summary>
    /// Did the AI returned to the initial position while fall backing?
    /// </summary>
    /// <param name="initialPosition">The position where the ai was spawn</param>
    /// <param name="agent">the nav mesh agent that is controlling the ai</param>
    /// <returns>if returns or not. Look at the logs, if the result is false.</returns>
    public bool DidReturnedToInitPos(in Vector3 initialPosition, in NavMeshAgent agent)
    {
        if(agent && CurrentState == State.Fallback)
        {
            // This is just checking if the agent stopped at the initial position or close to it, since it can stop early if set the stopping distance.
            return agent.pathStatus == NavMeshPathStatus.PathComplete && agent.velocity.magnitude == 0 && Vector3.Distance(agent.transform.position, initialPosition) <= agent.stoppingDistance;
        }else
        {
            // I cannot check if the agent is not set or the state is not fall back.
            Debug.LogError("Fail checking the state of the nav mesh agent");
        }
        return false;
    }

    /// <summary>
    /// I will check the surroundings to see if anything gets in radius. 
    /// If it does, then I check if this thing is on its field of view. If it can see, I will check if it is the intended target.
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    /// <param name="from">Your position</param>
    /// <param name="radius">Sphere Detection Radius</param>
    /// <param name="angle">Field of view angle</param>
    /// <param name="layerMask">Target's layer mask</param>
    /// <param name="target">Out target detected</param>
    /// <returns>If the target got detected</returns>
    public bool DidDetectATarget<T>(Vector3 from, Vector3 forward, float radius, float angle, int layerMask, out T target) where T : Component
    {
        Collider[] results = new Collider[5];
        target = null;
        if (Physics.OverlapSphereNonAlloc(from, radius, results, layerMask) > 0)
        {
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] != null && IsOnFieldOfView(forward, from - results[i].transform.position, angle))
                {
                    target = results[i].GetComponent<T>();
                    if (target != null)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool IsOnFieldOfView(Vector3 from, Vector3 targetPosition, float angle)
    {
        // The reason why I am using half of the angle and not the full angle, it is because I am checking from the centre of the character the angle.
        //      \  |  /
        //       \ | /
        //        \|/
        //_________0__________ 
        // To get the angle from both sides I just divided by 2. This function won't return me from which side the target was detected, so the value will be either
        // half of the angle or less then half of the angle
        var to = from - targetPosition;
        return Vector3.Angle(from, to) <= angle / 2;
    }


    /// <summary>
    /// Have the AI move to far from the start?
    /// </summary>
    /// <param name="currentPosition">Where the AI is right now?</param>
    /// <param name="InitialPosition">Where the AI started?</param>
    /// <param name="maxDistance">How far can it go?</param>
    /// <returns>If is too far or not</returns>
    public bool IsTooFarFromInit(in Vector3 currentPosition,in Vector3 InitialPosition, in float maxDistance)
    {
        return Vector3.Distance(currentPosition, InitialPosition) > maxDistance;
    }


}

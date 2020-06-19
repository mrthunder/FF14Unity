using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineComponent : MonoBehaviour
{
    private int _currentDestinationIndex = 0;
    private float _timer = 0;

    /// <summary>
    /// The character will walk following a path in a loop.
    /// </summary>
    public void Patrol(in List<Vector3> patrolDestinations, in NavMeshAgent agent, in Vector3 initialPosition)
    {
        if(agent)
        {
            if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.velocity.magnitude ==0 && _timer + 2f < Time.time)
            {
                var worldPosition = initialPosition + patrolDestinations[_currentDestinationIndex];
                if(agent.SetDestination(worldPosition))
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
    public void Persuit(Vector3 targetLocation, in NavMeshAgent agent)
    {
        if(agent)
        {
            agent.SetDestination(targetLocation);
        }
    }

    /// <summary>
    /// Attacks the target
    /// </summary>
    /// <param name="target">Who are you attacking?</param>
    public void Engage<T>(T target)
    {
        // while the nav mesh agent is stop
        // Attack target 
        // The attack should tell if it can attack or not based on the distance
    }

    /// <summary>
    /// When you are too far you need to return to its initial position
    /// </summary>
    public void FallBack(Vector3 initialPosition, in NavMeshAgent agent)
    {
        if(agent && agent.destination != initialPosition)
        {
            agent.SetDestination(initialPosition);
        }
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
    public bool DidDetectATarget<T>(Vector3 from,Vector3 forward, float radius, float angle, int layerMask, out T target) where T : Component
    {
        Collider[] results = new Collider[5];
        target = null;
        if(Physics.OverlapSphereNonAlloc(from, radius, results, layerMask) > 0)
        {
            for (int i = 0; i < results.Length; i++)
            {
                if(results[i] !=null && IsOnFieldOfView(forward,from - results[i].transform.position,angle))
                {
                    target = results[i].GetComponent<T>();
                    if(target != null)
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
        return Vector3.Angle(from,to) <= angle/2;
    }


    /// <summary>
    /// Have the AI move to far from the start?
    /// </summary>
    /// <param name="currentPosition">Where the AI is right now?</param>
    /// <param name="InitialPosition">Where the AI started?</param>
    /// <param name="maxDistance">How far can it go?</param>
    /// <returns>If is too far or not</returns>
    public bool IsTooFarFromInit(Vector3 currentPosition, Vector3 InitialPosition, float maxDistance)
    {
        return Vector3.Distance(currentPosition, InitialPosition) > maxDistance;
    }


}

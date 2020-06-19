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
    public NavMeshAgent Agent => _agent;

    /// <summary>
    /// The enemy needs to know its initial position to go back as soon as it goes to far from it.
    /// </summary>
    private Vector3 _initialPosition = Vector3.zero;
    public Vector3 InitialPosition => _initialPosition;

    public float DistanceFromStart => Vector3.Distance(transform.position, _initialPosition);

    private void Awake()
    {
        // Spawn brain
        GameObject go = new GameObject($"{name} - AI Controller");
        var brain = go.AddComponent<AIEnemyController>();
        // Assign brain
        brain.AssignControlledEnemy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _agent = GetComponent<NavMeshAgent>();
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
        if (!_agent.SetDestination(destination))
        {
            _agent.isStopped = true;
        }
        else if (_agent.isStopped)
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

    public Vector3 GetWorldPosition(Vector3 local)
    {
        return _initialPosition + local;
    }

    public float DistanceFromTarget(Vector3 targetPosition) => Vector3.Distance(transform.position, targetPosition);

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        DrawPerceptionGizmo();
        DrawPatrolPaths();
    }

    private void DrawPerceptionGizmo()
    {
        //Field of View
        if (Information != null)
        {
            Gizmos.color = Color.red;
            UnityEditor.Handles.color = new Color(1, 0, 0, .1f);
            var startPosition = transform.position + new Vector3(0, Information.AI.Height / 2, 0);
            var normal = Vector3.up;
            var from = transform.forward;
            var angle = Information.AI.PerceptionConeAngle / 2;
            var radius = Information.AI.PerceptionSphereRadius;
            UnityEditor.Handles.DrawSolidArc(startPosition, normal, from, angle, radius);
            UnityEditor.Handles.DrawSolidArc(startPosition, normal, from, -angle, radius);
            Gizmos.DrawWireSphere(startPosition, radius);
        }
    }

    private void DrawPatrolPaths()
    {
        if(Information!=null && Information.Settings.Destinations!= null)
        {
            for (int i = 0; i < Information.Settings.Destinations.Count; i++)
            {

                Vector3 from = Application.isPlaying?GetWorldPosition(Information.Settings.Destinations[i]):transform.TransformPoint(Information.Settings.Destinations[i]);
                Gizmos.DrawSphere(from, .1f);
                Vector3 to = Application.isPlaying ? GetWorldPosition(Information.Settings.Destinations[0]) : transform.TransformPoint(Information.Settings.Destinations[0]);
                if (i < Information.Settings.Destinations.Count - 1)
                {
                    to = Application.isPlaying ? GetWorldPosition(Information.Settings.Destinations[i+1]) : transform.TransformPoint(Information.Settings.Destinations[i+1]);
                }
                Gizmos.DrawLine(from, to);
            }
        }
    }
#endif

}

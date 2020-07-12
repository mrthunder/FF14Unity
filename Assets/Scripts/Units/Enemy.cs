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
    public StatsComponent Stats = null;

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

    public void StopMoving() => _agent.isStopped = true;

    public void Attack(StatsComponent target)
    {
        if(Information.SkillSet != null && Information.SkillSet.SkillTable.Count >0)
        {
            Information.SkillSet.SkillTable["Unique"]?.StartCasting(Stats,target);
        }
    }

    private void Update()
    {
        if (Information.SkillSet != null)
        {
            foreach (KeyValuePair<string, Skill> pair in Information.SkillSet.SkillTable)
            {
                // That is null because the enemy does not have any input
                pair.Value.SkillUpdate(null);
            } 
        }
    }

    public Vector3 GetWorldPosition(Vector3 local) => _initialPosition + local;

    public bool IsFarFromTheTarget(Vector3 targetPosition) => Vector3.Distance(transform.position, targetPosition) > Information.AI.StopDistance;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        DrawPerceptionGizmo(Color.red);
        DrawPatrolPaths(Color.green);
        DrawTravelDistance(Color.magenta);
    }

    private void DrawPerceptionGizmo(Color color)
    {
        //Field of View
        if (Information != null)
        {
            Gizmos.color = color;
            UnityEditor.Handles.color = color - new Color(0, 0, 0, .9f);
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

    private void DrawPatrolPaths(Color color)
    {
        if(Information!=null && Information.Settings.Destinations!= null)
        {
            for (int i = 0; i < Information.Settings.Destinations.Count; i++)
            {
                Gizmos.color = color;
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

    private void DrawTravelDistance(Color color)
    {
        if(Information != null)
        {
            Vector3 centre = transform.position;
            if(Application.isPlaying)
            {
                centre = InitialPosition;
            }
            float radius = Information.AI.MaxTravelDistance;
            Gizmos.color = color;
            Gizmos.DrawWireSphere(centre, radius);
        }
    }
#endif

}

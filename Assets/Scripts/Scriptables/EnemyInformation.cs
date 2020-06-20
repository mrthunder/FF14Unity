using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyInformation : ScriptableObject
{
    [System.Serializable]
    public struct AISetting
    {
        /// <summary>
        /// The size of the bubble that will detect a player
        /// </summary>
        public float PerceptionSphereRadius;

        /// <summary>
        /// The total angle of the cone or field of view of the ai.
        /// </summary>
        public float PerceptionConeAngle;

        /// <summary>
        /// How far can this enemy travel until it gets back to its initial position
        /// </summary>
        public float MaxTravelDistance;

        /// <summary>
        /// How far from the player will the enemy stop to attack
        /// </summary>
        public float StopDistance;

        /// <summary>
        /// How fast does this ai moves
        /// </summary>
        public float Speed;

        public float Height;

        public float Radius;
    }
    [System.Serializable]
    public struct PatrolSettings
    {
        public List<Vector3> Destinations;
    }

    [Header("AI Settings")]
    public AISetting AI;

    [Space(2f), Header("State Machine")]
    [Header("Patrol")]
    public PatrolSettings Settings;
}

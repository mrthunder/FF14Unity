using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineComponent : MonoBehaviour
{

    public void Patrol()
    {

    }

    public void Persuit()
    {

    }

    public void Engage()
    {

    }

    public void FallBack()
    {

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
    public bool DidDetectATarget<T>(Vector3 from, float radius, float angle, int layerMask, out T target) where T : Component
    {
        Collider[] results = new Collider[5];
        target = null;
        if(Physics.OverlapSphereNonAlloc(from, radius, results, layerMask) > 0)
        {
            for (int i = 0; i < results.Length; i++)
            {
                if(IsOnFieldOfView(from, results[i].transform.position,angle))
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
        var to = targetPosition - from;
        return Vector3.Angle(from,to) <= angle/2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyController : MonoBehaviour
{
    [SerializeField]
    private Enemy _controlledEnemy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(_controlledEnemy)
        {
            transform.position = _controlledEnemy.transform.position;
        }
    }
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        //Field of View
        if (_controlledEnemy != null && _controlledEnemy.Information != null)
        {
            Gizmos.color = Color.red;
            UnityEditor.Handles.color = new Color(1,0,0,.1f);
            var startPosition = _controlledEnemy.transform.position + new Vector3(0, _controlledEnemy.Information.AI.Height / 2, 0);
            var normal = Vector3.up;
            var from = _controlledEnemy.transform.forward;
            var angle = _controlledEnemy.Information.AI.PerceptionConeAngle / 2;
            var radius = _controlledEnemy.Information.AI.PerceptionSphereRadius;
            UnityEditor.Handles.DrawSolidArc(startPosition, normal, from, angle, radius);
            UnityEditor.Handles.DrawSolidArc(startPosition, normal, from, -angle, radius);
            Gizmos.DrawWireSphere(startPosition, radius);
        }
    } 
#endif
}

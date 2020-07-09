﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionComponent))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementComponent _movementComponent = null;
    public PlayerMovementComponent MovementComponent => _movementComponent;
    [SerializeField]
    private StatsComponent _stats = null;
    public StatsComponent Stats => _stats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.Debug;

public class PlayerMovementComponent : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField]
    private float _speed = 2f;

    [SerializeField]
    private Rigidbody _rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(_rigidbody);
    }
   

    public void NormalMovement(Vector2 movementInput,float strafeInput, bool isMouseControllingRotation)
    {
        Vector3 movementDirection = new Vector3(movementInput.x, 0, movementInput.y);
        if (!isMouseControllingRotation)
        {
            // Turning either left or right
            transform.Rotate(Vector3.up, movementInput.x);
            // I am converting the input from a vector 2 to a 3. Where y is equal to the z axis
            movementDirection.x = strafeInput; 
        }
        Vector3 characterDirection = transform.TransformDirection(movementDirection);
        // This is the actual speed based on the game loop
        float deltaSpeed = _speed;//* Time.deltaTime*1000;
        // The velocity is just the direction times the speed.
        Vector3 movementVelocity = characterDirection * deltaSpeed;
        //I am making the y speed from the new velocity the same as the current velocity
        movementVelocity.y = _rigidbody.velocity.y;
        // Assigning the new velocity
        _rigidbody.velocity = movementVelocity;
    }

    public void RotateCharacterWithMouse(Vector2 mouseDelta)
    {
        transform.localEulerAngles += (Vector3.up * mouseDelta.x);
    }

    

    public void AroundTargetMovement(Vector2 input,float strafeInput)
    {
        Vector3 movementDirection = new Vector3(input.x, 0, input.y);
        if(strafeInput != 0)
        {
            movementDirection.x = strafeInput;
        }
        Vector3 characterDirection = transform.TransformDirection(movementDirection);
        // This is the actual speed based on the game loop
        float deltaSpeed = _speed;//* Time.deltaTime*1000;
        // The velocity is just the direction times the speed.
        Vector3 movementVelocity = characterDirection * deltaSpeed;
        //I am making the y speed from the new velocity the same as the current velocity
        movementVelocity.y = _rigidbody.velocity.y;
        // Assigning the new velocity
        _rigidbody.velocity = movementVelocity;
    }

    public void FocusOn(SelectionComponent target)
    {
        if (target == null) return;
        //transform.LookAt(target.transform,Vector3.up);
        //var localRotation = transform.localEulerAngles;
        //localRotation.x = 0;
        //localRotation.z = 0;
        //transform.localEulerAngles = localRotation;

        Vector3 forward = target.transform.position - transform.position;
        Vector3 lookRotation = Quaternion.LookRotation(forward).eulerAngles;
        lookRotation.x = 0;
        lookRotation.z = 0;
        transform.eulerAngles = lookRotation;
    }
}

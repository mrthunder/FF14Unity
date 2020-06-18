using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// This is the character controlled by the player controller.
    /// </summary>
    [SerializeField]
    private Character _controlledCharacter = null;
    // This returns a reference of the player character being controlled by the player controller.
    public Character ControlledCharacter => _controlledCharacter;
    [SerializeField]
    private TargetComponent _targetComponent = null;

    /// <summary>
    /// This is main camera that should be parented to the player controller.
    /// </summary>
    [SerializeField]
    private Camera _mainCamera = null;

    //Rotation
    /// <summary>
    /// Essentially, this prevents the camera from having a weird rotation, when I move the mouse across the screen.
    /// </summary>
    [SerializeField]
    private Transform _horizontalAxis = null;
    [SerializeField]
    private Transform _verticalAxis = null;
    [SerializeField]
    private Vector2 _minAndMaxVerticalEAngles = new Vector2(90, 340);

    public bool IsCameraLocked = false;
    [SerializeField,Range(0f,1f)]
    private float _smoothValue = .5f;

    // Is the player controller following the character's rotation?
    private bool _isPCRotationLocked = false;
    private bool AmIControllingTheCamera = false;

    //Input System
    private FFInputActions _ffInputActions;

    private bool IsMouseLeftButtonDown => _ffInputActions.Game.MouseLeftClick.ReadValue<float>() == 1;
    private bool IsMouseRightButtonDown => _ffInputActions.Game.MouseRightClick.ReadValue<float>() == 1;

    private void Awake()
    {
        _ffInputActions = new FFInputActions();
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        // if the character was not assigned on the inspector
        if (_controlledCharacter == null)
        {
            // then I will try to find it on the scene.
            _controlledCharacter = FindObjectOfType<Character>();
            if (_controlledCharacter == null)
            {
                // if the character is nowhere to be found, then display error message
                Debug.LogError("There is no character in the scene. Please add one.");
            }
        }
    }

    private void OnEnable()
    {
        _ffInputActions.Enable();
    }

    private void OnDisable()
    {
        _ffInputActions.Disable();
    }

    private void LateUpdate()
    {
        // Something that I notice that happens with FF14 is that the player controller follows the character rotation
        // and so the camera. However, when the left mouse click, the camera rotates freely from the character rotation,
        // but the character continues follow its own directions.
        CameraFunctions();
        MoveCharacter();
        // The player controller will be following the character where ever it goes. No only, but it will also follow the player's rotation.
        FollowPlayer();
    }

    private void MoveCharacter()
    {
        Vector2 input = _ffInputActions.Game.Movement.ReadValue<Vector2>();
        float strafeInput = _ffInputActions.Game.Strafe.ReadValue<float>();
        if (_targetComponent.IsTargetFocused)
        {
            _controlledCharacter.MovementComponent.FocusOn(_targetComponent.ObjectSelected);
            ControlledCharacter.MovementComponent.AroundTargetMovement(input, strafeInput);
        }
        else
        {
            ControlledCharacter.MovementComponent.NormalMovement(input, strafeInput, (AmIControllingTheCamera));
        }
    }

    /// <summary>
    /// This takes cares of what happens with the camera when the player presses or hold a button.
    /// </summary>
    private void CameraFunctions()
    {


        // This is just so I can have a on mouse hold / down equivalent. If their is one better than this, I'll change.
        //When the value is 1 it means that the mouse is pressed and holding. Zero means released.
        // 
        if(_targetComponent.IsTargetFocused)
        {
            AmIControllingTheCamera = false;
            _isPCRotationLocked = true;
            _horizontalAxis.transform.localEulerAngles = Vector3.zero;
        }
        else if (IsMouseLeftButtonDown && !IsMouseRightButtonDown)
        {
            RotateCamera(true);
            _isPCRotationLocked = false;
            AmIControllingTheCamera = false;
        }
        else if (!IsMouseLeftButtonDown && IsMouseRightButtonDown)
        {
            // When the left mouse is down, the main camera just follows the player controller.
            _horizontalAxis.transform.localEulerAngles = Vector3.zero;
            RotateCamera(false);
            _controlledCharacter.MovementComponent.RotateCharacterWithMouse(_ffInputActions.Game.MousePositionDelta.ReadValue<Vector2>());
            _isPCRotationLocked = true;
            AmIControllingTheCamera = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            AmIControllingTheCamera = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _isPCRotationLocked = true;
        }
      

    }

    private void RotateCamera(bool isRotatingHorizontal)
    {
        if (_mainCamera != null && _horizontalAxis != null && _verticalAxis != null)
        {
            // The new Input System already provides the mouse position delta.
            Vector2 deltaPosition = _ffInputActions.Game.MousePositionDelta.ReadValue<Vector2>();

            if (isRotatingHorizontal)
            {
                // Horizontal
                _horizontalAxis.localEulerAngles += (Vector3.up * deltaPosition.x); 
            }

            // Vertical - I naturally set as inverted
            _verticalAxis.localEulerAngles -= (Vector3.right * deltaPosition.y);

            // Checking if the mouse rotation is not going beyond boundaries.
            var localRotation = _verticalAxis.localEulerAngles;
            if (localRotation.x > _minAndMaxVerticalEAngles.x && localRotation.x <= 180f) // Looking down
            {

                localRotation.x = _minAndMaxVerticalEAngles.x;
            }
            else if (localRotation.x > 180f && localRotation.x < _minAndMaxVerticalEAngles.y) // Looking Up
            {
                localRotation.x = _minAndMaxVerticalEAngles.y;
            }
            //The vertical axis game object was getting upside down. Upon observation, the y and z rotation were changing.
            // So to make sure those values would keep the same, I set them below.
            localRotation.y = 0;
            localRotation.z = 0;
            _verticalAxis.localEulerAngles = localRotation;
        }
        else
        {
            Debug.LogError("Either the main camera was not set on the inspector or the Axis");
        }
    }

    private void FollowPlayer()
    {
        if (_controlledCharacter != null)
        {
            transform.position = Vector3.Lerp(transform.position,_controlledCharacter.transform.position,_smoothValue);
            if (_isPCRotationLocked)
            {
                transform.rotation = _controlledCharacter.transform.rotation; 
            }
        }
    }
}

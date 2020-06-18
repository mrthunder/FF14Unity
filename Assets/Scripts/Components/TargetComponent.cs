using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetComponent : MonoBehaviour
{
    // This is the object that is selected
    private SelectionComponent _objectSelected;
    public SelectionComponent ObjectSelected => _objectSelected;
    [SerializeField]
    private bool _isTargetFocused = false;
    public bool IsTargetFocused => _isTargetFocused;

    // I use the main camera to convert the mouse position on screen to a ray
    [SerializeField]
    private Camera _mainCamera = null;

    // I am going to test the generated class from the input action obj
    private FFInputActions _ffInputActions = null;


    private void Awake()
    {
        _ffInputActions = new FFInputActions();
        _ffInputActions.Game.MouseLeftClick.performed += _ =>
        {
            Select();
        };
        _ffInputActions.Game.SetFocusTarget.performed += _ =>
         {
             if (_objectSelected != null)
             {
                 _isTargetFocused = !_isTargetFocused;
                 if (_isTargetFocused)
                 {
                     _objectSelected.Focus();
                 }
                 else
                 {
                     _objectSelected.Unfocus();
                 } 
             }
         };
    }

    // Start is called before the first frame update
    void Start()
    {
        // I need the main camera to make this selection work. That is why I am asserting on start.
        Debug.Assert(_mainCamera);
    }

    private void OnEnable()
    {
        // This line makes sure that the input will be register when the component is enable
        _ffInputActions.Enable();
    }

    private void OnDisable()
    {
        // This line makes sure that the input will not be register when the component is not enable
        _ffInputActions.Disable();
    }

    private void Select()
    {
        //Creates a ray from the mouse position to the camera's forward
        Vector2 mouseScreenPosition = _ffInputActions.Game.MousePosition.ReadValue<Vector2>();
        Ray ray = _mainCamera.ScreenPointToRay(mouseScreenPosition);
        //I will only save 5 of the results in this array
        RaycastHit[] results = new RaycastHit[5];
        int resultsCount = Physics.RaycastNonAlloc(ray, results, 100f);
        //I need to check if the ray hits anything
        if (resultsCount > 0)
        {
            bool DidSelectedSomething = false;
            // I am going through the objects checking if any of them has a selection component.
            foreach (var result in results)
            {
                if (result.collider != null)
                {
                    // I am creating the out parameter inline, in case the try function fails, the parameter does not get allocated.
                    if (result.collider.gameObject.TryGetComponent(out SelectionComponent obj))
                    {
                        // I am just replacing the object that was select with the new one, and 
                        // notifying the old one that is being unselected.

                        _objectSelected?.Unselect();
                        _objectSelected = obj;
                        _objectSelected.Select();

                        DidSelectedSomething = true;
                        break;
                    }
                }
            }
            // Nothing was selected, then just unselected what was already selected
            if (DidSelectedSomething == false)
            {
                _objectSelected?.Unselect();
                _objectSelected = null;
                _isTargetFocused = false;
            }
        }
        else
        {
            // Nothing was selected, then just unselected what was already selected
            _objectSelected?.Unselect();
            _objectSelected = null;
            _isTargetFocused = false;
        }
    }


}

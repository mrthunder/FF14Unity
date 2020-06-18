// GENERATED AUTOMATICALLY FROM 'Assets/Settings/FFInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FFInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FFInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FFInputActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""5cdd6877-caaa-430b-9c44-f59078ea7565"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""3a009819-cbd5-4370-b3d7-f0813a58f6ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""88883cde-5f0e-4df4-8f52-d11b9468699b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4bb59758-cc20-49dd-8460-9185d7012e00"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePositionDelta"",
                    ""type"": ""Value"",
                    ""id"": ""81776500-c16e-4576-93fa-494fa5e2b058"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""6f42ed4b-c067-4150-8b1c-20e93d8004f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""773c8172-9256-405b-9994-92539fce0515"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseRightClick"",
                    ""type"": ""Button"",
                    ""id"": ""23229fdd-243f-4b54-8100-f9849b80de52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Strafe"",
                    ""type"": ""Value"",
                    ""id"": ""1e71f886-b53f-4795-bcb7-11718443bf4b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""81241513-224d-4790-be70-6fc8d5633c33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleThroughEnemies"",
                    ""type"": ""Button"",
                    ""id"": ""1126db75-cf7b-4f03-9ef8-98ce9b322f4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SetFocusTarget"",
                    ""type"": ""Button"",
                    ""id"": ""875b307a-80c4-4a17-baf3-c03f21d60b4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""605795f2-a1d9-44b0-85d6-6e464b2db63e"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f1ed4cc-f083-4ac9-9554-1b1411e2d1ae"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5643fa96-ec5f-42c1-9622-162b4832cc06"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18b3961f-e61a-412d-ae4c-760064912436"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Directions"",
                    ""id"": ""5309392f-f167-4607-ab0f-cc81003b3b21"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""255dac0c-c1af-44b1-a777-e0c801a68357"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e50b9f75-6ed1-4c87-9c63-fed1105f1677"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cd584898-1b52-4b6a-8318-58df02f1994a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""abb15776-d843-403a-8857-563ec12c9fbe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""39212648-2490-4b04-bbbc-d57c2237b10c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc8b4813-954a-45cf-a7ce-154ae9435360"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MousePositionDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47a1eff9-209b-48b9-a4a0-2e3b2cb00e6b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""MousePositionDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""405863c0-ad07-440f-877c-36255da1d310"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MouseLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0deff51c-c5e9-4ee2-bd79-b7d2414137d6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ee76911-6c79-4459-a7a2-0b76e11e17b5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MouseRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""ceac0bd2-adea-45a4-958f-b50820220058"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1c557c95-df99-42ec-a088-379abe218057"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aa20f9da-6033-4373-b628-4e7d1e7d5293"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1996c877-392d-4076-a385-fc0629d90901"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1faad7bc-6fdc-4cc2-a164-e23c14413e1a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CycleThroughEnemies"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""85847221-5531-4dd9-a437-67871da0ed39"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetFocusTarget"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8b4e57f6-b69f-476b-8657-007291149b5c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SetFocusTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""8fa4070a-2311-4659-881b-d9677a4a66fd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SetFocusTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Confirm = m_Game.FindAction("Confirm", throwIfNotFound: true);
        m_Game_Cancel = m_Game.FindAction("Cancel", throwIfNotFound: true);
        m_Game_Movement = m_Game.FindAction("Movement", throwIfNotFound: true);
        m_Game_MousePositionDelta = m_Game.FindAction("MousePositionDelta", throwIfNotFound: true);
        m_Game_MouseLeftClick = m_Game.FindAction("MouseLeftClick", throwIfNotFound: true);
        m_Game_MousePosition = m_Game.FindAction("MousePosition", throwIfNotFound: true);
        m_Game_MouseRightClick = m_Game.FindAction("MouseRightClick", throwIfNotFound: true);
        m_Game_Strafe = m_Game.FindAction("Strafe", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_CycleThroughEnemies = m_Game.FindAction("CycleThroughEnemies", throwIfNotFound: true);
        m_Game_SetFocusTarget = m_Game.FindAction("SetFocusTarget", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Confirm;
    private readonly InputAction m_Game_Cancel;
    private readonly InputAction m_Game_Movement;
    private readonly InputAction m_Game_MousePositionDelta;
    private readonly InputAction m_Game_MouseLeftClick;
    private readonly InputAction m_Game_MousePosition;
    private readonly InputAction m_Game_MouseRightClick;
    private readonly InputAction m_Game_Strafe;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_CycleThroughEnemies;
    private readonly InputAction m_Game_SetFocusTarget;
    public struct GameActions
    {
        private @FFInputActions m_Wrapper;
        public GameActions(@FFInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_Game_Confirm;
        public InputAction @Cancel => m_Wrapper.m_Game_Cancel;
        public InputAction @Movement => m_Wrapper.m_Game_Movement;
        public InputAction @MousePositionDelta => m_Wrapper.m_Game_MousePositionDelta;
        public InputAction @MouseLeftClick => m_Wrapper.m_Game_MouseLeftClick;
        public InputAction @MousePosition => m_Wrapper.m_Game_MousePosition;
        public InputAction @MouseRightClick => m_Wrapper.m_Game_MouseRightClick;
        public InputAction @Strafe => m_Wrapper.m_Game_Strafe;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputAction @CycleThroughEnemies => m_Wrapper.m_Game_CycleThroughEnemies;
        public InputAction @SetFocusTarget => m_Wrapper.m_Game_SetFocusTarget;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_GameActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnConfirm;
                @Cancel.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCancel;
                @Movement.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                @MousePositionDelta.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionDelta;
                @MousePositionDelta.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionDelta;
                @MousePositionDelta.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionDelta;
                @MouseLeftClick.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseLeftClick;
                @MousePosition.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePosition;
                @MouseRightClick.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseRightClick;
                @Strafe.started -= m_Wrapper.m_GameActionsCallbackInterface.OnStrafe;
                @Strafe.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnStrafe;
                @Strafe.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnStrafe;
                @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @CycleThroughEnemies.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleThroughEnemies;
                @CycleThroughEnemies.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleThroughEnemies;
                @CycleThroughEnemies.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCycleThroughEnemies;
                @SetFocusTarget.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSetFocusTarget;
                @SetFocusTarget.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSetFocusTarget;
                @SetFocusTarget.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSetFocusTarget;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MousePositionDelta.started += instance.OnMousePositionDelta;
                @MousePositionDelta.performed += instance.OnMousePositionDelta;
                @MousePositionDelta.canceled += instance.OnMousePositionDelta;
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseRightClick.started += instance.OnMouseRightClick;
                @MouseRightClick.performed += instance.OnMouseRightClick;
                @MouseRightClick.canceled += instance.OnMouseRightClick;
                @Strafe.started += instance.OnStrafe;
                @Strafe.performed += instance.OnStrafe;
                @Strafe.canceled += instance.OnStrafe;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @CycleThroughEnemies.started += instance.OnCycleThroughEnemies;
                @CycleThroughEnemies.performed += instance.OnCycleThroughEnemies;
                @CycleThroughEnemies.canceled += instance.OnCycleThroughEnemies;
                @SetFocusTarget.started += instance.OnSetFocusTarget;
                @SetFocusTarget.performed += instance.OnSetFocusTarget;
                @SetFocusTarget.canceled += instance.OnSetFocusTarget;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IGameActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMousePositionDelta(InputAction.CallbackContext context);
        void OnMouseLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnStrafe(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCycleThroughEnemies(InputAction.CallbackContext context);
        void OnSetFocusTarget(InputAction.CallbackContext context);
    }
}

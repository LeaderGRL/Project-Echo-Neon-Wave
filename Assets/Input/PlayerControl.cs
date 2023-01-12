// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c0fbe2a8-befd-4e7b-874c-b283f53cc56b"",
            ""actions"": [
                {
                    ""name"": ""FLDestroy"",
                    ""type"": ""Button"",
                    ""id"": ""1a30ffb7-3ead-49ec-be40-bd8b04cc0268"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LDestroy"",
                    ""type"": ""Button"",
                    ""id"": ""7c99d5c0-3446-45a0-8bad-17a4d7b09b4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RDestroy"",
                    ""type"": ""Button"",
                    ""id"": ""6b9326b5-76cb-4367-94f6-f8c8197357d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FRDestroy"",
                    ""type"": ""Button"",
                    ""id"": ""94cb9df2-78bf-411d-bb64-33c64d0c18b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightLaserMovement"",
                    ""type"": ""Value"",
                    ""id"": ""465d0dbf-1e4c-46ce-af29-520a597f1ac4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftLaserMovement"",
                    ""type"": ""Value"",
                    ""id"": ""b9fe4146-1286-4d6e-bc23-01b09727880a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f076e035-8f7d-4c92-a913-fe2b1279a93d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Tap,Press,Hold,SlowTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FLDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2969c423-6dd3-4356-ad0a-f234f08e375b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FLDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""RightLaser 1D Axis"",
                    ""id"": ""70f451b0-de45-4cba-a2bf-bc70e07a70de"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightLaserMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""78642df2-6420-4c00-8eee-d835c4caf681"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightLaserMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8c2de13d-15e0-47ad-953f-4a6140bbffba"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightLaserMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftLaser 1D Axis"",
                    ""id"": ""652d7b9a-3465-4dcc-bd17-d105a1944648"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftLaserMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""844971ab-2e79-4eee-a041-24fcfe465fc4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftLaserMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5b546d04-a323-4dbd-9171-27781ace5361"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftLaserMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""414f6526-4038-4b6d-8374-8c19d7daaa3b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Hold,Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36740b57-46ba-45c5-9f45-89a525271547"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd36cc98-ab67-4a7c-a5e7-7ffd0b80aa8a"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": ""Hold,Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cad27dd-8766-4d09-9984-7d380df80077"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dd863bb-c387-45cb-8fdb-736e2554d643"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Hold,Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FRDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f094cce-5c7e-4f73-aa0d-e698ad53ec5a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FRDestroy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_FLDestroy = m_Player.FindAction("FLDestroy", throwIfNotFound: true);
        m_Player_LDestroy = m_Player.FindAction("LDestroy", throwIfNotFound: true);
        m_Player_RDestroy = m_Player.FindAction("RDestroy", throwIfNotFound: true);
        m_Player_FRDestroy = m_Player.FindAction("FRDestroy", throwIfNotFound: true);
        m_Player_RightLaserMovement = m_Player.FindAction("RightLaserMovement", throwIfNotFound: true);
        m_Player_LeftLaserMovement = m_Player.FindAction("LeftLaserMovement", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_FLDestroy;
    private readonly InputAction m_Player_LDestroy;
    private readonly InputAction m_Player_RDestroy;
    private readonly InputAction m_Player_FRDestroy;
    private readonly InputAction m_Player_RightLaserMovement;
    private readonly InputAction m_Player_LeftLaserMovement;
    public struct PlayerActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @FLDestroy => m_Wrapper.m_Player_FLDestroy;
        public InputAction @LDestroy => m_Wrapper.m_Player_LDestroy;
        public InputAction @RDestroy => m_Wrapper.m_Player_RDestroy;
        public InputAction @FRDestroy => m_Wrapper.m_Player_FRDestroy;
        public InputAction @RightLaserMovement => m_Wrapper.m_Player_RightLaserMovement;
        public InputAction @LeftLaserMovement => m_Wrapper.m_Player_LeftLaserMovement;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @FLDestroy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFLDestroy;
                @FLDestroy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFLDestroy;
                @FLDestroy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFLDestroy;
                @LDestroy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLDestroy;
                @LDestroy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLDestroy;
                @LDestroy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLDestroy;
                @RDestroy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRDestroy;
                @RDestroy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRDestroy;
                @RDestroy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRDestroy;
                @FRDestroy.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFRDestroy;
                @FRDestroy.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFRDestroy;
                @FRDestroy.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFRDestroy;
                @RightLaserMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightLaserMovement;
                @RightLaserMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightLaserMovement;
                @RightLaserMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightLaserMovement;
                @LeftLaserMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftLaserMovement;
                @LeftLaserMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftLaserMovement;
                @LeftLaserMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftLaserMovement;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FLDestroy.started += instance.OnFLDestroy;
                @FLDestroy.performed += instance.OnFLDestroy;
                @FLDestroy.canceled += instance.OnFLDestroy;
                @LDestroy.started += instance.OnLDestroy;
                @LDestroy.performed += instance.OnLDestroy;
                @LDestroy.canceled += instance.OnLDestroy;
                @RDestroy.started += instance.OnRDestroy;
                @RDestroy.performed += instance.OnRDestroy;
                @RDestroy.canceled += instance.OnRDestroy;
                @FRDestroy.started += instance.OnFRDestroy;
                @FRDestroy.performed += instance.OnFRDestroy;
                @FRDestroy.canceled += instance.OnFRDestroy;
                @RightLaserMovement.started += instance.OnRightLaserMovement;
                @RightLaserMovement.performed += instance.OnRightLaserMovement;
                @RightLaserMovement.canceled += instance.OnRightLaserMovement;
                @LeftLaserMovement.started += instance.OnLeftLaserMovement;
                @LeftLaserMovement.performed += instance.OnLeftLaserMovement;
                @LeftLaserMovement.canceled += instance.OnLeftLaserMovement;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnFLDestroy(InputAction.CallbackContext context);
        void OnLDestroy(InputAction.CallbackContext context);
        void OnRDestroy(InputAction.CallbackContext context);
        void OnFRDestroy(InputAction.CallbackContext context);
        void OnRightLaserMovement(InputAction.CallbackContext context);
        void OnLeftLaserMovement(InputAction.CallbackContext context);
    }
}

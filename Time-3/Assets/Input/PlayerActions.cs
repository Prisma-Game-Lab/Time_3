// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""a9a5e93f-a581-4586-88c5-0b2f112c7e31"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a8932e7e-6887-4d30-aafd-1c3e79295f94"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hero 1"",
                    ""type"": ""Button"",
                    ""id"": ""750c0a03-6bc2-4df6-ad4b-4e3982f40bce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hero 2"",
                    ""type"": ""Button"",
                    ""id"": ""30e395a6-587d-48a0-8651-e8adfa172bd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hero 3"",
                    ""type"": ""Button"",
                    ""id"": ""546deadc-9a90-42c6-a668-d6884fad9a81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BasicAttack"",
                    ""type"": ""Button"",
                    ""id"": ""457f2828-5a26-4244-af22-429a555a9444"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CombatSkill"",
                    ""type"": ""Button"",
                    ""id"": ""b42bb68b-4add-4cd4-a03d-09c5c8fdbae9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExplorationSkill"",
                    ""type"": ""Button"",
                    ""id"": ""9e2f5d28-654f-4267-87d4-e2fcda2db863"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""bb9dc7b8-ecfd-4070-b7ca-cd33eadcb582"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""67823f30-a371-4a82-8193-0b045bc1584a"",
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
                    ""id"": ""12c8d29a-27a5-4ace-b702-9a36d59694fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6cb7080a-0911-4a7d-b70b-31b678594dbc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cf5f7d4d-7ea6-44f1-b9b0-10695384aa7e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d76e6e03-f625-49ce-b517-709ffecc8aef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""db9320e0-199d-48ae-922a-98dfef46faf0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""634a4f68-d0b8-40b3-b4e7-5b207fd02aca"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hero 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""775c5b62-5175-4b58-81c9-01e73f8ed6f6"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hero 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f491dce-1368-457d-9f6f-a57d73ac5cb6"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hero 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e62477ab-2fcb-47d8-80a6-28775459b76b"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hero 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac45a250-c2fc-48fe-8387-688bcac2c253"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hero 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3efa09e-e42a-4575-8409-52b0ce3d06a9"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hero 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a37ebfa6-9aba-461f-a5cd-dfc4b061974c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef57cbf9-da07-4965-a513-a17ea74c9cbd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""149c83b7-a913-4cb6-ad43-9f076c3782c3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombatSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""014d7e1f-da22-459f-bda6-834fbf330aa5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CombatSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1f36132-15f4-4e83-bfdf-5809358f17e5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExplorationSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed6e101c-b0ac-4623-8a1b-49cb900a5359"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExplorationSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f936d2db-9014-4f1a-874c-a0d4f8d5e11b"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34c4783e-2ed2-4989-b3e7-69017a842e31"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameControls"",
            ""id"": ""146e8960-826f-4874-ac17-f2bca24ee32a"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""59fa7bc4-616e-49b5-b9b0-a25942ffad3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59b091fd-06d2-489b-a1a2-40938104bb64"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2228be59-163f-4789-807d-af4fafdb40d3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Hero1 = m_PlayerControls.FindAction("Hero 1", throwIfNotFound: true);
        m_PlayerControls_Hero2 = m_PlayerControls.FindAction("Hero 2", throwIfNotFound: true);
        m_PlayerControls_Hero3 = m_PlayerControls.FindAction("Hero 3", throwIfNotFound: true);
        m_PlayerControls_BasicAttack = m_PlayerControls.FindAction("BasicAttack", throwIfNotFound: true);
        m_PlayerControls_CombatSkill = m_PlayerControls.FindAction("CombatSkill", throwIfNotFound: true);
        m_PlayerControls_ExplorationSkill = m_PlayerControls.FindAction("ExplorationSkill", throwIfNotFound: true);
        m_PlayerControls_Interact = m_PlayerControls.FindAction("Interact", throwIfNotFound: true);
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_Pause = m_GameControls.FindAction("Pause", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Hero1;
    private readonly InputAction m_PlayerControls_Hero2;
    private readonly InputAction m_PlayerControls_Hero3;
    private readonly InputAction m_PlayerControls_BasicAttack;
    private readonly InputAction m_PlayerControls_CombatSkill;
    private readonly InputAction m_PlayerControls_ExplorationSkill;
    private readonly InputAction m_PlayerControls_Interact;
    public struct PlayerControlsActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerControlsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Hero1 => m_Wrapper.m_PlayerControls_Hero1;
        public InputAction @Hero2 => m_Wrapper.m_PlayerControls_Hero2;
        public InputAction @Hero3 => m_Wrapper.m_PlayerControls_Hero3;
        public InputAction @BasicAttack => m_Wrapper.m_PlayerControls_BasicAttack;
        public InputAction @CombatSkill => m_Wrapper.m_PlayerControls_CombatSkill;
        public InputAction @ExplorationSkill => m_Wrapper.m_PlayerControls_ExplorationSkill;
        public InputAction @Interact => m_Wrapper.m_PlayerControls_Interact;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Hero1.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero1;
                @Hero1.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero1;
                @Hero1.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero1;
                @Hero2.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero2;
                @Hero2.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero2;
                @Hero2.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero2;
                @Hero3.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero3;
                @Hero3.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero3;
                @Hero3.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHero3;
                @BasicAttack.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnBasicAttack;
                @CombatSkill.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCombatSkill;
                @CombatSkill.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCombatSkill;
                @CombatSkill.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCombatSkill;
                @ExplorationSkill.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExplorationSkill;
                @ExplorationSkill.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExplorationSkill;
                @ExplorationSkill.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExplorationSkill;
                @Interact.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Hero1.started += instance.OnHero1;
                @Hero1.performed += instance.OnHero1;
                @Hero1.canceled += instance.OnHero1;
                @Hero2.started += instance.OnHero2;
                @Hero2.performed += instance.OnHero2;
                @Hero2.canceled += instance.OnHero2;
                @Hero3.started += instance.OnHero3;
                @Hero3.performed += instance.OnHero3;
                @Hero3.canceled += instance.OnHero3;
                @BasicAttack.started += instance.OnBasicAttack;
                @BasicAttack.performed += instance.OnBasicAttack;
                @BasicAttack.canceled += instance.OnBasicAttack;
                @CombatSkill.started += instance.OnCombatSkill;
                @CombatSkill.performed += instance.OnCombatSkill;
                @CombatSkill.canceled += instance.OnCombatSkill;
                @ExplorationSkill.started += instance.OnExplorationSkill;
                @ExplorationSkill.performed += instance.OnExplorationSkill;
                @ExplorationSkill.canceled += instance.OnExplorationSkill;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // GameControls
    private readonly InputActionMap m_GameControls;
    private IGameControlsActions m_GameControlsActionsCallbackInterface;
    private readonly InputAction m_GameControls_Pause;
    public struct GameControlsActions
    {
        private @PlayerActions m_Wrapper;
        public GameControlsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnHero1(InputAction.CallbackContext context);
        void OnHero2(InputAction.CallbackContext context);
        void OnHero3(InputAction.CallbackContext context);
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnCombatSkill(InputAction.CallbackContext context);
        void OnExplorationSkill(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IGameControlsActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}

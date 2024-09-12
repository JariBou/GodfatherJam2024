//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_project/Input/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""ce9fa691-7eb9-4e7b-8c07-6e42568dd062"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e870c0b9-cb60-4694-982e-dd8c51bd1fe1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Random Red Walls"",
                    ""type"": ""Button"",
                    ""id"": ""ca49fc5e-2b5b-4bc2-a9c1-70e01327dade"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Red Walls Removal"",
                    ""type"": ""Button"",
                    ""id"": ""cae04f85-0e2e-4522-bb42-a90bfdcc6e5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Random Blue Walls"",
                    ""type"": ""Button"",
                    ""id"": ""eba972bf-4784-4035-bc0c-a8255bc20ea4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Blue Walls Removal"",
                    ""type"": ""Button"",
                    ""id"": ""bcf1a1a5-b432-4b24-ab7a-52f25767e92e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Random Yellow Walls"",
                    ""type"": ""Button"",
                    ""id"": ""e6cabf3e-0b3c-452d-b98d-3bfb997d3fff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Yellow Walls Removal"",
                    ""type"": ""Button"",
                    ""id"": ""5a371972-4fbf-4d17-9e2b-3fb8ad0e4862"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpawnSpeedChange"",
                    ""type"": ""Value"",
                    ""id"": ""258dda63-0a6c-4ecc-b3be-f5e62c89022e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BallSpeedChange"",
                    ""type"": ""Value"",
                    ""id"": ""588e2a68-8a0e-4ecb-885c-e737c2cd7828"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MasterBallHell"",
                    ""type"": ""Button"",
                    ""id"": ""1c0ad190-3dd7-4d74-b4ae-b27b806312ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlayerBallHell"",
                    ""type"": ""Button"",
                    ""id"": ""0fd6d556-60f0-4dc6-96ed-0878cc968c9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c1ff549d-b9c7-49ac-8a05-0a57ea93b27f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""759018d0-2055-47f8-a69b-bce72ab9bfd1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d2ed1ca3-5d75-4d7d-b48e-47fbb0a1ae19"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dfc3afa4-c48c-4bd5-8b80-6b5f70d70a84"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ceed2289-3325-4d74-8fed-a1d888e8609e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""983b64b9-9337-4782-9999-cd9b55a2aa9c"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Random Red Walls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51ce9d48-c73b-40c1-934e-02eddf4f2177"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Random Blue Walls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""693c09ff-8908-4b2b-984a-b75f71c5f47e"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Random Yellow Walls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ef9e8610-36c1-4d9c-bf48-8c59b1c45853"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnSpeedChange"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a5491951-b5cc-46b4-a74c-7c3ad8c825ae"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnSpeedChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9ade23e6-5178-4e01-bbe0-9bcb69549a95"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnSpeedChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4d7f76e2-7e37-4c7f-8c8b-99372d827032"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BallSpeedChange"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e915d309-54d4-49f3-bfe0-3b022c43b1b3"",
                    ""path"": ""<Keyboard>/numpadDivide"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BallSpeedChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5b99f510-acd2-4fd5-ad4a-adf4a514ba72"",
                    ""path"": ""<Keyboard>/numpadMultiply"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BallSpeedChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d8dfa56d-be84-405f-90fe-1b88d66523b6"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Red Walls Removal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dddda22-b852-42a6-9618-1bb61b9768ee"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blue Walls Removal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6226877d-3876-415a-b6cf-5fa4b0f3e54f"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yellow Walls Removal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63c6eaf3-af74-4635-875a-52781ae1b47c"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MasterBallHell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3649e84f-7585-4e14-9ce6-46035d18722e"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerBallHell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Move = m_PlayerMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerMap_RandomRedWalls = m_PlayerMap.FindAction("Random Red Walls", throwIfNotFound: true);
        m_PlayerMap_RedWallsRemoval = m_PlayerMap.FindAction("Red Walls Removal", throwIfNotFound: true);
        m_PlayerMap_RandomBlueWalls = m_PlayerMap.FindAction("Random Blue Walls", throwIfNotFound: true);
        m_PlayerMap_BlueWallsRemoval = m_PlayerMap.FindAction("Blue Walls Removal", throwIfNotFound: true);
        m_PlayerMap_RandomYellowWalls = m_PlayerMap.FindAction("Random Yellow Walls", throwIfNotFound: true);
        m_PlayerMap_YellowWallsRemoval = m_PlayerMap.FindAction("Yellow Walls Removal", throwIfNotFound: true);
        m_PlayerMap_SpawnSpeedChange = m_PlayerMap.FindAction("SpawnSpeedChange", throwIfNotFound: true);
        m_PlayerMap_BallSpeedChange = m_PlayerMap.FindAction("BallSpeedChange", throwIfNotFound: true);
        m_PlayerMap_MasterBallHell = m_PlayerMap.FindAction("MasterBallHell", throwIfNotFound: true);
        m_PlayerMap_PlayerBallHell = m_PlayerMap.FindAction("PlayerBallHell", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private List<IPlayerMapActions> m_PlayerMapActionsCallbackInterfaces = new List<IPlayerMapActions>();
    private readonly InputAction m_PlayerMap_Move;
    private readonly InputAction m_PlayerMap_RandomRedWalls;
    private readonly InputAction m_PlayerMap_RedWallsRemoval;
    private readonly InputAction m_PlayerMap_RandomBlueWalls;
    private readonly InputAction m_PlayerMap_BlueWallsRemoval;
    private readonly InputAction m_PlayerMap_RandomYellowWalls;
    private readonly InputAction m_PlayerMap_YellowWallsRemoval;
    private readonly InputAction m_PlayerMap_SpawnSpeedChange;
    private readonly InputAction m_PlayerMap_BallSpeedChange;
    private readonly InputAction m_PlayerMap_MasterBallHell;
    private readonly InputAction m_PlayerMap_PlayerBallHell;
    public struct PlayerMapActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerMapActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMap_Move;
        public InputAction @RandomRedWalls => m_Wrapper.m_PlayerMap_RandomRedWalls;
        public InputAction @RedWallsRemoval => m_Wrapper.m_PlayerMap_RedWallsRemoval;
        public InputAction @RandomBlueWalls => m_Wrapper.m_PlayerMap_RandomBlueWalls;
        public InputAction @BlueWallsRemoval => m_Wrapper.m_PlayerMap_BlueWallsRemoval;
        public InputAction @RandomYellowWalls => m_Wrapper.m_PlayerMap_RandomYellowWalls;
        public InputAction @YellowWallsRemoval => m_Wrapper.m_PlayerMap_YellowWallsRemoval;
        public InputAction @SpawnSpeedChange => m_Wrapper.m_PlayerMap_SpawnSpeedChange;
        public InputAction @BallSpeedChange => m_Wrapper.m_PlayerMap_BallSpeedChange;
        public InputAction @MasterBallHell => m_Wrapper.m_PlayerMap_MasterBallHell;
        public InputAction @PlayerBallHell => m_Wrapper.m_PlayerMap_PlayerBallHell;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @RandomRedWalls.started += instance.OnRandomRedWalls;
            @RandomRedWalls.performed += instance.OnRandomRedWalls;
            @RandomRedWalls.canceled += instance.OnRandomRedWalls;
            @RedWallsRemoval.started += instance.OnRedWallsRemoval;
            @RedWallsRemoval.performed += instance.OnRedWallsRemoval;
            @RedWallsRemoval.canceled += instance.OnRedWallsRemoval;
            @RandomBlueWalls.started += instance.OnRandomBlueWalls;
            @RandomBlueWalls.performed += instance.OnRandomBlueWalls;
            @RandomBlueWalls.canceled += instance.OnRandomBlueWalls;
            @BlueWallsRemoval.started += instance.OnBlueWallsRemoval;
            @BlueWallsRemoval.performed += instance.OnBlueWallsRemoval;
            @BlueWallsRemoval.canceled += instance.OnBlueWallsRemoval;
            @RandomYellowWalls.started += instance.OnRandomYellowWalls;
            @RandomYellowWalls.performed += instance.OnRandomYellowWalls;
            @RandomYellowWalls.canceled += instance.OnRandomYellowWalls;
            @YellowWallsRemoval.started += instance.OnYellowWallsRemoval;
            @YellowWallsRemoval.performed += instance.OnYellowWallsRemoval;
            @YellowWallsRemoval.canceled += instance.OnYellowWallsRemoval;
            @SpawnSpeedChange.started += instance.OnSpawnSpeedChange;
            @SpawnSpeedChange.performed += instance.OnSpawnSpeedChange;
            @SpawnSpeedChange.canceled += instance.OnSpawnSpeedChange;
            @BallSpeedChange.started += instance.OnBallSpeedChange;
            @BallSpeedChange.performed += instance.OnBallSpeedChange;
            @BallSpeedChange.canceled += instance.OnBallSpeedChange;
            @MasterBallHell.started += instance.OnMasterBallHell;
            @MasterBallHell.performed += instance.OnMasterBallHell;
            @MasterBallHell.canceled += instance.OnMasterBallHell;
            @PlayerBallHell.started += instance.OnPlayerBallHell;
            @PlayerBallHell.performed += instance.OnPlayerBallHell;
            @PlayerBallHell.canceled += instance.OnPlayerBallHell;
        }

        private void UnregisterCallbacks(IPlayerMapActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @RandomRedWalls.started -= instance.OnRandomRedWalls;
            @RandomRedWalls.performed -= instance.OnRandomRedWalls;
            @RandomRedWalls.canceled -= instance.OnRandomRedWalls;
            @RedWallsRemoval.started -= instance.OnRedWallsRemoval;
            @RedWallsRemoval.performed -= instance.OnRedWallsRemoval;
            @RedWallsRemoval.canceled -= instance.OnRedWallsRemoval;
            @RandomBlueWalls.started -= instance.OnRandomBlueWalls;
            @RandomBlueWalls.performed -= instance.OnRandomBlueWalls;
            @RandomBlueWalls.canceled -= instance.OnRandomBlueWalls;
            @BlueWallsRemoval.started -= instance.OnBlueWallsRemoval;
            @BlueWallsRemoval.performed -= instance.OnBlueWallsRemoval;
            @BlueWallsRemoval.canceled -= instance.OnBlueWallsRemoval;
            @RandomYellowWalls.started -= instance.OnRandomYellowWalls;
            @RandomYellowWalls.performed -= instance.OnRandomYellowWalls;
            @RandomYellowWalls.canceled -= instance.OnRandomYellowWalls;
            @YellowWallsRemoval.started -= instance.OnYellowWallsRemoval;
            @YellowWallsRemoval.performed -= instance.OnYellowWallsRemoval;
            @YellowWallsRemoval.canceled -= instance.OnYellowWallsRemoval;
            @SpawnSpeedChange.started -= instance.OnSpawnSpeedChange;
            @SpawnSpeedChange.performed -= instance.OnSpawnSpeedChange;
            @SpawnSpeedChange.canceled -= instance.OnSpawnSpeedChange;
            @BallSpeedChange.started -= instance.OnBallSpeedChange;
            @BallSpeedChange.performed -= instance.OnBallSpeedChange;
            @BallSpeedChange.canceled -= instance.OnBallSpeedChange;
            @MasterBallHell.started -= instance.OnMasterBallHell;
            @MasterBallHell.performed -= instance.OnMasterBallHell;
            @MasterBallHell.canceled -= instance.OnMasterBallHell;
            @PlayerBallHell.started -= instance.OnPlayerBallHell;
            @PlayerBallHell.performed -= instance.OnPlayerBallHell;
            @PlayerBallHell.canceled -= instance.OnPlayerBallHell;
        }

        public void RemoveCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRandomRedWalls(InputAction.CallbackContext context);
        void OnRedWallsRemoval(InputAction.CallbackContext context);
        void OnRandomBlueWalls(InputAction.CallbackContext context);
        void OnBlueWallsRemoval(InputAction.CallbackContext context);
        void OnRandomYellowWalls(InputAction.CallbackContext context);
        void OnYellowWallsRemoval(InputAction.CallbackContext context);
        void OnSpawnSpeedChange(InputAction.CallbackContext context);
        void OnBallSpeedChange(InputAction.CallbackContext context);
        void OnMasterBallHell(InputAction.CallbackContext context);
        void OnPlayerBallHell(InputAction.CallbackContext context);
    }
}

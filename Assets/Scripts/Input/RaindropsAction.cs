//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/RaindropsAction.inputactions
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

public partial class @RaindropsAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @RaindropsAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RaindropsAction"",
    ""maps"": [
        {
            ""name"": ""Base Action Map"",
            ""id"": ""b3878eb2-7ef4-4948-9de5-0a63f27f860e"",
            ""actions"": [
                {
                    ""name"": ""Enter Action"",
                    ""type"": ""Button"",
                    ""id"": ""73d28010-ddb8-46dd-853f-cfc17e55355a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""f5391296-439c-478c-8422-2e062c49a754"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""57282d5d-51be-459c-b567-22936f38ed3e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c0c40c8-9a19-4876-9b13-0b8969b17099"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f337b3cd-1dc7-453e-94dd-85db0b6fd923"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Base Action Map
        m_BaseActionMap = asset.FindActionMap("Base Action Map", throwIfNotFound: true);
        m_BaseActionMap_EnterAction = m_BaseActionMap.FindAction("Enter Action", throwIfNotFound: true);
        m_BaseActionMap_Escape = m_BaseActionMap.FindAction("Escape", throwIfNotFound: true);
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

    // Base Action Map
    private readonly InputActionMap m_BaseActionMap;
    private List<IBaseActionMapActions> m_BaseActionMapActionsCallbackInterfaces = new List<IBaseActionMapActions>();
    private readonly InputAction m_BaseActionMap_EnterAction;
    private readonly InputAction m_BaseActionMap_Escape;
    public struct BaseActionMapActions
    {
        private @RaindropsAction m_Wrapper;
        public BaseActionMapActions(@RaindropsAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnterAction => m_Wrapper.m_BaseActionMap_EnterAction;
        public InputAction @Escape => m_Wrapper.m_BaseActionMap_Escape;
        public InputActionMap Get() { return m_Wrapper.m_BaseActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IBaseActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Add(instance);
            @EnterAction.started += instance.OnEnterAction;
            @EnterAction.performed += instance.OnEnterAction;
            @EnterAction.canceled += instance.OnEnterAction;
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(IBaseActionMapActions instance)
        {
            @EnterAction.started -= instance.OnEnterAction;
            @EnterAction.performed -= instance.OnEnterAction;
            @EnterAction.canceled -= instance.OnEnterAction;
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(IBaseActionMapActions instance)
        {
            if (m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBaseActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_BaseActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BaseActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BaseActionMapActions @BaseActionMap => new BaseActionMapActions(this);
    public interface IBaseActionMapActions
    {
        void OnEnterAction(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
}
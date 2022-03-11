// GENERATED AUTOMATICALLY FROM 'Assets/Data/MainControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Core.Input
{
    public class @MainControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @MainControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""95482df4-8f4f-471f-9e0a-b66ebf33ac49"",
            ""actions"": [
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""62860223-6fbf-4554-8200-cdfd5dbb9c1a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""b4e0f63d-727e-413e-8478-e4b1cbc0f957"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""7e004450-1209-4f8a-b933-c959c638ea90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e3026889-51a8-4446-a6ee-c658f93cbca4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""8029b513-fecf-4fb4-a51e-3f8b96f7c741"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""75d06ae4-b4a3-4089-be85-371979bbb6d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ae1eac79-c594-4ba3-931f-b263f0033be7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FastAttack"",
                    ""type"": ""Button"",
                    ""id"": ""805f0ac5-039f-4478-8afa-e5371ef2072d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrongAttack"",
                    ""type"": ""Button"",
                    ""id"": ""03c9f202-7686-4937-bd15-ec80a35d2a44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""0127b4c9-3327-4104-9ba4-d2d26345bc6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon 0"",
                    ""type"": ""Button"",
                    ""id"": ""b5eaa313-a53a-4dc8-84bf-a769230b9c44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon 1"",
                    ""type"": ""Button"",
                    ""id"": ""cf33fcc5-b8c4-4415-9de6-f9243c359f38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon 2"",
                    ""type"": ""Button"",
                    ""id"": ""287ae1f5-4e8d-43b5-bee2-bfea21ba0efc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon 3"",
                    ""type"": ""Button"",
                    ""id"": ""6b6140ea-d9c3-4baf-a40b-c960c5df8897"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon 4"",
                    ""type"": ""Button"",
                    ""id"": ""c4f27836-3e73-4ef2-97fa-352b5d4d7eff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon 5"",
                    ""type"": ""Button"",
                    ""id"": ""f0c86d8e-6253-4907-8274-46dae1153791"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d9d776f8-1638-4549-8ada-0af59d5b84c8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d76397b8-b7e2-4864-a46e-36335cfa267b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd48ddec-203c-49eb-b25b-05390b171b94"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d852bcec-295b-421f-82da-b2b8d708bf1e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76dbd33b-0d81-4b45-aa15-7a8a11b69148"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ab88f5b-aef9-429f-ae95-5274f0910b80"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f210378-f110-4a20-8cfb-f69639b9efd3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""927627f3-4bea-4dc6-a203-a26b792e7443"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""FastAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f83f338b-25d1-458d-960a-6474ce07fe7e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""FastAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db38cb3a-2875-48b8-9083-b75957ff91b9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""StrongAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e9aee3-5c28-4e9a-9fcf-2644dbf9104f"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""StrongAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a36aadd0-54ef-4c26-849b-4687463cb16f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02a875f0-13a1-4ef5-b05f-3e8d91349f78"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c148e053-46ee-450f-8985-e60f31018b32"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab5c565d-b56e-486a-a2ea-d88f5c5baaf4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""148ba216-d122-49fc-8fe8-070f29832618"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d5dfabb-58cb-4c7c-b7f0-f2ecd603335c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dfb2811-34a8-43fe-8d3f-8527c36555fe"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""220ca727-17a6-4fd9-afce-b6469dee9780"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d34899ac-aed8-4b4e-a1f6-25de1a4cbab5"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fda8585-b09e-496e-b68f-2d2e1aa6a149"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21e81abf-eeb7-459b-b1f0-73c9f3c79fce"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90d097c2-385b-42e8-aedd-496cdcf14d1e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""332d3700-3386-4e5f-ba15-7bd73401b9bb"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ede511e-2030-477d-bc0c-453b1997e78e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Weapon 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d99a3fcd-583c-4698-8117-d2626b6ef836"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ab24385-70c6-4312-ab15-7f3feb4e70a7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4020508b-eb8a-41d8-b305-caf743f98562"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c433bcaa-8f9b-45e9-ba44-1c9c142d89b7"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed253e95-a7e5-4491-be3d-12615adbf251"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ca72a8b-586c-4d23-8dfd-0b37d09f5b77"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59d7c362-317a-4f90-b164-a96333d30ccd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6323940-ae69-4537-8eda-cddfb0d98566"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34aa649d-af35-46b6-b587-e27cebfbb10c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23a5ce71-94df-4e41-99dc-836d062d0414"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ae3b23d-5c94-46fb-a1d7-a9d30f931521"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d99e6e38-ccbc-4af4-8472-6a48819f9333"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main"",
            ""bindingGroup"": ""Main"",
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_MoveDown = m_Player.FindAction("MoveDown", throwIfNotFound: true);
            m_Player_MoveUp = m_Player.FindAction("MoveUp", throwIfNotFound: true);
            m_Player_MoveRight = m_Player.FindAction("MoveRight", throwIfNotFound: true);
            m_Player_MoveLeft = m_Player.FindAction("MoveLeft", throwIfNotFound: true);
            m_Player_Action = m_Player.FindAction("Action", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
            m_Player_FastAttack = m_Player.FindAction("FastAttack", throwIfNotFound: true);
            m_Player_StrongAttack = m_Player.FindAction("StrongAttack", throwIfNotFound: true);
            m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
            m_Player_Weapon0 = m_Player.FindAction("Weapon 0", throwIfNotFound: true);
            m_Player_Weapon1 = m_Player.FindAction("Weapon 1", throwIfNotFound: true);
            m_Player_Weapon2 = m_Player.FindAction("Weapon 2", throwIfNotFound: true);
            m_Player_Weapon3 = m_Player.FindAction("Weapon 3", throwIfNotFound: true);
            m_Player_Weapon4 = m_Player.FindAction("Weapon 4", throwIfNotFound: true);
            m_Player_Weapon5 = m_Player.FindAction("Weapon 5", throwIfNotFound: true);
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
        private readonly InputAction m_Player_MoveDown;
        private readonly InputAction m_Player_MoveUp;
        private readonly InputAction m_Player_MoveRight;
        private readonly InputAction m_Player_MoveLeft;
        private readonly InputAction m_Player_Action;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Dash;
        private readonly InputAction m_Player_FastAttack;
        private readonly InputAction m_Player_StrongAttack;
        private readonly InputAction m_Player_Block;
        private readonly InputAction m_Player_Weapon0;
        private readonly InputAction m_Player_Weapon1;
        private readonly InputAction m_Player_Weapon2;
        private readonly InputAction m_Player_Weapon3;
        private readonly InputAction m_Player_Weapon4;
        private readonly InputAction m_Player_Weapon5;
        public struct PlayerActions
        {
            private @MainControls m_Wrapper;
            public PlayerActions(@MainControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveDown => m_Wrapper.m_Player_MoveDown;
            public InputAction @MoveUp => m_Wrapper.m_Player_MoveUp;
            public InputAction @MoveRight => m_Wrapper.m_Player_MoveRight;
            public InputAction @MoveLeft => m_Wrapper.m_Player_MoveLeft;
            public InputAction @Action => m_Wrapper.m_Player_Action;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Dash => m_Wrapper.m_Player_Dash;
            public InputAction @FastAttack => m_Wrapper.m_Player_FastAttack;
            public InputAction @StrongAttack => m_Wrapper.m_Player_StrongAttack;
            public InputAction @Block => m_Wrapper.m_Player_Block;
            public InputAction @Weapon0 => m_Wrapper.m_Player_Weapon0;
            public InputAction @Weapon1 => m_Wrapper.m_Player_Weapon1;
            public InputAction @Weapon2 => m_Wrapper.m_Player_Weapon2;
            public InputAction @Weapon3 => m_Wrapper.m_Player_Weapon3;
            public InputAction @Weapon4 => m_Wrapper.m_Player_Weapon4;
            public InputAction @Weapon5 => m_Wrapper.m_Player_Weapon5;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @MoveDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveDown;
                    @MoveDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveDown;
                    @MoveDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveDown;
                    @MoveUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveUp;
                    @MoveUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveUp;
                    @MoveUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveUp;
                    @MoveRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                    @MoveRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                    @MoveRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                    @MoveLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                    @Action.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                    @Action.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                    @Action.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @FastAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFastAttack;
                    @FastAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFastAttack;
                    @FastAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFastAttack;
                    @StrongAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrongAttack;
                    @StrongAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrongAttack;
                    @StrongAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrongAttack;
                    @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                    @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                    @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                    @Weapon0.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon0;
                    @Weapon0.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon0;
                    @Weapon0.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon0;
                    @Weapon1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon1;
                    @Weapon1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon1;
                    @Weapon1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon1;
                    @Weapon2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon2;
                    @Weapon2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon2;
                    @Weapon2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon2;
                    @Weapon3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon3;
                    @Weapon3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon3;
                    @Weapon3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon3;
                    @Weapon4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon4;
                    @Weapon4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon4;
                    @Weapon4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon4;
                    @Weapon5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon5;
                    @Weapon5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon5;
                    @Weapon5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWeapon5;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveDown.started += instance.OnMoveDown;
                    @MoveDown.performed += instance.OnMoveDown;
                    @MoveDown.canceled += instance.OnMoveDown;
                    @MoveUp.started += instance.OnMoveUp;
                    @MoveUp.performed += instance.OnMoveUp;
                    @MoveUp.canceled += instance.OnMoveUp;
                    @MoveRight.started += instance.OnMoveRight;
                    @MoveRight.performed += instance.OnMoveRight;
                    @MoveRight.canceled += instance.OnMoveRight;
                    @MoveLeft.started += instance.OnMoveLeft;
                    @MoveLeft.performed += instance.OnMoveLeft;
                    @MoveLeft.canceled += instance.OnMoveLeft;
                    @Action.started += instance.OnAction;
                    @Action.performed += instance.OnAction;
                    @Action.canceled += instance.OnAction;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @FastAttack.started += instance.OnFastAttack;
                    @FastAttack.performed += instance.OnFastAttack;
                    @FastAttack.canceled += instance.OnFastAttack;
                    @StrongAttack.started += instance.OnStrongAttack;
                    @StrongAttack.performed += instance.OnStrongAttack;
                    @StrongAttack.canceled += instance.OnStrongAttack;
                    @Block.started += instance.OnBlock;
                    @Block.performed += instance.OnBlock;
                    @Block.canceled += instance.OnBlock;
                    @Weapon0.started += instance.OnWeapon0;
                    @Weapon0.performed += instance.OnWeapon0;
                    @Weapon0.canceled += instance.OnWeapon0;
                    @Weapon1.started += instance.OnWeapon1;
                    @Weapon1.performed += instance.OnWeapon1;
                    @Weapon1.canceled += instance.OnWeapon1;
                    @Weapon2.started += instance.OnWeapon2;
                    @Weapon2.performed += instance.OnWeapon2;
                    @Weapon2.canceled += instance.OnWeapon2;
                    @Weapon3.started += instance.OnWeapon3;
                    @Weapon3.performed += instance.OnWeapon3;
                    @Weapon3.canceled += instance.OnWeapon3;
                    @Weapon4.started += instance.OnWeapon4;
                    @Weapon4.performed += instance.OnWeapon4;
                    @Weapon4.canceled += instance.OnWeapon4;
                    @Weapon5.started += instance.OnWeapon5;
                    @Weapon5.performed += instance.OnWeapon5;
                    @Weapon5.canceled += instance.OnWeapon5;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_MainSchemeIndex = -1;
        public InputControlScheme MainScheme
        {
            get
            {
                if (m_MainSchemeIndex == -1) m_MainSchemeIndex = asset.FindControlSchemeIndex("Main");
                return asset.controlSchemes[m_MainSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMoveDown(InputAction.CallbackContext context);
            void OnMoveUp(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnAction(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnFastAttack(InputAction.CallbackContext context);
            void OnStrongAttack(InputAction.CallbackContext context);
            void OnBlock(InputAction.CallbackContext context);
            void OnWeapon0(InputAction.CallbackContext context);
            void OnWeapon1(InputAction.CallbackContext context);
            void OnWeapon2(InputAction.CallbackContext context);
            void OnWeapon3(InputAction.CallbackContext context);
            void OnWeapon4(InputAction.CallbackContext context);
            void OnWeapon5(InputAction.CallbackContext context);
        }
    }
}

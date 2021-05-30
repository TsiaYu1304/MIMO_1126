// GENERATED AUTOMATICALLY FROM 'Assets/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""8454aebf-40af-4a82-bb56-395c4023327f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""59a85c7b-9ada-4b99-ac39-d5cc07862155"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5c7635c2-be3f-40dc-828e-bd2c064385a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""c221e954-4640-4421-9a62-9cc2e6fb55c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combine"",
                    ""type"": ""Button"",
                    ""id"": ""a8786ffb-0e2d-44b3-822a-6357cd7620bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PushButton"",
                    ""type"": ""Button"",
                    ""id"": ""7080884f-f1f9-4baf-af14-d75238298c12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speak"",
                    ""type"": ""Button"",
                    ""id"": ""0e76c98d-7a53-414a-a954-a03d2398af99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e494003b-9033-45b3-987b-a87c5694d366"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""796439c9-d427-4310-9abd-2e1d32e7378a"",
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
                    ""id"": ""7918b94e-cace-4219-84f4-72911d4aab4d"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cc9ae85f-fe36-4856-abdd-0e15483da42d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c0d3932b-f781-4b33-aec7-6316b8c2ff47"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b63c1490-b873-460f-927d-127660b048cf"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bb2db480-1cae-4887-ae49-195cf2b21c80"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c750889-7224-41b1-bad6-70cb8dd19b77"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13c4ec19-d305-4da1-98a0-1330c44ef87a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d2845ff-6e65-41b4-9445-8b87de417686"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12f52def-12a4-4117-9ce1-8cf85c9bce35"",
                    ""path"": ""<Keyboard>/rightAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8acb09-3e9c-478d-888e-8d2eea090df2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7547ffd-ba5d-4254-a9cc-146ef239497c"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b4cecf5-9e15-4793-827c-50617a37bca5"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""0e0600c0-e36f-4fdc-96d1-022eb007beb0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""97b496c6-35ba-4607-bf87-0188d427eec0"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""16738b3f-9398-4e8f-949e-8b023907d52f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""3b568599-46f4-4bb8-8854-583eadfcf35d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combine"",
                    ""type"": ""Button"",
                    ""id"": ""c88b98c4-c1b7-4c8b-8b6b-f77828f0a829"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PushButton"",
                    ""type"": ""Button"",
                    ""id"": ""9d90735a-ed6d-402d-94c1-556a124ab9c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speak"",
                    ""type"": ""Button"",
                    ""id"": ""2cc7c348-61bb-49fd-a342-24fbaada0e14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4a50371c-791a-4c5a-890f-83ca6f4d5dfe"",
                    ""path"": ""<HID::54C-5C4>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fc949d11-3c2c-404b-b668-45e90320271d"",
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
                    ""id"": ""68ac8e76-1bad-458c-89ae-bed30a43358a"",
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
                    ""id"": ""edbf9a19-7100-4d86-86e5-df4a3d7e72af"",
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
                    ""id"": ""ae9ee83b-f17b-49af-afa7-6aa16c580a36"",
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
                    ""id"": ""4cf0334d-38cd-4b19-b3ca-4313c7736eb2"",
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
                    ""id"": ""9877c225-892a-4d34-a556-40176d9f3517"",
                    ""path"": ""<HID::54C-5C4>/button2"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf228fd4-1a06-4ce1-8f32-2469c95308c5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""877bc559-4e07-4057-b357-6da13ab937fd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20eedcf4-c6a9-42d9-b3b1-436f7b3100ad"",
                    ""path"": ""<HID::54C-5C4>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d91cef6-65f6-4e99-b0fb-20adcc39265d"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d6a20c7-631c-4ba5-97df-f2e7d3b531a4"",
                    ""path"": ""<HID::54C-5C4>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62999b36-ab86-4a9f-a9d7-1ed11961d7fd"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""332f2d07-07cf-4103-be90-b839e276e02e"",
                    ""path"": ""<HID::54C-5C4>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CombineMi"",
            ""id"": ""42ccc510-556a-4fe5-803c-f7c2c56d3174"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""738c915e-9e9b-4ee9-94b6-b88bd2fc2a07"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5ed8c7b0-a012-4a0f-8f40-e3d4d636c277"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""55d2449b-f569-4d6b-920e-3f2af7cb0982"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Discombine"",
                    ""type"": ""Button"",
                    ""id"": ""bdf85752-fd8c-4549-b90d-64dd5afc34eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bang_Discombine"",
                    ""type"": ""Button"",
                    ""id"": ""dacdb498-201f-4e4f-8301-e1504c00a2ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Normal_Discombine"",
                    ""type"": ""Button"",
                    ""id"": ""a4f8a915-4a65-4537-ab6f-77ca550d50e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PushButton"",
                    ""type"": ""Button"",
                    ""id"": ""abaa22c8-9da6-4be5-a61f-dbbcdb04ed70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speak"",
                    ""type"": ""Button"",
                    ""id"": ""40bb7192-02cc-4a49-9556-766ce40b887b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1172b8c2-7dff-470d-903d-54b6e8f39762"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""190e18cc-92ff-4336-a49e-9e275924d2f8"",
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
                    ""id"": ""8d3612bc-aa38-4b3e-9a7d-e4ca840831f8"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ecd01a5-a173-46c9-bfe1-4dcfb65b16dd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""47caf4d2-1e32-4e4a-898c-691b05b59fe9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""33f735ba-e59f-411c-877f-de014a45de7a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""01069123-9f6a-4a11-815f-47d749e582ac"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""584f7145-3b36-45a5-9b63-a17d1e84113a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3721df22-e3c2-4acf-8748-05d0564f9efc"",
                    ""path"": ""<HID::54C-5C4>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f91d8037-f016-44cc-a42f-25713b916a6c"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c88c09a-e892-4672-a164-f0dd06d84bda"",
                    ""path"": ""<HID::54C-5C4>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bang_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fff8580b-438d-4641-9c78-a754b72e7534"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bang_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abd7fea5-24a3-4352-aa76-6d335d9c1302"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Normal_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaed5dee-0cc3-43fb-a3e6-98e786ae77bf"",
                    ""path"": ""<Keyboard>/rightAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Normal_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00862b8c-11ed-456e-913e-15ef906ce7ad"",
                    ""path"": ""<HID::54C-5C4>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab2fcb00-9c1d-4b94-9d04-6df840eb82ba"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdabc840-0aa7-42cc-bc8d-f41ff899cb06"",
                    ""path"": ""<HID::54C-5C4>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c25152ec-10d6-4c50-8eb3-4cf1361ef115"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CombineMo"",
            ""id"": ""b5bf737c-8872-4858-ba83-2bdbcc654d5f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2cb4ae31-80da-4c8e-9617-75c7b67e18b6"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a598b770-2179-4a21-9fcd-1842f2e07d4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""456c37be-a586-405a-b488-325f61cfb4f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Discombine"",
                    ""type"": ""Button"",
                    ""id"": ""99eb5bc2-ea36-4b3c-a068-d37840eed975"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Normal_Discombine"",
                    ""type"": ""Button"",
                    ""id"": ""b7b604f8-3400-48bb-ad53-43b03ecefbbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bang_Discombine"",
                    ""type"": ""Button"",
                    ""id"": ""35e3597e-7b4f-4af7-9d22-0e897fd162fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PushButton"",
                    ""type"": ""Button"",
                    ""id"": ""8f1fdf68-6d82-429b-b1ed-4d1ad63f8669"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speak"",
                    ""type"": ""Button"",
                    ""id"": ""9335281b-1ec8-4765-8775-25da9fd04d02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a36aec50-8310-47ee-8056-bddd0e5735b1"",
                    ""path"": ""<HID::54C-5C4>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9301ef9d-7b18-48c2-8d21-394d43bcaa93"",
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
                    ""id"": ""082681c6-0a6a-4d5f-a658-3a3d0f8213a1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dd7fb800-ecdd-4758-9327-35091d6145d9"",
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
                    ""id"": ""f2faf4cd-e5fb-43b9-8a09-adab88bec9e6"",
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
                    ""id"": ""7be208c5-52df-41dc-b4b4-2e603fe78063"",
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
                    ""id"": ""7d499e32-5971-4be9-af0a-738f3da855ce"",
                    ""path"": ""<HID::54C-5C4>/button2"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f19a03f6-2ec1-4242-b4c3-ccb5e876e749"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b69b2bfa-5fa0-4ecc-a32f-5c0bd0b26fa3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55a76b65-d2e7-426c-8259-ba84ab71f9db"",
                    ""path"": ""<HID::54C-5C4>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a25d290-0870-4f1e-9598-e1ee91ad7d36"",
                    ""path"": ""<HID::54C-5C4>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Normal_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb61aade-5249-4166-a89a-f01a635ce9dd"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Normal_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb89bc77-1364-474f-95cc-086fe191968b"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bang_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a06d9325-9fc1-41e9-b39d-4fbf8aa413e3"",
                    ""path"": ""<Keyboard>/rightAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bang_Discombine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecbf0a6a-a511-4513-b8ab-7e43bcd1a9ab"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36dca871-8d41-4b19-bf8d-da8aa5cbd775"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PushButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30a54f53-16b9-4f99-ae0e-33a240d7b2c4"",
                    ""path"": ""<HID::54C-5C4>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b425888b-b8a1-42f9-ad57-cc3ad0886fc0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speak"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Move = m_Player1.FindAction("Move", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Grab = m_Player1.FindAction("Grab", throwIfNotFound: true);
        m_Player1_Combine = m_Player1.FindAction("Combine", throwIfNotFound: true);
        m_Player1_PushButton = m_Player1.FindAction("PushButton", throwIfNotFound: true);
        m_Player1_Speak = m_Player1.FindAction("Speak", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Move = m_Player2.FindAction("Move", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_Grab = m_Player2.FindAction("Grab", throwIfNotFound: true);
        m_Player2_Combine = m_Player2.FindAction("Combine", throwIfNotFound: true);
        m_Player2_PushButton = m_Player2.FindAction("PushButton", throwIfNotFound: true);
        m_Player2_Speak = m_Player2.FindAction("Speak", throwIfNotFound: true);
        // CombineMi
        m_CombineMi = asset.FindActionMap("CombineMi", throwIfNotFound: true);
        m_CombineMi_Move = m_CombineMi.FindAction("Move", throwIfNotFound: true);
        m_CombineMi_Jump = m_CombineMi.FindAction("Jump", throwIfNotFound: true);
        m_CombineMi_Grab = m_CombineMi.FindAction("Grab", throwIfNotFound: true);
        m_CombineMi_Discombine = m_CombineMi.FindAction("Discombine", throwIfNotFound: true);
        m_CombineMi_Bang_Discombine = m_CombineMi.FindAction("Bang_Discombine", throwIfNotFound: true);
        m_CombineMi_Normal_Discombine = m_CombineMi.FindAction("Normal_Discombine", throwIfNotFound: true);
        m_CombineMi_PushButton = m_CombineMi.FindAction("PushButton", throwIfNotFound: true);
        m_CombineMi_Speak = m_CombineMi.FindAction("Speak", throwIfNotFound: true);
        // CombineMo
        m_CombineMo = asset.FindActionMap("CombineMo", throwIfNotFound: true);
        m_CombineMo_Move = m_CombineMo.FindAction("Move", throwIfNotFound: true);
        m_CombineMo_Jump = m_CombineMo.FindAction("Jump", throwIfNotFound: true);
        m_CombineMo_Grab = m_CombineMo.FindAction("Grab", throwIfNotFound: true);
        m_CombineMo_Discombine = m_CombineMo.FindAction("Discombine", throwIfNotFound: true);
        m_CombineMo_Normal_Discombine = m_CombineMo.FindAction("Normal_Discombine", throwIfNotFound: true);
        m_CombineMo_Bang_Discombine = m_CombineMo.FindAction("Bang_Discombine", throwIfNotFound: true);
        m_CombineMo_PushButton = m_CombineMo.FindAction("PushButton", throwIfNotFound: true);
        m_CombineMo_Speak = m_CombineMo.FindAction("Speak", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Grab;
    private readonly InputAction m_Player1_Combine;
    private readonly InputAction m_Player1_PushButton;
    private readonly InputAction m_Player1_Speak;
    public struct Player1Actions
    {
        private @PlayerActionControls m_Wrapper;
        public Player1Actions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Grab => m_Wrapper.m_Player1_Grab;
        public InputAction @Combine => m_Wrapper.m_Player1_Combine;
        public InputAction @PushButton => m_Wrapper.m_Player1_PushButton;
        public InputAction @Speak => m_Wrapper.m_Player1_Speak;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Grab.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnGrab;
                @Combine.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCombine;
                @Combine.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCombine;
                @Combine.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCombine;
                @PushButton.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPushButton;
                @PushButton.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPushButton;
                @PushButton.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPushButton;
                @Speak.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSpeak;
                @Speak.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSpeak;
                @Speak.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSpeak;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Combine.started += instance.OnCombine;
                @Combine.performed += instance.OnCombine;
                @Combine.canceled += instance.OnCombine;
                @PushButton.started += instance.OnPushButton;
                @PushButton.performed += instance.OnPushButton;
                @PushButton.canceled += instance.OnPushButton;
                @Speak.started += instance.OnSpeak;
                @Speak.performed += instance.OnSpeak;
                @Speak.canceled += instance.OnSpeak;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Move;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_Grab;
    private readonly InputAction m_Player2_Combine;
    private readonly InputAction m_Player2_PushButton;
    private readonly InputAction m_Player2_Speak;
    public struct Player2Actions
    {
        private @PlayerActionControls m_Wrapper;
        public Player2Actions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @Grab => m_Wrapper.m_Player2_Grab;
        public InputAction @Combine => m_Wrapper.m_Player2_Combine;
        public InputAction @PushButton => m_Wrapper.m_Player2_PushButton;
        public InputAction @Speak => m_Wrapper.m_Player2_Speak;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Grab.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnGrab;
                @Combine.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCombine;
                @Combine.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCombine;
                @Combine.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCombine;
                @PushButton.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnPushButton;
                @PushButton.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnPushButton;
                @PushButton.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnPushButton;
                @Speak.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSpeak;
                @Speak.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSpeak;
                @Speak.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSpeak;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Combine.started += instance.OnCombine;
                @Combine.performed += instance.OnCombine;
                @Combine.canceled += instance.OnCombine;
                @PushButton.started += instance.OnPushButton;
                @PushButton.performed += instance.OnPushButton;
                @PushButton.canceled += instance.OnPushButton;
                @Speak.started += instance.OnSpeak;
                @Speak.performed += instance.OnSpeak;
                @Speak.canceled += instance.OnSpeak;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // CombineMi
    private readonly InputActionMap m_CombineMi;
    private ICombineMiActions m_CombineMiActionsCallbackInterface;
    private readonly InputAction m_CombineMi_Move;
    private readonly InputAction m_CombineMi_Jump;
    private readonly InputAction m_CombineMi_Grab;
    private readonly InputAction m_CombineMi_Discombine;
    private readonly InputAction m_CombineMi_Bang_Discombine;
    private readonly InputAction m_CombineMi_Normal_Discombine;
    private readonly InputAction m_CombineMi_PushButton;
    private readonly InputAction m_CombineMi_Speak;
    public struct CombineMiActions
    {
        private @PlayerActionControls m_Wrapper;
        public CombineMiActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CombineMi_Move;
        public InputAction @Jump => m_Wrapper.m_CombineMi_Jump;
        public InputAction @Grab => m_Wrapper.m_CombineMi_Grab;
        public InputAction @Discombine => m_Wrapper.m_CombineMi_Discombine;
        public InputAction @Bang_Discombine => m_Wrapper.m_CombineMi_Bang_Discombine;
        public InputAction @Normal_Discombine => m_Wrapper.m_CombineMi_Normal_Discombine;
        public InputAction @PushButton => m_Wrapper.m_CombineMi_PushButton;
        public InputAction @Speak => m_Wrapper.m_CombineMi_Speak;
        public InputActionMap Get() { return m_Wrapper.m_CombineMi; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombineMiActions set) { return set.Get(); }
        public void SetCallbacks(ICombineMiActions instance)
        {
            if (m_Wrapper.m_CombineMiActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnJump;
                @Grab.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnGrab;
                @Discombine.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnDiscombine;
                @Discombine.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnDiscombine;
                @Discombine.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnDiscombine;
                @Bang_Discombine.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnBang_Discombine;
                @Bang_Discombine.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnBang_Discombine;
                @Bang_Discombine.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnBang_Discombine;
                @Normal_Discombine.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnNormal_Discombine;
                @Normal_Discombine.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnNormal_Discombine;
                @Normal_Discombine.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnNormal_Discombine;
                @PushButton.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnPushButton;
                @PushButton.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnPushButton;
                @PushButton.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnPushButton;
                @Speak.started -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnSpeak;
                @Speak.performed -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnSpeak;
                @Speak.canceled -= m_Wrapper.m_CombineMiActionsCallbackInterface.OnSpeak;
            }
            m_Wrapper.m_CombineMiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Discombine.started += instance.OnDiscombine;
                @Discombine.performed += instance.OnDiscombine;
                @Discombine.canceled += instance.OnDiscombine;
                @Bang_Discombine.started += instance.OnBang_Discombine;
                @Bang_Discombine.performed += instance.OnBang_Discombine;
                @Bang_Discombine.canceled += instance.OnBang_Discombine;
                @Normal_Discombine.started += instance.OnNormal_Discombine;
                @Normal_Discombine.performed += instance.OnNormal_Discombine;
                @Normal_Discombine.canceled += instance.OnNormal_Discombine;
                @PushButton.started += instance.OnPushButton;
                @PushButton.performed += instance.OnPushButton;
                @PushButton.canceled += instance.OnPushButton;
                @Speak.started += instance.OnSpeak;
                @Speak.performed += instance.OnSpeak;
                @Speak.canceled += instance.OnSpeak;
            }
        }
    }
    public CombineMiActions @CombineMi => new CombineMiActions(this);

    // CombineMo
    private readonly InputActionMap m_CombineMo;
    private ICombineMoActions m_CombineMoActionsCallbackInterface;
    private readonly InputAction m_CombineMo_Move;
    private readonly InputAction m_CombineMo_Jump;
    private readonly InputAction m_CombineMo_Grab;
    private readonly InputAction m_CombineMo_Discombine;
    private readonly InputAction m_CombineMo_Normal_Discombine;
    private readonly InputAction m_CombineMo_Bang_Discombine;
    private readonly InputAction m_CombineMo_PushButton;
    private readonly InputAction m_CombineMo_Speak;
    public struct CombineMoActions
    {
        private @PlayerActionControls m_Wrapper;
        public CombineMoActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CombineMo_Move;
        public InputAction @Jump => m_Wrapper.m_CombineMo_Jump;
        public InputAction @Grab => m_Wrapper.m_CombineMo_Grab;
        public InputAction @Discombine => m_Wrapper.m_CombineMo_Discombine;
        public InputAction @Normal_Discombine => m_Wrapper.m_CombineMo_Normal_Discombine;
        public InputAction @Bang_Discombine => m_Wrapper.m_CombineMo_Bang_Discombine;
        public InputAction @PushButton => m_Wrapper.m_CombineMo_PushButton;
        public InputAction @Speak => m_Wrapper.m_CombineMo_Speak;
        public InputActionMap Get() { return m_Wrapper.m_CombineMo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombineMoActions set) { return set.Get(); }
        public void SetCallbacks(ICombineMoActions instance)
        {
            if (m_Wrapper.m_CombineMoActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnJump;
                @Grab.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnGrab;
                @Discombine.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnDiscombine;
                @Discombine.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnDiscombine;
                @Discombine.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnDiscombine;
                @Normal_Discombine.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnNormal_Discombine;
                @Normal_Discombine.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnNormal_Discombine;
                @Normal_Discombine.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnNormal_Discombine;
                @Bang_Discombine.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnBang_Discombine;
                @Bang_Discombine.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnBang_Discombine;
                @Bang_Discombine.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnBang_Discombine;
                @PushButton.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnPushButton;
                @PushButton.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnPushButton;
                @PushButton.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnPushButton;
                @Speak.started -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnSpeak;
                @Speak.performed -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnSpeak;
                @Speak.canceled -= m_Wrapper.m_CombineMoActionsCallbackInterface.OnSpeak;
            }
            m_Wrapper.m_CombineMoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Discombine.started += instance.OnDiscombine;
                @Discombine.performed += instance.OnDiscombine;
                @Discombine.canceled += instance.OnDiscombine;
                @Normal_Discombine.started += instance.OnNormal_Discombine;
                @Normal_Discombine.performed += instance.OnNormal_Discombine;
                @Normal_Discombine.canceled += instance.OnNormal_Discombine;
                @Bang_Discombine.started += instance.OnBang_Discombine;
                @Bang_Discombine.performed += instance.OnBang_Discombine;
                @Bang_Discombine.canceled += instance.OnBang_Discombine;
                @PushButton.started += instance.OnPushButton;
                @PushButton.performed += instance.OnPushButton;
                @PushButton.canceled += instance.OnPushButton;
                @Speak.started += instance.OnSpeak;
                @Speak.performed += instance.OnSpeak;
                @Speak.canceled += instance.OnSpeak;
            }
        }
    }
    public CombineMoActions @CombineMo => new CombineMoActions(this);
    public interface IPlayer1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnCombine(InputAction.CallbackContext context);
        void OnPushButton(InputAction.CallbackContext context);
        void OnSpeak(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnCombine(InputAction.CallbackContext context);
        void OnPushButton(InputAction.CallbackContext context);
        void OnSpeak(InputAction.CallbackContext context);
    }
    public interface ICombineMiActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnDiscombine(InputAction.CallbackContext context);
        void OnBang_Discombine(InputAction.CallbackContext context);
        void OnNormal_Discombine(InputAction.CallbackContext context);
        void OnPushButton(InputAction.CallbackContext context);
        void OnSpeak(InputAction.CallbackContext context);
    }
    public interface ICombineMoActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnDiscombine(InputAction.CallbackContext context);
        void OnNormal_Discombine(InputAction.CallbackContext context);
        void OnBang_Discombine(InputAction.CallbackContext context);
        void OnPushButton(InputAction.CallbackContext context);
        void OnSpeak(InputAction.CallbackContext context);
    }
}

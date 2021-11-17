using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    [SerializeField] VisualEffect fireworks;

    [SerializeField] PlayerInput playerInput = null; // new input system component

    InputAction keysInputAction;
    string keysAndPadsActionName = "Move"; // name of action in input action asset

    InputAction slidersInputAction;
    string slidersActionName = "Look"; // name of action in input action asset
    InputBinding wheelBinding;

    void Start()
    {
        keysInputAction = playerInput.actions.FindAction(keysAndPadsActionName);
        keysInputAction.started += KeysInputAction_started;
        keysInputAction.canceled += KeysInputAction_canceled;

        slidersInputAction = playerInput.actions.FindAction(slidersActionName);
        //slidersInputAction.performed += SliderInputAction_started;
        InputBinding[] sliderArray = slidersInputAction.bindings.ToArray();
        wheelBinding = sliderArray[3];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Debugging();
        
        Debug.Log(slidersInputAction.ReadValue<float>());
    }

    void KeysInputAction_started(InputAction.CallbackContext obj)
    {
        //Debug.Log("internal started: " + obj.control.ToString());
        // a key was PRESSED - find out which one
        fireworks.SendEvent("Fire");
    }

    void KeysInputAction_canceled(InputAction.CallbackContext obj)
    {

    }

    void SliderInputAction_started(InputAction.CallbackContext obj)
    {
        //Debug.Log("internal started: " + obj.control.ToString());
        //Debug.Log(slidersInputAction.ReadValue<float>());
    }

    void OnDestroy()
    {
        keysInputAction.started -= KeysInputAction_started;
        keysInputAction.canceled -= KeysInputAction_canceled;
    }

    void Debugging()
    {
        InputBinding[] arr = slidersInputAction.bindings.ToArray();
        foreach (InputBinding b in arr)
        {
            Debug.Log(b.path.ToString());
        }
    }
}

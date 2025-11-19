using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour
{
    public static InputService Instance { get; private set; }
    public bool leftClickEnabled { get; private set; }

    private List<Action> leftClickListeners = new List<Action>();
    private InputAction leftClick { get; set; }
    

    void Awake()
    {
        leftClick = InputSystem.actions.FindAction("Attack");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new Exception("Multiple InputServices Detected");
        }
    }

    private void Update()
    {
        if (leftClick.WasPerformedThisFrame())
        {
            leftClickEnabled = true;
            foreach (Action action in leftClickListeners)
            {
                action.Invoke();
            }
        }
        if (leftClick.WasCompletedThisFrame())
        {
            leftClickEnabled = false;
        }
    }

    public void RegisterLeftClickListener(Action action)
    {
        leftClickListeners.Add(action);
    }
}

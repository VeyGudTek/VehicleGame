using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour
{
    public static InputService Instance { get; private set; }
    public bool leftClickEnabled { get; private set; }

    private List<Action> leftClickListeners { get; set; } = new List<Action>();
    private List<Action> leftClickFixedListeners { get; set; } = new List<Action>();
    private List<Action> previousClickListeners { get; set; } = new List<Action>();
    private List<Action> nextClickListeners { get; set; } = new List<Action>();
    private List<Action> jumpListeners { get; set; } = new List<Action>();

    private InputAction leftClick { get; set; }
    private InputAction next { get; set; }
    private InputAction previous { get; set; }
    private InputAction jump { get; set; }


    void Awake()
    {
        leftClick = InputSystem.actions.FindAction("Attack");
        next = InputSystem.actions.FindAction("Next");
        previous = InputSystem.actions.FindAction("Previous");
        jump = InputSystem.actions.FindAction("Jump");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new Exception("Multiple Singletons: [Input Service]");
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

        if (next.WasPerformedThisFrame())
        {
            foreach (Action action in nextClickListeners)
            {
                action.Invoke();
            }
        }

        if (previous.WasPerformedThisFrame())
        {
            foreach(Action action in previousClickListeners)
            {
                action.Invoke();
            }
        }

        if (jump.WasPerformedThisFrame())
        {
            foreach(Action action in jumpListeners)
            {
                action.Invoke();
            }
        }
    }

    private void FixedUpdate()
    {
        if (leftClickEnabled)
        {
            foreach(Action action in leftClickFixedListeners)
            {
                action.Invoke();
            }
        }
    }

    public void RegisterLeftClickListener(Action action, bool fix = false)
    {
        if (!fix)
        {
            leftClickListeners.Add(action);
        }
        else
        {
            leftClickFixedListeners.Add(action);
        }
    }

    public void RegisterNextClickListeners(Action action)
    {
        nextClickListeners.Add(action);
    }

    public void RegisterPreviousClickListners(Action action)
    {
        previousClickListeners.Add(action);
    }

    public void RegisterJumpListerners(Action action)
    {
        jumpListeners.Add(action);
    }
}

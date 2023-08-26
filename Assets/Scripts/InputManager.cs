using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    // Define the event types
    public event Action OnSpacePressed;

    void Awake()
    {
        // Singleton pattern, ensuring only one instance of InputManager
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Update()
    {
        CheckForKeyPress();
    }

    private void CheckForKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Logger.Debug) Logger.Log("Space Pressed");

            OnSpacePressed?.Invoke();  // check not null before invoking
        }
    }

}

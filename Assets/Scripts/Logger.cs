using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static bool Debug { get; set; } = true;

    public static void Log(string message)
    {
        if (Debug)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}

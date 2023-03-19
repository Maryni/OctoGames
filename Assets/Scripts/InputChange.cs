using System;
using System.Collections;
using System.Collections.Generic;
using Opsive.Shared.Input;
using UnityEngine;

public class InputChange : MonoBehaviour
{
    [SerializeField] private UnityInput unityInput;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            unityInput.DisableCursor = false;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            unityInput.DisableCursor = true;
        }
    }
}

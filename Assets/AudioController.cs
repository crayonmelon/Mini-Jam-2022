using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void HandleVolumeUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float currentVal;

            audioMixer.GetFloat("MyExposedParam", out currentVal);
            audioMixer.SetFloat("MyExposedParam", currentVal + 1);
        }
    }

    public void HandleVolumeDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float currentVal;

            audioMixer.GetFloat("MyExposedParam", out currentVal);
            audioMixer.SetFloat("MyExposedParam", currentVal - 1);

        }
    }

}

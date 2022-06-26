using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Animator bloodJar;
    private int currentStep = 0;
    [SerializeField] private GameObject tutScreen1, tutScreen2, tutScreen3, tutScreen4;

    public void nextStep()
    {
        currentStep++;
        switch (currentStep)
        {
            case 1:
                bloodJar.enabled = true;
                break;
            case 2:
                tutScreen1.SetActive(true);
                break;
            case 3:
                tutScreen2.SetActive(true);
                break;
            case 4:
                tutScreen3.SetActive(true);
                break;
            case 5:
                tutScreen4.SetActive(true);
                break;
            default:
                SceneManager.LoadSceneAsync(1);
                break;
        }
    }

    public void HandleSplashScreenInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            nextStep();
        }
    }
}

using UnityEngine;

public class SplashScreenBlood : MonoBehaviour
{
    public void NextStep()
    {
        GetComponentInParent<SplashScreen>().nextStep();
    }
}

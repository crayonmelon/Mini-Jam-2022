using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeVealSprite : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public void NextLevelEvent()
    {
        GameManager.GM.fallInToNextLevel();
        Destroy(camera);
    }
}

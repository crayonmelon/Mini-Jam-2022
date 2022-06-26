using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeVealSprite : MonoBehaviour
{
    public void NextLevelEvent()
    {
        GameManager.GM.fallInToNextLevel();
    }
}

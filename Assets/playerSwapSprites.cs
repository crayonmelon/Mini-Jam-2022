using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwapSprites : MonoBehaviour
{
   [SerializeField] RuntimeAnimatorController facingForward;
    [SerializeField] RuntimeAnimatorController sideOn;
    [SerializeField] RuntimeAnimatorController facingBackward;

    public void whichDirectionShouldBeFacing(Vector3 t_direction)
    {
        if (t_direction.x > 0) right();
        else if (t_direction.x < 0) left();
        if (t_direction.z > 0 ) this.GetComponentInChildren<Animator>().runtimeAnimatorController = facingBackward;
        else if (t_direction.z < 0 ) this.GetComponentInChildren<Animator>().runtimeAnimatorController = facingForward;
       
    }
    public void left()
    {
        this.GetComponentInChildren<Animator>().runtimeAnimatorController = sideOn;
        this.GetComponentsInChildren<SpriteRenderer>()[1].flipX = true;
    }
    public void right()
    {
        this.GetComponentInChildren<Animator>().runtimeAnimatorController = sideOn;
        this.GetComponentsInChildren<SpriteRenderer>()[1].flipX = false;
    }
}

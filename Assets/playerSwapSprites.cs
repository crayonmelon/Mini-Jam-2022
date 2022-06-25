using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwapSprites : MonoBehaviour
{
   [SerializeField] RuntimeAnimatorController facingForward;
    [SerializeField] RuntimeAnimatorController sideOn;
    [SerializeField] RuntimeAnimatorController facingBackward;
    [SerializeField] GameObject childWithSprites;

    public void whichDirectionShouldBeFacing(Vector3 t_direction)
    {
        if (t_direction.x > 0) right();
        else if (t_direction.x < 0) left();
        if (t_direction.z > 0 ) childWithSprites.GetComponent<Animator>().runtimeAnimatorController = facingBackward;
        else if (t_direction.z < 0 ) childWithSprites.GetComponent<Animator>().runtimeAnimatorController = facingForward;
       
    }
    public void left()
    {
        childWithSprites.GetComponent<Animator>().runtimeAnimatorController = sideOn;
        childWithSprites.GetComponent<SpriteRenderer>().flipX = true;
    }
    public void right()
    {
        childWithSprites.GetComponent<Animator>().runtimeAnimatorController = sideOn;
        childWithSprites.GetComponent<SpriteRenderer>().flipX = false;
    }
}

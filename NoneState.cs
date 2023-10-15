using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("MoleType", 0);
        animator.gameObject.GetComponent<Hole>().StartCoroutine(Wait(animator));
    }
    IEnumerator Wait(Animator animator)
    {
        float time = Random.Range(0.5f, 4.5f);
        yield return new WaitForSeconds(time);

        animator.SetInteger("MoleType", (Random.Range(0, 100) > 50) ? 1 : 2);
    }
}

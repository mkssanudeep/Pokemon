using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStateBehaviour : FighterStateBehaviour
{
    //GameObject charge;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        float fighterX = fighter.transform.position.x;
        GameObject instance = UnityEngine.Object.Instantiate(Resources.Load("sfx/Charge"),
            new Vector3 (fighterX, 1, 0),
            Quaternion.identity) as GameObject;
        ChargeExp charge = instance.GetComponent<ChargeExp>();
        charge.caster = fighter;
    }
}

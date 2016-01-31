using UnityEngine;
using System.Collections;

public class ResetAnimVariables : StateMachineBehaviour
{
    [System.Serializable]
    public class IntId
    {
        public string id = "";
        public int value = 0;
    }

    [System.Serializable]
    public class FloatId
    {
        public string id = "";
        public float value = 0f;
    }

    [System.Serializable]
    public class BoolId
    {
        public string id = "";
        public bool value = false;
    }

    public IntId[] ints = new IntId[0];
    public FloatId[] floats = new FloatId[0];
    public BoolId[] bools = new BoolId[0];

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (IntId id in ints)
        {
            animator.SetInteger(id.id, id.value);
        }

        foreach (FloatId id in floats)
        {
            animator.SetFloat(id.id, id.value);
        }

        foreach (BoolId id in bools)
        {
            animator.SetBool(id.id, id.value);
        }
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

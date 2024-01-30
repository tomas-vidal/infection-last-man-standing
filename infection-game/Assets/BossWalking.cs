using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalking : StateMachineBehaviour
{
    private Boss boss;
    private Rigidbody2D rb2d;
    private Transform transform;
    [SerializeField] private float movementVelocity;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        transform = animator.GetComponent<Transform>();
        rb2d = boss.rb2d;
        boss.lookPlayer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(boss.player.transform.position.x, this.transform.position.y), movementVelocity * Time.deltaTime);
            boss.lookPlayer();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

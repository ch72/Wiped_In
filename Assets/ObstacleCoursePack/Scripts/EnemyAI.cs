using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public float sightRange, attackRange;
    public bool playerInSightRange;
    private bool oldPlayerInSightRangeValue;

    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange) ChasePlayer();

        if(mAnimator != null && oldPlayerInSightRangeValue != playerInSightRange) {
            changeAnimation();
        }
    }

    private void changeAnimation()
    {
        if (playerInSightRange) mAnimator.SetTrigger("Run");
        else mAnimator.SetTrigger("Idle");
        oldPlayerInSightRangeValue = playerInSightRange;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}

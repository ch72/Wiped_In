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

    private bool newShout = false;
    private float timeRemaining = 0;
    public float voiceLineTime = 3;
    public AudioClip[] EnemyYells;

    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = voiceLineTime;
        player = GameObject.Find("PlayerUpdated").transform;
        agent = GetComponent<NavMeshAgent>();

        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            newShout = true;
            timeRemaining = voiceLineTime;
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSight())
        {
            ChasePlayer();
        }

        if(mAnimator != null && oldPlayerInSightRangeValue != playerInSight()) {
            changeAnimation();
        }
    }

    private bool playerInSight() {
        return (playerInSightRange && player.position.z < 10.2);
    }

    private void changeAnimation()
    {
        if (playerInSight()) mAnimator.SetTrigger("Run");
        else mAnimator.SetTrigger("Idle");
        oldPlayerInSightRangeValue = playerInSight();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if (newShout == true)
        {
            SoundManager.Instance.RandomSoundEffectEnemy(EnemyYells);
            newShout = false;
        }
    }
}

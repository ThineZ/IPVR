using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovements : MonoBehaviour
{
    public string CurrentState;
    public string NextState;

    public float idleTime;

    public NavMeshAgent agent;

    public Transform[] checkpoints;

    private int currentCheckPointIndex;

    public Animator animator;
    public RuntimeAnimatorController[] CowAnim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        CurrentState = "Idle";
        NextState = CurrentState;
        SwitchState();
    }

    private void Update()
    {
        if (CurrentState != NextState)
        {
            CurrentState = NextState;
        }
    }

    void SwitchState()
    {
        StartCoroutine(CurrentState);
    }

    IEnumerator Idle()
    {
        animator.runtimeAnimatorController = CowAnim[0];

        while (CurrentState == "Idle")
        {
            yield return new WaitForSeconds(idleTime);

            NextState = "Walking";
        }
        SwitchState();
    }

    IEnumerator Walking()
    {
        agent.SetDestination(checkpoints[currentCheckPointIndex].position);

        bool hasReached = false;

        animator.runtimeAnimatorController = CowAnim[1];

        while (CurrentState == "Walking")
        {
            yield return null;

            if (!hasReached)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    hasReached = true;

                    NextState = "Idle";

                    ++currentCheckPointIndex;

                    if (currentCheckPointIndex >= checkpoints.Length)
                    {
                        currentCheckPointIndex = 0;
                    }
                }
            }
        }
        SwitchState();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private bool isPlayerHit = false;
    private bool isStunned = false;

    public DeathCon deathController;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent != null && !isStunned && player != null)
        {
            agent.destination = player.position;

            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerHit)
        {
            isPlayerHit = true;
            Debug.Log("Hit Player");
            StartCoroutine(deathController.DeathDelay(collision));
        }
    }

    public void StopMovement()
    {
        if (agent != null)
        {
            isStunned = true;
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            agent.ResetPath();
            StartCoroutine(StartFollow(3f));
        }
    }

    private IEnumerator StartFollow(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (agent != null && player != null)
        {
            isStunned = false;
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }
}

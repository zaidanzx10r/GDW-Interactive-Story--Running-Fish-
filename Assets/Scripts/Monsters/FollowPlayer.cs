using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private bool isPlayerHit = false;
    
    public DeathCon deathController;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = player.position;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
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
}

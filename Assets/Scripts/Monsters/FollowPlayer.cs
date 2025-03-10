using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Behaviour deathScreen;

    [SerializeField]
    private float delay = 1f;

    void Start()
    {
        deathScreen.enabled = false;
    }

    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            StartCoroutine(ActionDelay(collision));
        }
    }

    void ReloadMenuScene ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator ActionDelay(Collision player)
    {
        deathScreen.enabled = true;

        yield return new WaitForSeconds(delay);

        ReloadMenuScene();
    }
}

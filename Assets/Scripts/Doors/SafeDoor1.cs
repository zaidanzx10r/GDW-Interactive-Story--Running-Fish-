using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeDoor1 : MonoBehaviour
{
    [SerializeField]
    private float delay = 5f;

    public void safeDoor1()
    {
        SceneManager.LoadScene("GameScene2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActionDelay(other));
        }
    }

    private IEnumerator ActionDelay(Collider player)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameScene2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeDoor2 : MonoBehaviour
{
    [SerializeField]
    private float delay = 5f;

    public void safeDoor2()
    {
        SceneManager.LoadScene("GameScene3");
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
        SceneManager.LoadScene("GameScene3");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeDoor3 : MonoBehaviour
{
    public Behaviour winScreen;
    [SerializeField]
    private float delay = 1f;

    void Start()
    {
        winScreen.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winScreen.enabled = true;
            StartCoroutine(ActionDelay(other));
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ActionDelay(Collider player)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
}

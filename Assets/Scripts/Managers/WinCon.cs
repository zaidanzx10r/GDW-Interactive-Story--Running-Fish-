using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    public GameObject winScreen;

    [SerializeField]
    protected float delay = 1f;

    void Start()
    {
        winScreen.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator WinDelay(Collider other)
    {
        winScreen.SetActive(true);

        yield return new WaitForSeconds(delay);

        ReloadScene();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

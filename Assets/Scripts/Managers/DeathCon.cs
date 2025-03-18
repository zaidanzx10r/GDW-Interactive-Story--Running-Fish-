using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCon : MonoBehaviour
{
    public GameObject deathScreen;

    [SerializeField]
    protected float delay = 1f;

    void Start()
    {
        deathScreen.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator DeathDelay(Collision collision)
    {
        deathScreen.SetActive(true);

        yield return new WaitForSeconds(delay);

        ReloadScene();
    }

    public IEnumerator DoorDeathDelay(Collider other)
    {
        deathScreen.SetActive(true);

        yield return new WaitForSeconds(delay);

        ReloadScene();
    }

}

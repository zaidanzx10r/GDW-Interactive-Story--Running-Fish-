using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDoor : MonoBehaviour
{
    public DoorManager Door;

    public void deathDoor()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

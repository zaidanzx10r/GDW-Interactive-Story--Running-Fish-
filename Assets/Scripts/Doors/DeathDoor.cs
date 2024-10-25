using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDoor : MonoBehaviour
{
    public void deathDoor()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

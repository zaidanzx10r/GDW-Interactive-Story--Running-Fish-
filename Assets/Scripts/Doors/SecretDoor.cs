using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretDoor : MonoBehaviour
{
    public DoorManager Door;


    public void secretDoor()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeDoor1 : MonoBehaviour
{
    public DoorManager Door;
    
    public void safeDoor1()
    {
        SceneManager.LoadScene("GameScene2");
    }
}

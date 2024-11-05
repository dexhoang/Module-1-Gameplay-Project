using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//used code from: https://youtu.be/gtpXc_9MR6g?si=Jem08o8L5PZRwTcz
public class triggerScene : MonoBehaviour
{
    public int sceneNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNumber);
        }
    }
}

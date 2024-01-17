using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            NextScene();
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

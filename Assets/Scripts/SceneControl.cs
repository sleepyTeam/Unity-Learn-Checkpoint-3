using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public int sceneIndex;
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
        sceneIndex++;
    }

}

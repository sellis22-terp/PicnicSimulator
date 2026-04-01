using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using System;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneToChangeTo;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }
    }

    public void SetScene(string scene)
    {
        sceneToChangeTo = scene;
    }
}


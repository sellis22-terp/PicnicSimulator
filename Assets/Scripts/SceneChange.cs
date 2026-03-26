using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using System;

public class SceneChange : MonoBehaviour
{
    [SerializeField] String sceneToChangeTo;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneToChangeTo);
        }
    }
}


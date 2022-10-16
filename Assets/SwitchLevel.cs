using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public void SwitchScene(int index)
    {
        if (index < 0 || index >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError($"Uncorrect index: {index}");
            return;
        }
        SceneManager.LoadScene(index);
    }

    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}

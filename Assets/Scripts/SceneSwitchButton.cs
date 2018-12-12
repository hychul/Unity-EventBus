using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButton : MonoBehaviour
{
    public void OnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

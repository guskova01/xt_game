using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    
    public void ExitGame()
    {
        Application.Quit();
    }
}

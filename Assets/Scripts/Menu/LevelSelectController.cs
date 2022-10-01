using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelectController : MonoBehaviour
{
    public MenuManager menuManager;
    public void StartStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }

    public void Return()
    {
        menuManager.GoToMainMenu();
    }
}

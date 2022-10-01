using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public MenuManager menuManager;

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToLevelSelect()
    {
        menuManager.GoToLevelSelect();
    }
}

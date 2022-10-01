using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelectMenu;

    public void GoToMainMenu()
    {
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
    }

    public void GoToLevelSelect()
    {
        MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RobertGameManager : MonoBehaviour
{
    // HUD
    public Image ExperienceBar;
    public Image HealthBar;
    public TextMeshProUGUI LevelText;

    public GameObject LevelUpMenu;

    public int[] ItemsLevels = new int[6];

    public void UpdateExperienceBar(float percent)
    {
        ExperienceBar.fillAmount = percent;
    }

    public void UpdateHealthBar(float percent)
    {
        HealthBar.fillAmount = percent;
    }


    public void UpdateLevel(int level)
    {
        LevelText.text = $"Level {level}";
    }

    public void StartLevelUp()
    {
        LevelUpMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void FinnishLevelUp()
    {
        LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RobertGameManager : MonoBehaviour
{

    public Image ExperienceBar;
    public Image HealthBar;

    public TextMeshProUGUI LevelText;
    // Receives current percent of XP
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
}

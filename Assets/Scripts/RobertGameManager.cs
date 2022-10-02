using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RobertGameManager : MonoBehaviour
{
    // HUD
    public Image ExperienceBar;
    public TextMeshProUGUI ExperienceText;

    public Image HealthBar;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI TimerText;

    public GameObject LevelUpMenu;
    public ItemLevelsUIController itemLevelsUIController;

    public int[] ItemsLevels = new int[6];

    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        int minutes = (int)timer / 60;
        TimerText.text = minutes > 9 ? $"{minutes}:" : $"0{minutes}:";

        int seconds = (int)timer % 60;
        TimerText.text += seconds > 9 ? $"{seconds}" : $"0{seconds}";
    }

    public void UpdateExperienceBar(float experience, float nextLevelExperience)
    {
        ExperienceBar.fillAmount = experience / nextLevelExperience;
        ExperienceText.text = $"{experience}/{nextLevelExperience}";
    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        HealthBar.fillAmount = health / maxHealth;
        HealthText.text = $"{health}/{maxHealth}";
    }


    public void UpdateLevel(int level)
    {
        LevelText.text = $"Level {level}";
    }

    public void UpdateItemLevels()
    {
        itemLevelsUIController.LevelUpItems(ItemsLevels);
    }

    public void StartLevelUp()
    {
        LevelUpMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void FinnishLevelUp(int rewardId)
    {
        LevelUpMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

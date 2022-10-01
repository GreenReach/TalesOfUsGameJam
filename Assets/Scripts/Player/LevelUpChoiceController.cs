using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelUpChoiceController : MonoBehaviour
{
    public LevelUpPanelController levelUpPanelController;

    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;

    public Image Icon;
    public Button button;

    public int rewardId;

    private void Start()
    {
        button.onClick.AddListener(Choose);
    }

    public void Configure(int rewardId, int upgradeLevel)
    {
        this.rewardId = rewardId;
        // TODO icon
        if(rewardId == (int)GameStructures.LevelUpListItems.Horse)
        {
            Title.text = $"Horse +{upgradeLevel}";
            Description.text = GameStructures.HorseUpgradesDescription[upgradeLevel];
        }

        if (rewardId == (int)GameStructures.LevelUpListItems.Ambrosia)
        {
            Title.text = $"Ambrosia +{upgradeLevel}";
            Description.text = GameStructures.AmbrosiaUpgradesDescription[upgradeLevel];
        }

        if (rewardId == (int)GameStructures.LevelUpListItems.GiantsHeritage)
        {
            Title.text = $"Giants Heritage +{upgradeLevel}";
            Description.text = GameStructures.GiantsHeritageUpgradesDescription[upgradeLevel];
        }
    }

    public void Choose()
    {
        levelUpPanelController.RewardChoice(rewardId);
    }


}

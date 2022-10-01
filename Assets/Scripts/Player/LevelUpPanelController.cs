using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanelController : MonoBehaviour
{
    public RobertGameManager Rga;
    public GameObject Player;

    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;

    public void OnEnable()
    {
        PlayerController playerController = Player.GetComponent<PlayerController>();
        // TODO get a structure with all levels from weapons + passive items
        int Choice1Reward = Random.Range(0, 6);
        while(Rga.ItemsLevels[Choice1Reward] > 5)
            Choice1Reward = Random.Range(0, 6);

        int Choice2Reward = Random.Range(0, 6);
        while (Rga.ItemsLevels[Choice2Reward] > 5)
            Choice2Reward = Random.Range(0, 6);

        int Choice3Reward = Random.Range(0, 6);
        while (Rga.ItemsLevels[Choice3Reward] > 5)
            Choice3Reward = Random.Range(0, 6);

        Choice1.GetComponent<LevelUpChoiceController>().Configure(Choice1Reward, Rga.ItemsLevels[Choice1Reward]);
        Choice2.GetComponent<LevelUpChoiceController>().Configure(Choice2Reward, Rga.ItemsLevels[Choice2Reward]);
        Choice3.GetComponent<LevelUpChoiceController>().Configure(Choice3Reward, Rga.ItemsLevels[Choice3Reward]);

    }

    public void RewardChoice(int rewardId)
    {
        Player.GetComponent<PlayerController>().ApplyReward(rewardId);
        Rga.FinnishLevelUp(rewardId);

    }

    public void FullHealChoice()
    {
        Player.GetComponent<PlayerController>().ApplyReward(-1);
        Rga.FinnishLevelUp(-1);
    }


}

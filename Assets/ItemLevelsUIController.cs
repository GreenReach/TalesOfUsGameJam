using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemLevelsUIController : MonoBehaviour
{
    public TextMeshProUGUI[] itemsLevelText = new TextMeshProUGUI[6];

    public void LevelUpItems(int[] levels)
    {
        for(int i = 0; i< levels.Length; i++)
            itemsLevelText[i].text = $"{levels[i]}/5";
    }
}

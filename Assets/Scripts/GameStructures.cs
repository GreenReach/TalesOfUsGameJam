using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStructures
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    static public float[] speedModifiersValues = { 1f, 1.25f, 1.5f, 2f, 2.5f, 3f };
    static public float[] damageModifierValues = { 1f, 1.25f, 1.5f, 2f, 2.5f, 3f };
    static public int[] healthUpgradeValues = { 100, 125, 150, 200, 250, 300 };

    public enum LevelUpListItems
    {
        Horse,
        Ambrosia,
        GiantsHeritage,
        Sword,
        Bow,
        SpellBook
    }

    static public string[] HorseUpgradesDescription =
    {
        "Move faster. +25% Movement speed",
        "Move faster. +50% Movement speed",
        "Move faster. +100% Movement speed",
        "Move faster. +150% Movement speed",
        "Move faster. +200% Movement speed",
    };


    static public string[] AmbrosiaUpgradesDescription =
    {
        "Increase Max Health. +25% Max Health",
        "Increase Max Health. +50% Max Health",
        "Increase Max Health. +100% Max Health",
        "Increase Max Health. +150% Max Health",
        "Increase Max Health. +200% Max Health",
    };

    static public string[] GiantsHeritageUpgradesDescription =
    {
        "Increase Damage. +25% Damage",
        "Increase Damage. +50% Damage",
        "Increase Damage. +100% Damage",
        "Increase Damage. +150% Damage",
        "Increase Damage. +200% Damage",
    };

    static public string[] PalosUpgradesDescription =
    {
        "Increase Damage. +25% Damage",
        "Increase AriaDamage. +100% Damage",
        "Increase Damage. +100% Damage",
        "Increase AttackSpeed. 50%",
    };

    static public string[] BowUpgradesDescription =
    {
        "Get the bow. Start shooting closest enemy",
        "Increase Damage. +25% Damage",
        "Shoot with two arrows",
        "Increase Damage. +75% Damage",
        "Shoot with three arrows",
    };

    public static string[] SpellBookUpgradesDescription = {
        "Get a Scholomancy Book that will orbit you, dealing damage to enemies",
        "Two books orbit you",
        "Increase damage",
        "Three books orbit you",
        "Increase damage"
    };
    
    
    
    public const string DamageIncreaseFactorKey = "DamageIncreaseFactor";
    public const string HpIncreaseAmountKey = "HpIncreaseAmount";
}

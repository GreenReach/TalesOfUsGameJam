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

    public enum PassiveItemLocation
    {
        Horse,
        Ambrosia,
        GiatsHeritage
    }

    static public float[] speedModifiersValues = { 1f, 1.25f, 1.5f, 2f, 2.5f };
    static public float[] damageModifierValues = { 1f, 1.25f, 1.5f, 2f, 2.5f };
    static public int[] healthUpgradeValues = { 100, 125, 150, 200, 250 };
}

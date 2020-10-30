using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerPropertiesFloat")]
public class PlayerPropertiesFloat: ScriptableObject
{
    public float CurrentValue;
    public float StartValue;
    public float ValueStep;
    public int NumberOfImprovements;
    public int MaxNumbersOfImprovements;
    public int StartPrice;
}

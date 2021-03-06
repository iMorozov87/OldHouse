﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPropertiesInt
{
    public string Name;
    public int CurrentValue;
    public int StartValue;
    public int ValueStep;
    public int NumberOfImprovements;
    public int MaxNumbersOfImprovements;
    public int Price;
    public int NextPrice;

    public void SetNextValue()
    {
        int magnification = 2;
        CurrentValue += ValueStep;
        NumberOfImprovements++;       
        Price *= magnification;
        NextPrice = Price * magnification;
    }
}

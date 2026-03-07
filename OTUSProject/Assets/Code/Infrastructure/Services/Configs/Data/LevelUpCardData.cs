using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUpcard", menuName = "ConfigData/LevelUpCard")]
public class LevelUpCardData : ScriptableObject
{
    public CardKey CardKey;
    public int Amount;
    public string LabelName;
    public string Description;
    public Sprite Icon;
    public Color IconColor;
}


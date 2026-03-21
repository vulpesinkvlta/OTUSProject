using System;
using UnityEngine;

namespace Code.Infrastructure.Data
{
    [Serializable]
    public class PlacedTowerData
    {
        public string TowerId;
        public WeaponType WeaponType;
        public Vector3 Position;
    }
}
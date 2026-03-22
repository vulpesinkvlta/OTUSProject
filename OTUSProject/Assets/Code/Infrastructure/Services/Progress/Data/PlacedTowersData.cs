using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Code.Infrastructure.Data
{
    [Serializable]
    public class PlacedTowerData
    {
        public string TowerId;
        public WeaponType WeaponType;
        public float PositionX;
        public float PositionY;
        public float PositionZ;

        [JsonIgnore]
        public Vector3 Position
        {
            get => new Vector3(PositionX, PositionY, PositionZ);
            set
            {
                PositionX = value.x;
                PositionY = value.y;
                PositionZ = value.z;
            }
        }

        public Vector3 ToPosition() => Position;

        public static PlacedTowerData FromPosition(string towerId, WeaponType weaponType, Vector3 position)
        {
            return new PlacedTowerData
            {
                TowerId = towerId,
                WeaponType = weaponType,
                Position = position
            };
        }
    }
}
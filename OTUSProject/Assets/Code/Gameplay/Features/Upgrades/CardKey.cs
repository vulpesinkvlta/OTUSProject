using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public struct CardKey : IEquatable<CardKey>
{
    public CardId Id;
    public int Percent;

    public CardKey(CardId id, int percent)
    {
        Id = id;
        Percent = percent;
    }

    public bool Equals(CardKey other)
    {
        return Id == other.Id && Percent == other.Percent;
    }

    public override bool Equals(object obj)
    {
        return obj is CardKey other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((int)Id * 397) ^ Percent;
        }
    }

    public override string ToString() => $"{Id} (Lv.{Percent})";

    public enum CardId
    {
        None = 0,
        Damage = 1,
        Health = 2,
        Speed = 3
    }
}


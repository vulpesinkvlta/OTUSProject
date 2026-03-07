using Entitas;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class PathComponent : IComponent
{
    public List<Vector3> waypoints;
    public int currentIndex;
}


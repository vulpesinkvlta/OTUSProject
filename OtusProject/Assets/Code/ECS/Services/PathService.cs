using System.Collections.Generic;
using UnityEngine;

public abstract class PathService
{
    public abstract List<Vector3> CalculatePath(Vector3 from, Vector3 to);
}


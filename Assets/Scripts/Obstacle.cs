using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : GameScript
{
    public abstract void Activate(LeverController lever);
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public static Action<bool> onDoorCollision;

    void DoorCollision(bool isColliding)
    {
        onDoorCollision?.Invoke(isColliding);
    }  
}

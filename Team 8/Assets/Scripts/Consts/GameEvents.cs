using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public static Action<bool> onDoorCollision;
    public static Action<string> onMessage;

    void DoorCollision(bool isColliding)
    {
        onDoorCollision?.Invoke(isColliding);
    }  

    void Massage(string massage)
    {
        onMessage?.Invoke(massage);
    }
}

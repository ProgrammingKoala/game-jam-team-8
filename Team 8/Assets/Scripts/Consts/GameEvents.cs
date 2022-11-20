using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public static Action<bool> onDoorCollision;
    public static Action<string> onMessage;
    public static Action onEnemyTakeDamage;
    public static Action onPlayerTakeDamage;
    public static Action onEnemyAttack;
    public static Action onSceneChange;

    void DoorCollision(bool isColliding)
    {
        onDoorCollision?.Invoke(isColliding);
    }  

    void Massage(string massage)
    {
        onMessage?.Invoke(massage);
    }

    void EnemyTakeDamage()
    {
        onEnemyTakeDamage?.Invoke();
    }

    void PlayerTakeDamage()
    {
        onPlayerTakeDamage?.Invoke();
    }

    void EnemyAttack()
    {
        onEnemyAttack?.Invoke();
    }

    void SceneChange() 
    { 
        onSceneChange?.Invoke();
    }
}

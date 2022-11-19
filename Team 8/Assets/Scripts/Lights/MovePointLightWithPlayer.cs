using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointLightWithPlayer : MonoBehaviour
{
    void Update()
    {
        if (GameStatics.playerPosition != null) 
        { 
            transform.position = new Vector3(GameStatics.playerPosition.position.x, GameStatics.playerPosition.position.y + 1, transform.position.z); 
        }

    }
}

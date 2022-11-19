using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpotLightWithPlayer : MonoBehaviour
{
    void Update()
    {
        if (GameStatics.playerPosition != null)
        {
            transform.position = new Vector3(GameStatics.playerPosition.position.x-1, GameStatics.playerPosition.position.y+0.5f, transform.position.z);
        }

    }
}

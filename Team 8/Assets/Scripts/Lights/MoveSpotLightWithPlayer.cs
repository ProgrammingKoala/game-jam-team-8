using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpotLightWithPlayer : MonoBehaviour
{
    private bool isFlipped = false;
    private float previous;

    void Update()
    {
        if (GameStatics.playerPosition != null)
        {       
            //Debug.Log(previous);
            Flip(previous);
            if (isFlipped)
            {
                transform.position = new Vector3(GameStatics.playerPosition.position.x + 1, GameStatics.playerPosition.position.y + 0.5f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(GameStatics.playerPosition.position.x - 1, GameStatics.playerPosition.position.y + 0.5f, transform.position.z);
            }
            previous = GameStatics.playerPosition.position.x;
        }

    }

    void Flip(float previousX)
    {
        
        if (previousX < GameStatics.playerPosition.position.x && isFlipped)
        {
            Vector3 newRotation = new Vector3(0, 76, 0);
            transform.eulerAngles = newRotation;
            isFlipped = false;
        }
        else if (previousX > GameStatics.playerPosition.position.x && !isFlipped)
        {
            Vector3 newRotation = new Vector3(0, -76, 0);
            transform.eulerAngles = newRotation;
            isFlipped = true;
        }
    }
}

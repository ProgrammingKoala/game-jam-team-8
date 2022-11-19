using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveToAnotherRoomText : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    // Start is called before the first frame update
    void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        _tmp.alpha = 0f;
    }


    private void OnEnable()
    {
        GameEvents.onDoorCollision += ChangeVisibility;
    }

    private void OnDisable()
    {
        GameEvents.onDoorCollision -= ChangeVisibility;
    }

    private void ChangeVisibility(bool isPlayerTouchingDoor)
    {
        if(isPlayerTouchingDoor && _tmp != null)
        {
            // can be animation
            _tmp.alpha=1f;
        } 
        else
        {
            // can be animation
            _tmp.alpha=0f;
        }
    }
}

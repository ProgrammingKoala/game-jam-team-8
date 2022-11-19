using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Object _destinationScene;
    [SerializeField] private int _numOfRespown = 0;
    private bool _isPlayerColliding;

    private void Update()
    {
        if (_isPlayerColliding && Input.GetButton(ButtonNames.Action))
        {
            _isPlayerColliding = false;
            GameEvents.onDoorCollision(false);
            GameStatics.respownPointNumber = _numOfRespown;
            SceneManager.LoadScene(_destinationScene.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //TODO Zmieniec na const z tagami
        {
            GameEvents.onDoorCollision(true);
            _isPlayerColliding= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //TODO Zmieniec na const z tagami
        {
            GameEvents.onDoorCollision(false);
            _isPlayerColliding = false;
        }
    }
}

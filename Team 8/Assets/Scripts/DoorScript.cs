using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Object _destinationScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //TODO Zmieniec na const z tagami
        {

            //TODO Player Freeze
            //TODO Animation of moving to another scene
            Debug.Log(_destinationScene.name);
            SceneManager.LoadScene(_destinationScene.name);
        }
    }

    void OnEnable()
    {
        GameEvents.onDoorCollision += ;
    }


    void OnDisable()
    {
        EventManager.OnClicked -= Teleport;
    }


}

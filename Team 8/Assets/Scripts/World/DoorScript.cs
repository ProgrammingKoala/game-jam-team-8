using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Object _destinationScene;
    [SerializeField] private int _numOfRespown = 0;
    [SerializeField] private bool _needKey = false;
    [SerializeField] private bool _needGeneralPower = false;
    private bool _isClosed;
    private bool _isPlayerColliding;

    private void Start()
    {
        if ((_needKey && !GameStatics.haveKey) || (_needGeneralPower && !GameStatics.powerIsOn))
        {
            _isClosed= true;
        } 
        else
        {
            _isClosed = false;
        }
    }

    private void Update()
    {
        if(GameStatics.haveKey)
        {
            _needKey = false;
        }
        if (GameStatics.powerIsOn)
        {
            _needGeneralPower = false;
        }
        if (_isPlayerColliding && _isClosed && _needKey) 
        {
            GameEvents.onMessage("You need a key card");
        }
        else if (_isPlayerColliding && _isClosed && _needGeneralPower)
        {
            GameEvents.onMessage("You need to activate general power");
        }
        else if (_isPlayerColliding && Input.GetButton(ButtonNames.Action))
        {
            Debug.Log("Change scene");
            _isPlayerColliding = false;
            GameStatics.respownPointNumber = _numOfRespown;
            StartCoroutine(ReloadScene());
        }
        else if (_isPlayerColliding)
        {
            GameEvents.onMessage("Press E to interact");
        }
    }

    private IEnumerator ReloadScene()
    {
        GameEvents.onSceneChange();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(_destinationScene.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //TODO Zmieniec na const z tagami
        {
            _isPlayerColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //TODO Zmieniec na const z tagami
        {
            //GameEvents.onDoorCollision(false);
            _isPlayerColliding = false;
        }
    }
}

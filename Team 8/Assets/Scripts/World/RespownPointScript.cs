using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespownPointScript : MonoBehaviour
{
    [SerializeField] private int _respownPonitNumber = 0;
    [SerializeField] private GameObject _playerPrefab;

    private void OnEnable()
    {
        if(_respownPonitNumber == GameStatics.respownPointNumber)
        {
            Instantiate(_playerPrefab, transform.position, transform.rotation);
        }
    }
}

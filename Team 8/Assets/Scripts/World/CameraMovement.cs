using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _cameraSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player")?.transform;

        } else
        {
            Vector3 a = _player.transform.position;
            a.z = -10;
            transform.position = Vector3.MoveTowards(transform.position, a, _cameraSpeed * Time.deltaTime * Vector2.Distance(transform.position, a));
        }
    }
}

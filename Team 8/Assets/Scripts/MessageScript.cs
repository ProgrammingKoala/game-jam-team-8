using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    private bool _onCooldown;
    [SerializeField] private float _massageCooldown = 3;

    private void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        _tmp.text = "";
        _onCooldown = false;
    }

    private void OnEnable()
    {
        GameEvents.onMessage += DisplayMessage;
    }

    private void OnDisable()
    {
        GameEvents.onMessage -= DisplayMessage;
    }

    private void DisplayMessage(string message)
    {
        if(!_onCooldown) 
        {
            _tmp.text = message;
            StartCoroutine(Cooldown(_massageCooldown));
        }
    }

    private IEnumerator Cooldown(float cooldown)
    {
        _onCooldown= true;
        yield return new WaitForSeconds(cooldown);
        _onCooldown = false;
        _tmp.text = "";
    }
}

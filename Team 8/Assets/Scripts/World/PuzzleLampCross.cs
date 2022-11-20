using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLampCross : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool isEnabled = true;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        this.gameObject.SetActive(false);
        isEnabled = true;
    }

    public void SwitchLampState()
    {
        if (isEnabled)
            SetDisabled();
        else
            SetEnabled();
    }

    public void SetDisabled()
    {
        this.gameObject.SetActive(true);
        isEnabled = false;
    }

    public void SetEnabled()
    {
        this.gameObject.SetActive(false);
        isEnabled = true;
    }
}

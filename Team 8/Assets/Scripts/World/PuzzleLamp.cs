using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLamp : MonoBehaviour
{
    [SerializeField] private PuzzleLampCross plc;
    [SerializeField] public int lampNumber;
    [SerializeField] public bool isOn = true;
    [SerializeField] public bool isRed = true;
    private SpriteRenderer sr;
    private Color rememberColor;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetColor(Color.red);

        //test
        // StartCoroutine(party());
    }

    //zmiana koloru lampy na podany
    public void SetColor(Color color)
    {
        sr.color = color;
    }

    /*//test
    private IEnumerator party()
    {
        while (true)
        {
            SwitchLight();
            yield return new WaitForSeconds(1);
        }
    }*/

    //zmiana koloru czerowny/zielony
    public void SwitchColor()
    {
        if (plc.isEnabled)
        {   
            if (isRed)
            {
                SetColor(Color.green);
                isRed = false;
            }
            else
            {
                SetColor(Color.red);
                isRed = true;
            }
        }
    }

    //włączanie/wyłączanie lampy
    public void SwitchLight()
    {
        plc.SwitchLampState();
    }

    public void EnableLight()
    {
        plc.SetEnabled();
    }

}
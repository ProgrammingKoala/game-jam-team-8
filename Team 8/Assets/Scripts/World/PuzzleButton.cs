using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    [SerializeField] private int buttonNumber;
    [SerializeField] private PuzzleLamp lamp1;
    [SerializeField] private PuzzleLamp lamp2;
    [SerializeField] private PuzzleLamp lamp3;
    private int clicksNumber = 0;
    // public static List<PuzzleLamp> lampList;


    void Start()
    {
        // if (lampList == null)
        // {
        //     lampList = new List<PuzzleLamp>();
        //     for (int i = 0; i < 3; i++)
        //     {
        //         PuzzleLamp tmp = GetComponent<PuzzleLamp>();
        //         lampList.Add(tmp);
        //     }
        //     for (int i = 0; i < lampList.Count; i++)
        //     {
        //         Debug.Log(i);
        //     }
        // }

        StartCoroutine(party());
    }


    void Update()
    {
        
    }

    //test
    private IEnumerator party()
    {
        while (true)
        {
            PressButton();
            yield return new WaitForSeconds(1);
        }
    }

    void PressButton()
    {
        switch (buttonNumber)
        {
            case 1:
                //wyłączanie kolejnych świateł co kliknięcie
                SwitchLighting();
                break;
            case 2:
                //zmiana stanu świateł B C (D)
                lamp2.SwitchColor();
                lamp3.SwitchColor();
                break;
            case 3:
                //zmiana stanu świateł A C
                lamp1.SwitchColor();
                lamp3.SwitchColor();
                break;
            case 4:
                //zmiana stanu świateł A B (D)
                lamp1.SwitchColor();
                lamp2.SwitchColor();
                break;
            default:
                Debug.Log("none of buttons");
                break;
        }
    }


    private void SwitchLighting()
    {
        switch (clicksNumber)
        {
            case 0:
                lamp1.SwitchLight();
                clicksNumber++;
                break;
            case 1:
                lamp1.SwitchLight();
                lamp2.SwitchLight();
                clicksNumber++;
                break;
            case 2:
                lamp2.SwitchLight();
                lamp3.SwitchLight();
                clicksNumber++;
                break;
            case 3:
                lamp3.SwitchLight();
                clicksNumber = 0;
                break;
        }
    }
}

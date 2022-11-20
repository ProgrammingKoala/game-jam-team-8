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
    private bool _isPlayerColliding = false;
    private bool keyEPressed = false;

    //one-time bools for messages
    public static bool buttonsMessageShown = false;
    public static bool lampsMessageShown = false;
    public static bool powerOnMessageShown = false;


    void Start()
    {
        //StartCoroutine(ButtonPressing());
    }


    private void Update()
    {

        if (_isPlayerColliding && !buttonsMessageShown)
        {
            GameEvents.onMessage("Press E to push the button");
            buttonsMessageShown = true;
        }

        if (clicksNumber == 1 && !lampsMessageShown)
        {
            GameEvents.onMessage("You have to turn on all of the lights");
            lampsMessageShown = true;
        }

        
        if (_isPlayerColliding && Input.GetKeyDown(KeyCode.E) && !keyEPressed)
        {
            PressButton();
            keyEPressed = true;
        }
        

        if (Input.GetKeyUp(KeyCode.E))
        {
            keyEPressed = false;
        }


        if (_isPlayerColliding && !lamp1.isRed && !lamp2.isRed && !lamp3.isRed && !powerOnMessageShown)
        {
            ShowAllGreen();
            GameEvents.onMessage("Congrats, the Power is ON");
            powerOnMessageShown = true;
            GameStatics.powerIsOn = true;
        }

    }


    // private IEnumerator party()
    // {
    //     while (true)
    //     {
    //         PressButton();
    //         yield return new WaitForSeconds(1);
    //     }
    // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerColliding = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerColliding = false;
        }
    }
    
    // private IEnumerator party()
    // {
    //     while (true)
    //     {
    //         PressButton();
    //         yield return new WaitForSeconds(1);
    //     }
    // }


    //funkcjonalność przycisków
    private void PressButton()
    {
        if (!GameStatics.powerIsOn)
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
    }

    //wyłączanie kolejnych świateł co kliknięcie
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

    //pokazuje na koniec wszystkie na zielono
    private void ShowAllGreen()
    {
        lamp1.EnableLight();
        lamp2.EnableLight();
        lamp3.EnableLight();
    }
}

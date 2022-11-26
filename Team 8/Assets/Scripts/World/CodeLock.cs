using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;


    // private bool isVisible = false;
    private bool _isPlayerColliding = false;
    private bool isFieldOpen = false;
    private bool isCorrctCodeEntered = false;
    private bool isMessageDisplaying = false;



    void Start()
    {
        Hide();

        // int tmp = inputField.characterLimit.get();
        // Debug.Log(inputField.characterLimit);


        // Debug.Log(inputField.text.Length);
        // Debug.Log(inputField.characterLimit);


            player = GameObject.FindWithTag("Player");
            playerMovement = player.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        //tutaj bo w Start() za wcześnie próbowało złapać gracza i był NullPointer
        //if (player == null)
        //{
        //    player = GameObject.FindWithTag("Player");
        //    playerMovement = player.GetComponent<PlayerMovement>();
        //}

        //wyświetla instrukcje interakcji
        if (_isPlayerColliding && !isFieldOpen && !isCorrctCodeEntered)
        {
            GameEvents.onMessage("Press E to interact");
        }

        //pokazuje InputField + wyłącza ruch Playera
        if (_isPlayerColliding && Input.GetKeyDown(KeyCode.E))
        {
            if (!isCorrctCodeEntered)
            {
                isFieldOpen = true;
                playerMovement.SetFreeze();
                Show();
                inputField.Select();
            }
            else
            {
                isMessageDisplaying = true;
            }
        }


        //zamyka InputField
        if (isFieldOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
            playerMovement.SetUnFreeze();
            isFieldOpen = false;
        }
        

        //sprawdzanie poprawności podawanego kodu
        if (isFieldOpen && !isCorrctCodeEntered && inputField.text.Length == inputField.characterLimit)
        {
            if (!string.Equals(inputField.text, GameStatics.codeLockKey))
                GameEvents.onMessage("Wrong code! Provide correct code or press Esc to leave");
            else
            {
                isCorrctCodeEntered = true;
                GameStatics.haveKey = true;
                isMessageDisplaying = true;
                StartCoroutine(AutoCloseInputField());
            }
        }

        //wyświetla wiadomość pod wprowadzeniu właściwego kodu
        if (isFieldOpen && isCorrctCodeEntered && isMessageDisplaying)
            GameEvents.onMessage("Correct code! You found a Keycard");


        //wyświetlanie wiadomości pod zdobyciu Keycarda
        if (_isPlayerColliding && isMessageDisplaying && !isFieldOpen)
            GameEvents.onMessage("Already found a Keycard");

        //wyłącza wyświetlanie po odejściu od CodeLocka
        if (!_isPlayerColliding && isMessageDisplaying && !isFieldOpen)
            isMessageDisplaying = false;
    }

    //auto zamykanie InputField po podaniu poprawnego kodu
    private IEnumerator AutoCloseInputField()
    {
        yield return new WaitForSeconds(3);
        if (isFieldOpen)
        {
            Hide();
            playerMovement.SetUnFreeze();
            isFieldOpen = false;
        }
        isMessageDisplaying = false;
    }


    // show/hide dla input field
    private void Hide()
    {
        inputField.gameObject.SetActive(false);
    }

    private void Show()
    {
        inputField.gameObject.SetActive(true);
    }

    
    //collision detection
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
}

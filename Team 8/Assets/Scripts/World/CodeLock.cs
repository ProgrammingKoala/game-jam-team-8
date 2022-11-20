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
    private bool messageShown = false;
    private bool isFieldOpen = false;



    void Start()
    {
        Hide();

        // int tmp = inputField.characterLimit.get();
        // Debug.Log(inputField.characterLimit);

        
        // Debug.Log(inputField.text.Length);
        // Debug.Log(inputField.characterLimit);
    }


    void Update()
    {
        //tutaj bo w Start() za wcześniej próbowało złapać gracza i był NullPointer
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            playerMovement = player.GetComponent<PlayerMovement>();
        }

        
        if (_isPlayerColliding && !messageShown)
        {
            GameEvents.onMessage("Press E to interact");
        }

        //otworzenie CodeLocka
        if (_isPlayerColliding && Input.GetKeyDown(KeyCode.E))
        {
            messageShown = true;
            Show();
            // playerMovement.SetFreeze();
            inputField.Select();
            isFieldOpen = true;
        }

        //zamknięcie CodeLocka
        if (isFieldOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
            playerMovement.SetUnFreeze();
            isFieldOpen = false;
        }
        

        //sprawdzanie poprawności podawanego kodu
        if (inputField.text.Length == inputField.characterLimit && isFieldOpen)
        {
            if (!string.Equals(inputField.text, GameStatics.codeLockKey))
                GameEvents.onMessage("Wrong code! Provide correct code or press Esc to leave");
            else
            {
                GameEvents.onMessage("Correct code! You found a key");
                StartCoroutine(CloseInSeconds(3f));
            }
        }
    }

    private IEnumerator CloseInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (isFieldOpen)
        {
            Hide();
            playerMovement.SetUnFreeze();
            isFieldOpen = false;
        }
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

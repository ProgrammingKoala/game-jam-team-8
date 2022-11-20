using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockKey : MonoBehaviour
{
    
    private bool _isPlayerColliding = false;
    private bool isIntroduced = false;
    private bool isRead = false;
    private bool isClosed = false;
    private bool displayCodeRuning = false;
    private bool thoughtRuning = false;
    


    void Start()
    {
        
    }


    void Update()
    {
        //wyświetla introduction interakcji 
        if (_isPlayerColliding && !isIntroduced)
        {
            GameEvents.onMessage("Press E to interact");

            // i uruchamia wyświetlanie CodeLockKey po odpaleniu
            if (Input.GetKeyDown(KeyCode.E))
            {
                isIntroduced = true;

                // !isRead && !displayCodeRunning
                StartCoroutine(displayCode());
                isRead = true;                
            }
        }

        //ponowne uruchomienia wyswietlenia kodu
        if (_isPlayerColliding && isIntroduced && !displayCodeRuning && !thoughtRuning)
        {
            // !isRead && !displayCodeRunning
            StartCoroutine(displayCode());
            isRead = true;
        }

        //odpalenie podpowiedzi do kodu
        if (isRead && !thoughtRuning && !displayCodeRuning && !isClosed)
        {
            StartCoroutine(thought());
            isClosed = true;

            //setup pod ponowne uruchomienie
            // isRead = false;
        }


        //wyswietla CodeLockKey w trakcie działania korutyny
        if (displayCodeRuning)
            GameEvents.onMessage("Secret number: 2_37");
        
        //wyświetla podpowiedź w trakcie działania korutyny
        if (thoughtRuning)
            GameEvents.onMessage("Hmm, one digit was hidden");

    }

    private IEnumerator displayCode()
    {
        displayCodeRuning = true;
        yield return new WaitForSeconds(3);
        displayCodeRuning = false;
    }


    private IEnumerator thought()
    {
        thoughtRuning = true;
        yield return new WaitForSeconds(3);
        thoughtRuning = false;
    }


    
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

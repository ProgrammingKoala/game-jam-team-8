using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockKey : MonoBehaviour
{
    
    private bool _isPlayerColliding = false;
    private bool isIntroduced = false;
    private bool displayCodeRuning = false;
    private bool thoughtRuning = false;
    


    void Update()
    {
        //wyświetla instrukcje interakcji 
        if (_isPlayerColliding && !isIntroduced)
        {
            GameEvents.onMessage("Press E to interact");

        }

        // uruchamia wyświetlanie CodeLockKey po odpaleniu
        if (_isPlayerColliding && Input.GetKeyDown(KeyCode.E) && !displayCodeRuning && !thoughtRuning)
        {
            isIntroduced = true;
            StartCoroutine(displayCode());
            //Hide();
        }


        //wyswietla CodeLockKey w trakcie działania korutyny
        if (displayCodeRuning)
            GameEvents.onMessage("Secret number: 2_37");
        

        //wyświetla podpowiedź w trakcie działania korutyny
        if (thoughtRuning)
            GameEvents.onMessage("Hmm, one digit was hidden, but this number seems familiar");

    }

    private IEnumerator displayCode()
    {
        Debug.Log("display Code");
        displayCodeRuning = true;
        yield return new WaitForSeconds(3);
        displayCodeRuning = false;

        //od razu uruchamia podpowiedź
        StartCoroutine(thought());
    }


    private IEnumerator thought()
    {
        Debug.Log("display Hint");
        thoughtRuning = true;
        yield return new WaitForSeconds(3);
        thoughtRuning = false;
    }


    //ukrywa obiekt
    private void Hide()
    {
        this.gameObject.SetActive(false);
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

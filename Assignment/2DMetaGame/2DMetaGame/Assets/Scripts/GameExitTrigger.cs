using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitTrigger : MonoBehaviour
{
    private bool isPlayerNear = false;

    [SerializeField] private GameObject exitMessageText; 

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (exitMessageText != null)
                exitMessageText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (exitMessageText != null)
                exitMessageText.SetActive(false);
        }
    }
}

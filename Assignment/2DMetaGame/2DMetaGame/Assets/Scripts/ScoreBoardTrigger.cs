using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoardPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreBoardPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreBoardPanel.SetActive(false);
        }
    }
}

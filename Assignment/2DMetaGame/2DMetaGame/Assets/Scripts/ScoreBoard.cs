using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI bestComboText;

    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        int bestCombo = PlayerPrefs.GetInt("BestCombo", 0);

        bestScoreText.text = $"BestScore: {bestScore}";
        bestComboText.text = $"BestCombo: {bestCombo}";
    }
}

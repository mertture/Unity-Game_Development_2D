using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameSession;
    public void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}

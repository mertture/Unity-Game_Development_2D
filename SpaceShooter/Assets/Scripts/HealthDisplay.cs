using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Player player;
    public void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    public void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}

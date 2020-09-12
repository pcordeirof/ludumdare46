using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class Score : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI scoreText;
    
    void Update()
    {
        scoreText.text = player.score.ToString();
    }
}

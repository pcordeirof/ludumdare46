using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Lifes : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI lifeText;

    // Update is called once per frame
    void Update()
    {
        lifeText.text = player.lifesScore.ToString();
    }
}

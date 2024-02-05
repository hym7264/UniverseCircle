using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()

    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text =  PlanetSpawner.bestscore.ToString();
    }
}

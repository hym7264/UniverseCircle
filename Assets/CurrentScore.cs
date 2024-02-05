using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CurrentScore : MonoBehaviour
{
    public TMP_Text scoreText; 
    // Start is called before the first frame update
    void Start()

    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score:"+PlanetSpawner.score.ToString();
    }

    // Update is called once per frame
    
}

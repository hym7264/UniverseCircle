using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BestScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()

    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Best Score:" + PlanetSpawner.bestscore.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetPrefab; // ������ Planet �������� �Ҵ�
    
    private bool canSpawn = true;
    private List<Transform> prefabList = new List<Transform>(); // �����յ��� Transform�� �����ϴ� ����Ʈ
    public static int score = 0;
    public static int bestscore = 0;
    public bool isOver;
    public TMP_Text scoreText;
    public BackgroundMusic backgroundMusic;
    int planetlevel;
    int number;
    
       // Start is called before the first frame update

    void Start()
    {
        score = 0;

        
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && canSpawn)
        {
            StartCoroutine(SpawnAfterDelay(2.0f)); // 1�� �ڿ� Spawn �Լ� ȣ��
        }
       

    }

    IEnumerator SpawnAfterDelay(float delay)
    {
        canSpawn = false; // ���� �ð� ���� ���� ����
        yield return new WaitForSeconds(delay);
        Planet newPlanet = SpawnPlanet();
        newPlanet.StartSpawnAnimation();
        GetComponent<AudioSource>().Play();
        canSpawn = true; // �ٽ� ���� ���
        
            
            
      
            
        

    }
    // Update is called once per frame
     Planet SpawnPlanet()
    {
        // Planet �������� ���� ��ġ�� ����
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0; // Z ���� 0���� ����
        GameObject newPlanet = Instantiate(planetPrefab, spawnPosition, Quaternion.identity);

        // ������ AddPrefab(); Planet ��ũ��Ʈ�� �ִٸ� �ʱ�ȭ
        Planet planetScript = newPlanet.GetComponent<Planet>();
        planetScript.level = Random.Range(0, 3); // ���� ������ �����ϼ���.

        
        
            // ������ �༺�� �ִϸ����͸� �����մϴ�.
        planetScript.planetAnimator = newPlanet.GetComponent<Animator>();
        planetScript.planetSpawner = this;
        return planetScript;
        
    }
    
    public BackgroundMusic GetBackgroundMusic()
    {
        return backgroundMusic;
    }

    public void Gameover(BackgroundMusic backgroundMusic)
    {
        if (isOver)
        {
            return;
        }
        isOver = true;
        
        SceneManager.LoadScene("GameOver");
        
        if (score > bestscore)
        {
            bestscore = score;
        }

        BackgroundMusic.instance.StopMusic();
    }
   void LateUpdate()
    {
        scoreText.text = score.ToString();
    }

   

}





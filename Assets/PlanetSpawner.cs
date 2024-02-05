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
    public GameObject planetPrefab; // 생성할 Planet 프리팹을 할당
    
    private bool canSpawn = true;
    private List<Transform> prefabList = new List<Transform>(); // 프리팹들의 Transform을 저장하는 리스트
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
            StartCoroutine(SpawnAfterDelay(2.0f)); // 1초 뒤에 Spawn 함수 호출
        }
       

    }

    IEnumerator SpawnAfterDelay(float delay)
    {
        canSpawn = false; // 일정 시간 동안 생성 막음
        yield return new WaitForSeconds(delay);
        Planet newPlanet = SpawnPlanet();
        newPlanet.StartSpawnAnimation();
        GetComponent<AudioSource>().Play();
        canSpawn = true; // 다시 생성 허용
        
            
            
      
            
        

    }
    // Update is called once per frame
     Planet SpawnPlanet()
    {
        // Planet 프리팹을 생성 위치에 생성
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0; // Z 축은 0으로 설정
        GameObject newPlanet = Instantiate(planetPrefab, spawnPosition, Quaternion.identity);

        // 생성된 AddPrefab(); Planet 스크립트가 있다면 초기화
        Planet planetScript = newPlanet.GetComponent<Planet>();
        planetScript.level = Random.Range(0, 3); // 레벨 범위를 조정하세요.

        
        
            // 생성된 행성의 애니메이터를 설정합니다.
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





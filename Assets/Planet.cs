using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Planet : MonoBehaviour
{
    public float moveSpeed=0.5f;
    Rigidbody2D rb;
    private bool isDown=false;
    public int level;
    public Animator planetAnimator;
   

    public PlanetSpawner planetSpawner;
    private float timeInsideFinish = 0f;
    SpriteRenderer sr;
    public CircleCollider2D circle;
    public Button yourUIButton; // UI 버튼을 Inspector에서 할당해야 합니다.
    public CircleCollider2D planetCollider;
    public AudioClip[] audio;
    public AudioSource audioSource;
    public float windpower = 2f;
    public float power = 5f; // 바람의 힘
   
    public static Planet instance;   //변수 선언부// 
   
    public AudioClip bibaudio;

    public float moveSpeed2 = 5f;

    private static bool canMove=true;
    public static bool windMove=true;
    //private bool moveLeft = true; // 왼쪽으로 이동하는지 여부

    // Start is called before the first frame update
    //동글이의 이동
    //1.마우스를 따라서이동하는 물체
    //2.마우스를 클릭하면 동글이는 떨어짐
    //동글이의 생성
    //
    //

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.simulated = false;
        planetAnimator = GetComponent<Animator>();
        // 버튼의 클릭 이벤트에 OnButtonClick() 메소드를 연결합니다.
        
        sr = GetComponent<SpriteRenderer>();
        planetCollider = GetComponent<CircleCollider2D>(); // Collider 할당 추가
        instance = this;

        canMove = GodModeToggle.isGodMode;
        windMove= WindModeToggle.isWindMode;


    }
    private void Start()
    {
        
    }




    // Update is calaled once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
            rb.simulated = true;


        }
        if (!isDown)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition.y = 4.25f;
            mousePosition.z = 0;
            // -3.1과 3.1 범위 내에서만 움직이도록 제한
            mousePosition.x = Mathf.Clamp(mousePosition.x, -1.7f + transform.localScale.x / 2f, 1.7f - transform.localScale.x / 2f);

            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed2);

        }
        if (canMove)
        {
            // 움직임 활성화 상태일 때만 움직입니다.
            Move();
        }
        if (windMove) 
        {
            windMovement();
        }











    }
    public void StartSpawnAnimation()
    {
        planetAnimator.SetInteger("Level", level);
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Planet otherPlanet = collision.gameObject.GetComponent<Planet>();

            // 충돌한 행성의 레벨이 같을 때만 처리
            if (otherPlanet.level == level &&level != 7 && otherPlanet.level != 7)
            {
                
                ContactPoint2D contactPoint = collision.GetContact(0);


                // 충돌 지점의 좌표로 현재 위치 변경
                transform.position = contactPoint.point;
               

                // 충돌한 행성 중 하나만 파괴
                Destroy(collision.gameObject);

                // 현재 행성의 레벨을 증가시켜 다음 레벨의 애니메이션을 시작
                level++;
                planetAnimator.SetInteger("Level", level);

                PlanetSpawner.score += 10*((int)Mathf.Pow(2,level));
                if (planetCollider != null && otherPlanet.planetCollider != null)
                {
                    Physics2D.IgnoreCollision(planetCollider, otherPlanet.planetCollider);
                }
                
                audioSource.Play();

            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Finish") )
        {
            timeInsideFinish += Time.deltaTime;

            if (timeInsideFinish >= 3f)
            {


                // 예시로 빨간색으로 변화하는 코드
               
                sr.color = new Color(0.9f,0.2f,0.2f);
                AudioSource.PlayClipAtPoint(bibaudio, transform.position);


                
                

            }
            if (timeInsideFinish >= 5f)
            {

                planetSpawner.Gameover(planetSpawner.GetBackgroundMusic());

            }
        }
    }

    // OnTriggerExit2D 함수 추가
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {

            timeInsideFinish = 0f; // 행성이 떠날 때 초기화
            sr.color = Color.white;
        }
    }



    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb.AddForce(Vector3.left * power);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            rb.AddForce(Vector3.right * power);
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            rb.AddForce(Vector3.up * power);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb.AddForce(Vector3.back * power);
        }
    }
    void windMovement(){ // 블랙홀 구현 

        Vector3 moveDirection = Vector3.up;

    // 이동 벡터를 정규화하여 방향은 유지하되 속도를 조절
        Vector3 movement = moveDirection.normalized * windpower * Time.deltaTime;

    // 화면 왼쪽 끝에 도달했을 때 이동 중단

    transform.Translate(movement);
    

    }

    // 토글의 상태를 변경할 때마다 호출되는 메서드
   







}
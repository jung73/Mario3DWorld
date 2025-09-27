using UnityEngine;
using System.Collections;


public class goomba : MonoBehaviour
{
    public float movementSpeed = 10f; // 굼바의 이동 속도
    public float rotationSpeed = 15f; // 굼바의 회전 속도
    public float detectionRadius = 9f; // 마리오를 감지할 반경
    private float attackRange = 2f;  //굼바가 공격할 거리

    private Rigidbody rb;
    public GameObject player; // 마리오 객체
    private Animator animator;
    private bool isDead = false;


    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Die = Animator.StringToHash("Die");

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        //animator.Play("Wait");
        
        player = GameObject.FindGameObjectWithTag("Mario");
        // "Mario" 태그로 설정된 오브젝트 찾기, hierachy에서 마리오에 태그 설정
        

    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Mario");
        }
        if (isDead || player == null) return;
        
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        

        if (distanceToPlayer <= attackRange)
        {
            // 공격 범위에 들어오면 이동을 멈추고 공격
            animator.SetTrigger("Attack"); 
            RotateTowardsPlayer(); 
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            MoveTowardsMario(); // 마리오를 향해 이동
            RotateTowardsPlayer(); // 플레이어를 향해 회전
        }
        else // 플레이어가 감지 범위를 벗어났을 때
        {
            // 대기 상태
            animator.SetBool(IsRunning, false); // 멈춤
        }
        
    }

    void MoveTowardsMario()
    {
        // 마리오를 향해 굼바를 이동시키는 방향 계산
        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0; //y固定
        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        // 굼바 이동
        animator.SetBool(IsRunning, true);
        rb.MovePosition(rb.position + movement);
    }


    void RotateTowardsPlayer()
    {
        // 플레이어를 향하는 방향 벡터 계산
        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0; //y固定


        // 굼바가 플레이어를 향하도록 회전, 방향이 0이 아닐 때만
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage()
    {
        if (isDead) return;
        isDead=true;

        

        GetComponent<Collider>().enabled = false;
        rb.isKinematic = true; // 물리 효과 중지
        movementSpeed = 0; // 이동 중지

        StartCoroutine(DieSequence());
       
    }

    // 죽는 과정을 순서대로 처리하는 코루틴
    private IEnumerator DieSequence()
    {
        animator.SetTrigger("Damaged");// 죽는 애니메이션 재생

        // 애니메이션이 재생될 시간을 대기
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        // 죽은 굼바
        if (isDead) return;

        if (collision.gameObject.CompareTag("Mario"))
        {
            
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.Hit(); // 마리오에게 데미지를 줍니다.
            }
            
        }
    }

    

    // 플레이어와 충돌했을 때 호출되는 함수
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        

        Vector3 normal = collision.contacts[0].normal;


        if (collision.gameObject.CompareTag("Mario"))
        {
            // 만약 마리오가 굼바 위에 있고, 아래 방향으로 내려온다면
            if (normal.y > 0.2f)
            {
                TakeDamage(); //죽는 과정
            }
            
        }
    }
    */
}

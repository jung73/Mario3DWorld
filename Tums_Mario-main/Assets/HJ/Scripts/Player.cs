using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 15;
    float hAxis;
    float vAxis;
    bool wDown;
    bool jDown;
    bool isJump;
    public Transform tf;

    Vector3 moveVec;

    Animator anim;
    Rigidbody rigid;

    public int health = 3;

    public static int coin = 0;

    public AudioSource jumpadio;
    

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        ClimbWall();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    //������
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        speed = 15;
        if (wDown == true)
        {
            speed = 7;
        }
        

        /*moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //if (isJump)
            

        Vector3 newPos = transform.position + moveVec * speed * Time.deltaTime;

        rigid.MovePosition(newPos);

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        speed = wDown ? 7 : 15;*/
    }

    void Turn() //ȸ��
    {
        if (moveVec != Vector3.zero) // moveVec�� 0�� �ƴ� ���� ȸ��
        {
            transform.LookAt(transform.position + moveVec);
        }
    }

    //����
    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
            jumpadio.Play();
        }
    }

    //�浹
    private void OnCollisionEnter(Collision collision)
    {
        //���� ������ ���ϰ�
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }

        //�Ǳ��̰�
        if (collision.gameObject.tag == "Goomba")
        {
            health -= 1;
        }
    }

    //��� 
    public void Die()
    {
        if (health == 0)
        {
            Debug.Log("Player is dead.");
        }
    }

    //���� 
    public void Hit()
    {
        health--;
        Debug.Log($"health: {health}");
        if (health <= 0)
        {
            Die();
        }
        tf.localScale = new Vector3(1.2f, 1f, 1.2f);
    }

    void ClimbWall()
    {
        // �÷��̾ Ư�� �������� �̵��ϰ� �ִ��� Ȯ��
        if (moveVec.magnitude > 0)
        {
            // �÷��̾� �ٷ� �� �������� ����ĳ��Ʈ �߻�
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                // ����ĳ��Ʈ�� ���� ������ �ش� ���� ���� �� �ְ� ��
                if (hit.collider.CompareTag("Wall"))
                {
                    float distanceToWall = hit.distance;

                    // ������ �ݰ� �ȿ� ������ ���� ���� ���� Ʈ���� ȣ��
                    if (distanceToWall < 10f)
                    {
                        // ���� ���� Ʈ���� ȣ��
                        jumpForce = 30f;
                    }
                    else jumpForce = 15f;
                }
            }
            else jumpForce = 15f;
            /*else
            {
                // ����ĳ��Ʈ�� ���� ���� ���� ���¿����� ������ �ݰ� �ȿ� ������ ���� ���� ���� Ʈ���� ȣ��
                if (Vector3.Distance(transform.position, hit.point) < 10f)
                {
                    // ���� ���� Ʈ���� ȣ��
                    jumpForce = 25f;
                }
                else jumpForce = 30f;
            }*/
        }
    }
    

}

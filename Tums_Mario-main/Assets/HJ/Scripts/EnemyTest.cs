/*충돌 양식 
 *
public GameObject player; 선언하고 

 private void OnTriggerEnter(Collider collider) //유의: 트리거, ontrigger체크 
//파괴되지 않는 것은 OnCollisionEnter(Collision collision)
    {
        if (collider.gameObject.tag == "Mario")
        {
            Debug.Log("부딪");

            Destroy(gameObject); //파괴할거면 넣어라
             

            if (player != null)
            {
                //동작내용
            }
            else
            {
                // 새 플레이어(고양이 마리오)를 찾아서 내용. 
                GameObject newPlayer = GameObject.FindGameObjectWithTag("Mario");
                if (newPlayer != null)
                {
                    //동작내용
                }
                else
                {
                    Debug.LogWarning("플레이어가 null");
                }
            }
        }
    }
 
 
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public GameObject player;
    public Player player1;

    // Start is called before the first frame update
    void Start()
    {
        player1 = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            Debug.Log("부딪");



            player1.Hit(); //맞음
            
            
        }
    }
}

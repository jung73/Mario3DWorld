using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; //회전을 위한 

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * -1 * Time.deltaTime); //제자리회전
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Mario")
        {
            Debug.Log("부딪");

            Destroy(gameObject);
             

            if (player != null)
            {
                //코인양1 늘리는 코드 작성해야됨
                Player.coin++;
                Debug.Log($"coin: {Player.coin}");
            }
            else
            {
                // 새 플레이어(고양이 마리오)를 찾아서 내용. 
                GameObject newPlayer = GameObject.FindGameObjectWithTag("Mario");
                if (newPlayer != null)
                {
                    //코인양1 늘리는 코드 작성해야됨
                    Player.coin++;
                    Debug.Log($"coin: {Player.coin}");
                }
                else
                {
                    Debug.LogWarning("플레이어가 null");
                }
            }
        }
    }
}

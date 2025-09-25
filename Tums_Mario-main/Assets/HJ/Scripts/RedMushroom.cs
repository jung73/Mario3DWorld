using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
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

            Destroy(gameObject);

            if (player != null)
            {
                player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else
            {
                // 새 플레이어(고양이 마리오)를 찾아서 크기를 변경
                GameObject newPlayer = GameObject.FindGameObjectWithTag("Mario");
                if (newPlayer != null)
                {
                    newPlayer.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                else
                {
                    Debug.LogWarning("플레이어가 null");
                }
            }
        }

    
    }
}

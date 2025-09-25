using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bell : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision) //벨을 먹으면... 
    {
        if (collision.gameObject.tag == "Mario") //마리오와 부딪히면
        {
            Debug.Log("벨 부딪");

            Destroy(gameObject);

            //catMario로 체인지, 메인카메라의 target바꿔줌 
            SwitchPlayer switchPlayer = GetComponent<SwitchPlayer>();
            if (switchPlayer != null)
            {
                // 고양이 마리오로 전환
                switchPlayer.SwitchToCat();
            }

        }
    }
}

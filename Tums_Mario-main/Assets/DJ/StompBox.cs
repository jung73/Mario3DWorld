using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampBox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 부딪힌 오브젝트의 태그가 Goomba라면
        if (other.CompareTag("Goomba"))
        {
            //Goomba 스크립트를 가져와서 takedamage() 함수를 직접 호출
            goomba goomba = other.GetComponent<goomba>();
            if (goomba != null)
            {
                goomba.TakeDamage();
            }
        }
    }
    
}

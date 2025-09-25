using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject marioPrefab; // 마리오 프리팹
    public GameObject catmarioPrefab; // 고양이마리오 

    public GameObject currentCharacter; // 현재 캐릭터

    public Follow follow;



    private void Start()
    {
        follow = Camera.main.GetComponent<Follow>();
        currentCharacter = GameObject.Find("Mario");

    }


    // 마리오로 캐릭터 전환
    public void SwitchToMario()
    {
        // 이전 캐릭터가 있으면 삭제
        if (currentCharacter != null)
            Destroy(currentCharacter);

        // 마리오 프리팹을 현재 위치에 생성
        currentCharacter = Instantiate(marioPrefab, transform.position, transform.rotation);

        //switch했다는 사실을 알려줌
        follow.isSwitch = true;
        Debug.Log("isSwitch = true");
    }

    // 고양이마리오로 캐릭터 전환
    public void SwitchToCat()
    {
        // 이전 캐릭터가 있으면 삭제
        if (currentCharacter != null)
            Destroy(currentCharacter);

        // 고양이마리오 프리팹을 현재 위치에 생성
        currentCharacter = Instantiate(catmarioPrefab, transform.position, transform.rotation);

        //switch했다는 사실을 알려줌
        follow.isSwitch = true;
        Debug.Log("isSwitch = true");
    }
}

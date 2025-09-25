using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Button triggerButton; // 나타날 버튼
    public GameObject objectToTrigger; // 트리거할 오브젝트
    public AudioSource audioEnd;
    public START audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했는지 확인
        {
            triggerButton.gameObject.SetActive(true); // 버튼 활성화
            PauseGame(); // 게임 정지
            
            audioEnd.Play();

        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // 게임 속도를 0으로 설정하여 정지
        audio.adioMain.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class START : MonoBehaviour
{
    public Button startButton; // 게임 시작 버튼
    public Button triggerButton; // 끝
    public GameObject objectToTrigger; 
    public AudioSource adioMain;
    public AudioSource adioStop;


    private void Start()
    {
        // 시작 버튼 클릭 시 게임 시작 함수 호출
        startButton.onClick.AddListener(StartGame);

        // 게임 시작 시 정지
        PauseGame();
    }

    void StartGame()
    {
        ResumeGame(); // 게임 시작 시 정지 상태 해제
        startButton.gameObject.SetActive(false);
        adioMain.Play();
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // 게임 속도를 0으로 설정하여 정지
        adioMain.Stop();
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // 게임 속도를 1로 설정하여 재개
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mario")) // 플레이어와 충돌했는지 확인
        {
            triggerButton.gameObject.SetActive(true); // 버튼 활성화
            adioMain.Stop();
            PauseGame(); // 게임 정지
            adioStop.Play();
        }
    }
}

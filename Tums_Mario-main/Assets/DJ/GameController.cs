using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // 싱글톤 패턴을 사용하여 인스턴스 생성

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 굼바에게 공격을 당했을 때 마리오가 damage를 받는 부분
    public void PlayerDamaged()
    {
        //데미지를 입는 로직 추가
    }

    // 마리오의 생명이 다 끝났을 때
    public void GameOver()
    {
        // 게임 오버 로직 추가

    }
}

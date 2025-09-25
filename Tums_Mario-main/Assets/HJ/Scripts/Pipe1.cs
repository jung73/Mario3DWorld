using UnityEngine;

public class Pipe2 : MonoBehaviour
{
    public Transform destinationCube; // 이동할 목적지 큐브의 Transform
    public float offsetDistance = 1f;
    public float ZDistance = 0f;
    public float YDistance = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mario")) // 플레이어와 충돌했는지 확인
        {
            Vector3 offset = new Vector3(offsetDistance, ZDistance, YDistance); // x축으로 offsetDistance 만큼 이동할 벡터 생성
            other.transform.position = destinationCube.position + offset; // 플레이어 위치를 목적지 큐브의 위치로 변경
        }
    }
}

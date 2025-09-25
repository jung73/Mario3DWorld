using UnityEngine;

public class TagCheck : MonoBehaviour
{
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Mario");
        Debug.Log("Mario 태그 오브젝트 개수: " + objs.Length);
        foreach (var obj in objs)
        {
            Debug.Log("찾은 오브젝트: " + obj.name);
        }
    }
}

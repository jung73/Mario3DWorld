using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public string targetTag = "Mario";
    private GameObject targetObject;
    public Transform target;
    public Vector3 offset;
    public bool isSwitch = false;
    public Vector3 initialPosition;
    public float yOffset = 2.0f;

    // 줌인 및 줌아웃에 사용될 변수
    public float zoomSpeed = 2.0f;
    public float minZoomDistance = 2.0f;
    public float maxZoomDistance = 10.0f;

    private float currentZoomDistance;

    // Start is called before the first frame update
    void Start()
    {
        FindAndTarget(); //시작할 때 타겟 한번 찾음
        transform.position = initialPosition;
        currentZoomDistance = offset.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 휠 입력 감지
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0)
        {
            // 줌인 및 줌아웃
            currentZoomDistance -= scrollWheelInput * zoomSpeed;
            currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        }

        if (isSwitch) //스위치되었으면
        {
            FindAndTarget(); //타겟 한번 찾고
            Debug.Log("타겟을찾다");
            isSwitch = false; //isswitch내리고 
        }
        else if (target != null && target.transform != null)
        {
            Vector3 desiredPosition = target.position - transform.forward * currentZoomDistance + new Vector3(0, yOffset, 0);

            transform.position = desiredPosition;
        }
    }

    public void FindAndTarget() //타겟찾음
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }
}

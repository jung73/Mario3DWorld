using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mario")
        {
            anim.SetTrigger("Break");
            Debug.Log("ºÎµú");

            Destroy(gameObject);

        }
    }
}

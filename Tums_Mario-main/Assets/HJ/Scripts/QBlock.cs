using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBlock : MonoBehaviour
{
    private Animator anim;
    public GameObject prefab_BlockEmpty;
    private int jumpCount = 0;
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
            Debug.Log("ºÎµúÈû");
            jumpCount++;
            if (jumpCount == 5)
            {
                jumpCount = 0;
                GameObject BlockEmpty = Instantiate(prefab_BlockEmpty, 
                  transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}

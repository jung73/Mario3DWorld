using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBlockCatMush : MonoBehaviour
{
    private Animator anim;
    public GameObject prefab_BlockEmpty;
    public GameObject prefab_CatMushroom;
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
            GameObject BlockEmpty = Instantiate(prefab_BlockEmpty, 
                  transform.position, transform.rotation);
            Destroy(gameObject);
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            GameObject NewCatMushroom = Instantiate(prefab_CatMushroom, newPosition, newRotation);

            NewCatMushroom.AddComponent<MoveObject>();

        }
    }
}

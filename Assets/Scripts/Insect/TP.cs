using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    MovementInsect test;
    public GameObject otherTel;

    private void Start()
    {
        //BoxCollider2D test =  this.gameObject.GetComponent<BoxCollider2D>();
        this.gameObject.GetComponent<BoxCollider2D>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Equals("Insect"))
        {
            test = collision.gameObject.GetComponent<MovementInsect>();
            test.usingPwr = false;
            if (test.usingPwr == true)
            {
                collision.gameObject.transform.position = new Vector3(otherTel.transform.position.x, otherTel.transform.position.y, collision.transform.position.z);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Insect"))
        {
            test = collision.gameObject.GetComponent<MovementInsect>();
            if (test.usingPwr == true)
            {
                test.usingPwr = false;
                collision.gameObject.transform.position = new Vector3(otherTel.transform.position.x, otherTel.transform.position.y, collision.transform.position.z);
            }
        }
    }
}

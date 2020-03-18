using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkOwl : MonoBehaviour
{
    SpriteRenderer someSprite;
    private void Start()
    {
        someSprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Owl"))
        {
            someSprite.enabled = false;
        }
    }
}

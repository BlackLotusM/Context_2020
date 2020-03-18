using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeTrap : MonoBehaviour
{
    [SerializeField]
    public float currentTime, minWaitTime, maxWaitTime;
    [SerializeField]
    public int spikesOut = 3;

    public SpriteRenderer spriteRenderer;
    public Sprite t_0;
    public Sprite t_1;


    void Start()
    {
        spriteRenderer = spriteRenderer.GetComponent<SpriteRenderer>();
        currentTime = Random.Range(minWaitTime, maxWaitTime);

    }


    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            StartCoroutine(Spikes());
        }
    }

    IEnumerator Spikes()
    {
        SpikeOut();
        yield return new WaitForSeconds(spikesOut);
        SpikeIn();
    }

    void SpikeOut()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = t_1;
        }
    }

    void SpikeIn()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = t_0;
        }
        spriteRenderer.sprite = t_0;
        currentTime = Random.Range(minWaitTime, maxWaitTime);
    }
}




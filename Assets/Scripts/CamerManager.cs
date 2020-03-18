using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera TopLeftCam;
    public Camera TopRightCam;
    public Camera BottomLeftCam;
    public Camera BottomRightCam;

    void Start()
    {
        TopLeftCam.rect = new Rect(0, 0, 0.5f, 1);
        TopRightCam.rect = new Rect(0.5f, 0, 0.5f, 1);
        //BottomLeftCam.rect = new Rect(0, 0, 0.5f, 0.5f);
        //BottomRightCam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

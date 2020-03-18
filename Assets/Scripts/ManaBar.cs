using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image barImage; //Component

    public float ManaNumber;//Value

    public bool overuse;

    public Image ManaChange;

    private void Start()
    {
        ManaChange = barImage.GetComponent<Image>();
    }
    private void Update()
    {
        
        if (overuse == true)
        {
            ManaChange.color = Color.red;
        }
        else if(overuse == false)
        {
            ManaChange.color = Color.blue;
        }
        
        if(ManaNumber > 1)
        {
            ManaNumber = 1;
        }
        if (ManaNumber < 0)
        {
            ManaNumber = 0;
        }

        barImage.fillAmount = ManaNumber;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salamander : MonoBehaviour
{
    private float _verticalInput = 0;
    private float _horizontalInput2 = 0;

    public bool usingPwr;

    public float mana;

    public int movementSpeed = 0;
    public int rotationSpeed = 0;

    public bool overuse;
    int time;
    ManaBar ScriptMana;

    Rigidbody2D rb2d;
    void Start()
    {
        mana = 1f;
        usingPwr = false;
        overuse = false;
        ScriptMana = GetComponent<ManaBar>();
        ScriptMana.overuse = false;

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        GetPlayerInput();
        RotatePlayer();
        MovePlayer();
        SpecialMove();
        OveruseCheck();
    }

    private void OveruseCheck()
    {

        if (overuse == true)
        {
            time = time + 1;

            if(mana < 1)
            {
                mana = mana + 0.005f;
            }
            if (time >= 600)
            {
                overuse = false;
                ScriptMana.overuse = false;
            }
        }
        else if (overuse == false)
        {
            time = 0;
        }
    }

    public float delayTime = 0.35F;
    private float next = 0.35F;
    private float myTime = 0.0F;


    private void SpecialMove()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > next)
        {
            next = myTime + delayTime;

            if (overuse == true)
            {
                usingPwr = false;
            }
            else
            {
                if (ScriptMana.ManaNumber <= 0)
                {
                    usingPwr = false;
                    overuse = true;
                    ScriptMana.overuse = true;
                }
                else
                {
                    transform.position += new Vector3(0,0.1f,0);
                    usingPwr = true;
                    mana = mana - 0.5f;
                    ScriptMana.ManaNumber = mana;
                }
            }
        }
        else
        {
            usingPwr = false;
            if (ScriptMana.ManaNumber < 1)
            {
                mana = mana + 0.005f;
                ScriptMana.ManaNumber = mana;
            }
        }

        if (ScriptMana.ManaNumber <= 0)
        {
            usingPwr = false;
            overuse = true;
            ScriptMana.overuse = true;
        }

        next = next - myTime;
        myTime = 0.0F;

    }

    private void GetPlayerInput()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput2 = Input.GetAxisRaw("Horizontal_2");
    }

    private void RotatePlayer()
    {
        float rotation = -_horizontalInput2 * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void MovePlayer()
    {
        rb2d.velocity = transform.up * _verticalInput * movementSpeed;
    }
}

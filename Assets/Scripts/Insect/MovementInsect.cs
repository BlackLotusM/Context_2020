using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInsect : MonoBehaviour
{
    private float _verticalInput = 0;
    private float _horizontalInput2 = 0;

    public bool usingPwr;
    public Animator animator;
    public float mana;
    int idelCheck;
    public int movementSpeed = 0;

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

        if (Input.GetButton("Fire2") && myTime > next)
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
        _verticalInput = Input.GetAxisRaw("Vertical_2");
        _horizontalInput2 = Input.GetAxisRaw("Horizontal_2");
    }

    private void MovePlayer()
    {
        rb2d.velocity = new Vector2(Mathf.Lerp(0, _horizontalInput2 * movementSpeed, 0.8f),
                                     Mathf.Lerp(0, _verticalInput * movementSpeed, 0.8f));

        if (_horizontalInput2 != 0 || _verticalInput != 0)
        {
            idelCheck = 1;
        }
        else
        {
            idelCheck = 0;
        }

        animator.SetFloat("Horizontal", _horizontalInput2);
        animator.SetFloat("Vertical", _verticalInput);
        animator.SetFloat("Magnitude", idelCheck);

    }
}

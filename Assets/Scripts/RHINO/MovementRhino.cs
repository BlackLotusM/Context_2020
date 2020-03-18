using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRhino : MonoBehaviour
{
    private float _verticalInput = 0;
    private float _horizontalInput2 = 0;

    public float mana;

    public int idelCheck;

    public Animator animator;

    public int baseSpeed = 0;
    public int movementSpeed = 0;

    public int usespeed;
    public bool pwruse;
    public bool overuse;
    public float time;
    ManaBar ScriptMana;
    Rigidbody2D rb2d;

    public string loopkant;

    void Start()
    {
        mana = 0.50f;
        rb2d = GetComponent<Rigidbody2D>();
        overuse = false;
        ScriptMana = GetComponent<ManaBar>();
        ScriptMana.overuse = false;
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
            pwruse = false;
            time = time + Time.deltaTime;
            if (time >= 8)
            {
                overuse = false;
                ScriptMana.overuse = false;
            }
            else
            {
                movementSpeed = 1;
            }
        }
        else if (overuse == false)
        {
            time = 0;
            if (pwruse == true)
            {
                movementSpeed = usespeed;
            }
            else
            {
                movementSpeed = baseSpeed;
            }
        }
    }

    private void SpecialMove()
    {
        if (Input.GetButton("Fire1"))
        {
            if (overuse == true)
            {
                if (ScriptMana.ManaNumber < 1)
                {
                    mana = mana + 0.0025f;
                    ScriptMana.ManaNumber = mana;
                }
            }

            else
            {
                if (ScriptMana.ManaNumber <= 0)
                {
                    overuse = true;
                    ScriptMana.overuse = true;
                }
                else
                {
                    pwruse = true;
                    mana = mana - 0.0015f;
                    ScriptMana.ManaNumber = mana;
                }
            }
        }
        else
        {
            pwruse = false;
            if (ScriptMana.ManaNumber < 1)
            {
                mana = mana + 0.0025f;
                ScriptMana.ManaNumber = mana;
            }
        }
    }

    private void GetPlayerInput()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput2 = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        rb2d.velocity = new Vector2(Mathf.Lerp(0, _horizontalInput2 * movementSpeed, 0.8f),
                                     Mathf.Lerp(0, _verticalInput * movementSpeed, 0.8f));

        if(_horizontalInput2 != 0|| _verticalInput != 0)
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

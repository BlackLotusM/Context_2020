using UnityEngine;

public class MovementCheetah : MonoBehaviour
{
    private float _verticalInput = 0;
    private float _horizontalInput2 = 0;

    public float mana;


    public int baseSpeed = 0;
    public int SpeedSpeed = 0;

    public int movementSpeed = 0;
    public int rotationSpeed = 0;

    public bool overuse;
    int time;
    ManaBar ScriptMana;


    Rigidbody2D rb2d;
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
            if (time >= 800)
            {
                
                overuse = false;
                ScriptMana.overuse = false;
            }
            else
            {
                movementSpeed = 2;
            }
        }
        else if (overuse == false)
        {
            time = 0;
            if (Input.GetButton("Fire2"))
            {
                movementSpeed = SpeedSpeed;
            }
            else
            {
                movementSpeed = baseSpeed;
            }
        }
    }


    private void SpecialMove()
    {
        if (Input.GetButton("Fire2")){
            if (overuse == true)
            {
                if (ScriptMana.ManaNumber < 1)
                {
                    mana = mana + 0.005f;
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
                    mana = mana - 0.0045f;
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
    }

    private void GetPlayerInput()
    {
        _verticalInput = Input.GetAxisRaw("Vertical_3");
        _horizontalInput2 = Input.GetAxisRaw("Horizontal_3");
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
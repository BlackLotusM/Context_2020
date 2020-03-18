using UnityEngine;

public class MovementSalamander : MonoBehaviour
{
    private float _verticalInput = 0;
    private float _horizontalInput2 = 0;

    public float mana;

    public int baseSpeed = 0;
    public int SpeedSpeed = 0;

    int idelCheck;
    public int movementSpeed = 0;
    public Animator animator;

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

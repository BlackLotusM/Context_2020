using UnityEngine;

public class MovementOwl : MonoBehaviour
{
    private float _verticalInput = 0;
    private float _horizontalInput2 = 0;

    public GameObject HiddenObjects;
    public float mana;

    public int movementSpeed = 0;
    public int rotationSpeed = 0;

    int idelCheck;
    public Animator animator;

    public bool overuse;
    int time;
    ManaBar ScriptMana;


    Rigidbody2D rb2d;
    void Start()
    {
        mana = 0.50f;
        rb2d = GetComponent<Rigidbody2D>();
        HiddenObjects.SetActive(false);
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
        
        if(overuse == true)
        { 
            time = time + 1;
            if(time >= 800)
            {
                overuse = false;
                ScriptMana.overuse = false;
            }
        }else if(overuse == false){
            time = 0;
        }
    }


    private void SpecialMove()
    {
        if (Input.GetButton("Fire1")){
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
                    HiddenObjects.SetActive(false);
                    overuse = true;
                    ScriptMana.overuse = true;
                }
                else
                {
                    mana = mana - 0.0045f;
                    ScriptMana.ManaNumber = mana;
                    HiddenObjects.SetActive(true);
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

            HiddenObjects.SetActive(false);
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
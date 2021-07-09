using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public enum PlayerType
    {
        HUMAN, AI
    };

    public float horizontalForce;
    public float verticalForce;

    public static float MAX_HEALTH = 100f;

    public float health = MAX_HEALTH;
    public string fighterName;

    public bool enable =false; 

    public Fighter opponent;

    public PlayerType player;
    public FighterState currentState = FighterState.IDLE;
    protected Animator animator;
    public Rigidbody myBody; 

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("health", healthPercent);

        if(opponent != null)
        {
            animator.SetFloat("opponent_health", opponent.healthPercent);
        }
        else
        {
            animator.SetFloat("opponent_health", 1);
        }

        if (player == PlayerType.HUMAN)
        {
            UpdateHumanInput();
        }
 
        

        if(health <= 0 && currentState != FighterState.DEAD)
        {
            animator.SetTrigger("dead");
        }
    }

    public void UpdateHumanInput()
    {
        //Left Right Animations are switched.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("idle", false);

            animator.SetBool("right", true);
            myBody.AddForce(horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("right", false);
            animator.SetBool("idle", true);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("idle", false);

            animator.SetBool("left", true);
            myBody.AddForce(-horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("left", false);
            animator.SetBool("idle", true);
        }
        /*
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            animator.SetBool("right", true);
            animator.SetBool("idle", false);
            
        } else{
            animator.SetBool("right", false);
            animator.SetBool("idle", true);
        }
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetBool("idle", false);
            animator.SetBool("left", true);
        } else{
            animator.SetBool("left", false);
            animator.SetBool("idle", true);
        }*/
        if (Input.GetAxis("Vertical") < -0.1)
        {
            //animator.SetBool("Duck", true);
        }
        else
        {
            //animator.SetBool("Duck", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Attack2");
        }
    }

    public virtual void hurt(float damage)
    {
        if (!invulnerable)
        {
            if (health >= damage)
            {
                health -= damage;
            }
            else
            {
                health = 0;
            }

            if (health > 0)
            {
                Debug.Log("Got HIt");
                //animator.SetTrigger("Take_Hit");
            }
        }
        
    }

    public bool invulnerable
    {
        get
        {
            return currentState == FighterState.Take_Hit || currentState == FighterState.Take_Hit || currentState == FighterState.DEAD;
        }
    }
    public bool attacking
    {
        get
        {
            return currentState == FighterState.ATTACK;
        }
    }
    public Rigidbody body
    {
        get
        {
            return this.myBody;
        }
    }
    public float healthPercent
    {
        get
        {
            return health / MAX_HEALTH;
        }
    }
}

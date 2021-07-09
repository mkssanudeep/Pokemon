using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeExp : MonoBehaviour
{
    public Fighter caster;

    public float damage;
    public float movementForce = 200;
    private Rigidbody body;
    private float creationTime;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddRelativeForce(new Vector3(movementForce, 0, 0));
    }

    void Update()
    {
        if(Time.time - creationTime > 3)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Fighter fighter = collision.gameObject.GetComponent<Fighter>();
        if(fighter != null && fighter != caster)
        {
            fighter.hurt(damage);
            Destroy(gameObject);
        }
    }
}

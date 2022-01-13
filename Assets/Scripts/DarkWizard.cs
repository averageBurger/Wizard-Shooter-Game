using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : Enemy
{
    float maxDistance = -3;

    //temporary:
    bool colliding = false;

    protected override void Attack()
    {
        DealDamage(2);
    }

    private void Update()
    {
        MoveEnemy(maxDistance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!colliding)
        {
            DealDamage(2);
            colliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }
}

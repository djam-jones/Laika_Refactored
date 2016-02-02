using UnityEngine;
using System.Collections;

public class GroundEnemyMovement : EnemyMovement
{
    public override void setTarget()
    {
        //base.setTarget();
        targetPosition = GameObject.FindGameObjectWithTag("Target").transform.position;
    }
}

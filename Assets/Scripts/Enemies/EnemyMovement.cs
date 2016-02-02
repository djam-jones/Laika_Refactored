using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float targetOffset = 1;

    private Vector3 tests;

    public Vector3 targetPosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        setTarget();
    }

    public virtual void setTarget()
    {
        targetPosition = target.transform.position + new Vector3(0, Random.Range(0, targetOffset), 0);
    }

    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}

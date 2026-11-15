using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed;
    // this is the current target that the enemy will move to next
    private bool movingRight;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        movingRight = true; // enemy starts by moving right
    }

    // Update is called once per frame
    private void Update()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointB.position,
                moveSpeed * Time.deltaTime
            );

            // checks when the enemy is close to point B, then turns
            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                movingRight = false;

                Vector3 enemyScale = transform.localScale;
                enemyScale.x = -1; // flips the enemy
                transform.localScale = enemyScale; // updates enemy scale
            }
        }
        else // moving left
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                pointA.position,
                moveSpeed * Time.deltaTime
            );

            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            {
                movingRight = true;

                Vector3 enemyScale = transform.localScale;
                enemyScale.x = 1; // flips the enemy
                transform.localScale = enemyScale; // updates enemy scale
            }
        }
        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float starTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemy;

    public float attackRangeX;//attack range for hitbox X axis
    public float attackRangeY;//attack range for hitbox y axis
    public int damage;
    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //then u can attack
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,whatIsEnemy);
                for(int i =0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    Debug.Log("hasAttacked");
                }
            }
            timeBtwAttack = starTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(attackPos.position, new Vector3(attackRangeX,attackRangeY,1));
    }
}

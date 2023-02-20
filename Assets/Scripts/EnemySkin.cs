using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkin : MonoBehaviour
{
    EnemyScriptable Config;

    public Animator AnimEnemy;
    public GameObject target;
    public float speed;
    public float hp;
    public float jumpForce;
    public bool Attack = false;
    public float MaxHp;
    public float hitForce;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToCharacterAndAttack();
    }

    public void MoveToCharacterAndAttack()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        float distance = Vector2.Distance(target.transform.position, this.transform.position); // tính khoảng cách của nhân vật và enemy
        direction = target.transform.position - this.transform.position; // Cập nhật vị trí của enemy và nhân vật
        if (distance < 3f && Attack == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * 0.5f * Time.deltaTime);
            float xDirection = direction.x; // Xác định hướng của enemy
            if (xDirection < 0)  // Thay đổi scale x của enemy theo hướng của nhân vật
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            AnimEnemy.SetBool("Run", true);
        }
        else AnimEnemy.SetBool("Run", false);

        if (distance < 0.8f && Attack == true)
        {
            //AnimEnemy.SetBool("Run", false);
            AnimEnemy.SetTrigger("Attack");
            StartCoroutine(ForceImpact());
        }
    }


    public void SetUpEnemy(EnemyScriptable enemyScriptable)
    {
        AnimEnemy.runtimeAnimatorController = enemyScriptable.AnimController;
        speed = enemyScriptable.Speed;
        MaxHp = enemyScriptable.MaxHp;
        hp = MaxHp;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack = false;
        }
    }

    public IEnumerator ForceImpact()
    {
        yield return new WaitForSeconds(0.5f);
        float hitMagnitude = hitForce / target.GetComponent<Rigidbody2D>().mass;
        target.GetComponent<Rigidbody2D>().AddForce(direction.normalized * hitMagnitude * 0.5f);
    }
}

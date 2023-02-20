using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject bombInstance;
    public float throwForce = 2f; // Sử dụng float để lưu lực ném.
    public float throwForceIncreasePerSecond = 5f; // đại diện cho tốc độ tăng lực ném của bom theo mỗi giây
    public static bool checkExplosion;

    private float currentThrowForce; // đại diện cho lực ném hiện tại của bom. Nó được sử dụng để lưu giá trị của lực ném mới nhất khi người dùng nhấn giữ phím LeftControl.
    private bool isThrowing = false;
    private float throwStartTime;
    private Vector2 throwDirection; // biến đại diện cho hướng ném

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isThrowing = true;
            throwStartTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isThrowing = false;
            ThrowBomb();
        }

        if (isThrowing)
        {
            currentThrowForce = throwForce + (Time.time - throwStartTime) * throwForceIncreasePerSecond;
        }
    }

    public void ThrowBomb()
    {
        checkExplosion = false;
        GameObject bomb = Instantiate(bombPrefab, bombInstance.transform.position, Quaternion.identity);
        Animator bombAnim = bomb.GetComponent<Animator>();
        Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();
        if(this.transform.localScale.x > 0)
        {
            throwDirection = (transform.right + transform.up).normalized; // Tính toán hướng và lực ném cho đạn theo hình vòng cung.
        } 
        else throwDirection = ((transform.right * -1f) + transform.up).normalized;
        //Debug.LogError(" " +throwDirection);
        bombRigidbody.AddForce(throwDirection * currentThrowForce, ForceMode2D.Impulse);
        StartCoroutine(bomb_Explosion(bombAnim));
        Destroy(bomb, 2.5f);
    }

    public IEnumerator bomb_Explosion(Animator bombAim)
    {
        yield return new WaitForSeconds(2f);
        bombAim.Play("Bomb_Explotion");
        checkExplosion = true;
    }
}


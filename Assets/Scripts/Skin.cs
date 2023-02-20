using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] public Animator Anim;
    [SerializeField] Image _imgHp;
    [SerializeField] TMP_Text _textName;

    public bool facingRight;

    public void Setup(CharacterScriptable characterScriptable)
    {
        Anim.runtimeAnimatorController = characterScriptable.Anim;
        _textName.text = characterScriptable.Name;
        SetHP(characterScriptable.MaxHP, characterScriptable.MaxHP);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(10f,armor);
        //    Anim.SetBool("takeDamage", true);
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Anim.SetBool("takeDamage", false);
        //}
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }

    }

    public void SetHP(float hp, float hpMax)
    {
        _imgHp.fillAmount = hp / hpMax;
        Debug.LogError("Ratio: " + _imgHp.fillAmount);
    }

    public void Attack()
    {
        Anim.SetTrigger("Attack");
    }

    public void TakeDamage()
    {
        Anim.SetTrigger("Attack");
    } 
    
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
}

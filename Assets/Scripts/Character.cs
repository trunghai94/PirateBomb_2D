using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    CharacterScriptable Confif;

    public Skin Skin;
    Mover Mover;

    public float maxHp;
    public float hp;
    public float speed;
    public float armor;
    public GameObject player;

    private bool isTakeDamage = false;
   
    public void Create(string path, CharacterScriptable characterScriptable, Vector3 startPos)
    {
        // Data
        maxHp = characterScriptable.MaxHP;
        hp = maxHp;
        armor = characterScriptable.Armor;
        speed = characterScriptable.Speed;

        // Skin
        player = GameObject.Instantiate(Resources.Load<GameObject>(path), Vector3.zero, Quaternion.identity);
        Skin = player.GetComponent<Skin>();
        Skin.Setup(characterScriptable);

        // Mover
        Mover = player.GetComponent<Mover>();
        Mover.transform.position = startPos;
    }

    public void Moving(float speed)
    {
        Mover.Moving(speed);
        if(speed < 0 && !Skin.facingRight )
        {
            Skin.Flip();
        }
        else if(speed > 0 && Skin.facingRight)
        {
            Skin.Flip();
        }
    }

    public void Jumping()
    {
        Mover.Jumping(1f);
    }
    public void TakeDamage(float damage, float armor)
    {
        if (isTakeDamage == false)
        {
            float finalDamage = damage - armor;
            if (finalDamage < 0)
            {
                finalDamage = 0;
            }

            hp -= finalDamage;
            Skin.SetHP(hp, maxHp);
            Skin.TakeDamage();

            Skin.StartCoroutine(waitTakeDamage());
            isTakeDamage = true;
        }
    }

    public IEnumerator waitTakeDamage()
    {
        yield return new WaitForSeconds(1f);
        isTakeDamage = false;
    }
}

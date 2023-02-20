using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : Skin
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetBool("takeDamage", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Anim.SetBool("takeDamage", false);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }
}

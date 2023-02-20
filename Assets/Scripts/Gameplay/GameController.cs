using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] CharacterScriptable[] characterScriptable;

    public Character player;
    public List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        player = new Character();
        player.Create("Gameplay/Player",characterScriptable[0], new Vector3(0, 0, 0));

        var enemy = new Enemy();
        enemy.Create("Gameplay/Player", characterScriptable[1], new Vector3(2f, 0, 0));
        enemies.Add(enemy);

        //for(int i = 0; i < 5; i++)
        //{
        //    GameObject player = Instantiate(characterPrefab, new Vector2(Random.Range(-3f,3f), Random.Range(-3f, 3f)), Quaternion.identity);
        //    var character = player.GetComponent<Character>();
        //    character.Setup(characterScriptable[i%characterScriptable.Length]);
        //}
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.Moving(player.speed * -1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.Moving(player.speed);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jumping();
        }

        float distance = Vector3.Distance(player.player.transform.position, enemies[0].player.transform.position);
        if (distance < 0.5f)
        {
            player.TakeDamage(10f, 0);
        }
    }

}

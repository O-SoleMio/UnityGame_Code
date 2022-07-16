using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMoving : MonoBehaviour
{
    Vector3 viewPos;
    GameManager gameManager;
    DamageText damageTextScript;
    List<Text> damageList;
    GameObject monster;

    float monsterSpeed;
    int monsterHp; // stage 에서 곱하는 형식
    int damage;
    int stage;
    void Start()
    {
        stage = 1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        damageTextScript = GameObject.Find("DamageTextPool").GetComponent<DamageText>();
        damageList = damageTextScript.damageList;
        monster = GameObject.Find("Monster");

        monsterSpeed = gameManager.monsterSpeed;
        monsterHp = gameManager.monsterHp;
        StartCoroutine(MonsterMoveRight());
    }
    IEnumerator MonsterMoveRight()
    {
        while(true)
        {
            viewPos = Camera.main.WorldToViewportPoint(monster.transform.position);

            monster.transform.Translate(Vector2.right * Time.deltaTime * monsterSpeed);

            if(viewPos.x > 0.9f)
            {
                StartCoroutine(MonsterMoveLeft());
                break;
            }
            yield return null;
        }       
    }

    IEnumerator MonsterMoveLeft()
    {
        while (true)
        {
            viewPos = Camera.main.WorldToViewportPoint(monster.transform.position);

            monster.transform.Translate(Vector2.left * Time.deltaTime * monsterSpeed);

            if (viewPos.x < 0.1f)
            {
                StartCoroutine(MonsterMoveRight());           
                break;
            }
            yield return null;
        }
    }
    void NextStage()
    {
        stage += 1;
        monsterHp = gameManager.monsterHp * stage;
        monsterSpeed = gameManager.monsterSpeed * stage;       
        gameObject.SetActive(true);
        StartCoroutine(MonsterMoveRight());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {       
        if(other.tag == "bullet")
        {
            damage = gameManager.bulletPower + Random.Range(-3, 3);
            other.gameObject.SetActive(false);
            monsterHp -= damage;

            damageTextScript.HitMonster(monster.transform.position, damage);

            if (monsterHp < 0)
            {
                Invoke("NextStage",3.0f);
                gameObject.SetActive(false);                
            }
        }
    }

}

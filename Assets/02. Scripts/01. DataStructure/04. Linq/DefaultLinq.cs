using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct MonsterTest
{
    public string name;
    public int health;
}
public class DefaultLinq : MonoBehaviour
{
    // Start is called before the first frame update
    public List<MonsterTest> monsters = new List<MonsterTest>()
    
    {
        new MonsterTest() { name = "A", health = 100 },
        new MonsterTest() { name = "A", health = 30 },
        new MonsterTest() { name = "A", health = 10 },
        new MonsterTest() { name = "B", health = 100 },
        new MonsterTest() { name = "B", health = 20 },
        new MonsterTest() { name = "C", health = 30 },
        new MonsterTest() { name = "C", health = 10 },
    };

    void Start()
    {
        //몬스터 테스트 그룹에서 A 네임을 가진 hp 30이상의 오브젝트들을 리스트화 해서 체력 높은 순 출력하기

        List<MonsterTest> resultMonsters = new List<MonsterTest>();
        for (var i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].name == "A" && monsters[i].health >= 30)
            {
                resultMonsters.Add(monsters[i]);   
            }
        }

        List<MonsterTest> LinqResults = 
            monsters.Where(e => e is { name: "A", health: >= 30 })
            .OrderByDescending(e => e.health).ToList();

        resultMonsters.Sort((l,r)=>l.health>=r.health ? -1 : 1);
        for (var i = 0; i < resultMonsters.Count; i++)
        {
            Debug.Log("이름 : " + resultMonsters[i].name + "체력 : " + resultMonsters[i].health);
        }
    }
}

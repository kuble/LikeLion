using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLinkedList : MonoBehaviour
{
    void Start()
    {
        string[] words = { "A", "B", "C", "D", "E", "F", "G" };
        //C#에서 제공하는 링크드리스트
        LinkedList<string> list = new LinkedList<string>(words);
        
        //꼬리에 1을 추가함
        list.AddLast("H");
        PrintLinkedList(list);
        //머리에 1을 추가함
        list.AddFirst("Z");
        PrintLinkedList(list);
        
        //꼬리의 자료를 삭제함
        list.RemoveLast();
        PrintLinkedList(list);
        
        //머리의 자료를 삭제함
        list.RemoveFirst();
        PrintLinkedList(list);

        int currIndex = 0;
        LogListComp(currIndex, list);
    }

    void LogListComp(int currIndex, LinkedList<string> list)
    {
        //링크드 리스트는 배열처럼 '몇번째 위치에서 가져온다'라는 관점이 존재하지 않는다.
        //즉 해당 관점을 사용하기 위해선 Enumerator를 사용해야 한다.
        int findIndex = 0;
        var enumerator = list.GetEnumerator();
        
        //Enumerator를 순회함
        while (enumerator.MoveNext())
        {
            if (currIndex == findIndex)
            {
                Debug.Log(enumerator.Current);
                break;
            }

            currIndex++;
        }
    }

    void PrintLinkedList(LinkedList<string> list)
    {
        string log = "";
        foreach (var comp in list)
        {
            log = log + comp + " ";
        }
        Debug.Log(log);
        log = "________________________________";
        Debug.Log(log);
    }
}

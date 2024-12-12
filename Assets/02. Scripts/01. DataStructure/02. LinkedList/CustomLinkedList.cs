using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Prev { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Prev = null;
        Data = data;
        Next = null;
    }
}

public class CustomLinkedList<T>
{
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        
        else
        {
            Head.Prev = newNode;
            newNode.Next = Head;
            Head = newNode;
        }
    }
    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Prev = Tail;
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Prev = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
    }

    public void Traverse()
    {
        Node<T> current = Head;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }

    public void ReverseTraverse()
    {
        Node<T> current = Tail;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Prev;
        }
    }

}
public class CustomLinkedList : MonoBehaviour
{
    void Start()
    {
        CustomLinkedList<string> list = new CustomLinkedList<string>();
        list.AddLast("A");
        list.AddLast("B");
        list.AddLast("C");
        list.AddFirst("Z");
        list.ReverseTraverse(); 
    }
}

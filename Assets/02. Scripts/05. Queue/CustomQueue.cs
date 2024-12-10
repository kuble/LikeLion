using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class CustomQueue : MonoBehaviour
{

}

public class Queue<T>
{
    private T[] array;
    private int front;
    private int rear;
    private int size;
    private int capacity;

    public Queue(int capacity = 10)
    {
        this.capacity = capacity;
        array = new T[capacity];
        front = 0;
        rear = -1;
        size = 0;
    }

    public int Count { get; set; }

    public void Enqueue(T item)
    {
        if (IsFull())
        {
            ResizeArray();
        }
        rear = (rear + 1) % capacity;
        array[rear] = item;
        size++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("큐가 비어있습니다.");
        }
        T item = array[front];
        front = (front + 1) % capacity;
        size--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("큐가 비어있습니다.");
        }
        return array[front];
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public bool IsFull()
    {
        return size == capacity;
    }

    public int Size()
    {
        return size;
    }

    private void ResizeArray()
    {
        int newCapacity = capacity * 2;
        T[] newArray = new T[newCapacity];
        
        // 기존 요소들을 새 배열로 복사
        for (int i = 0; i < size; i++)
        {
            newArray[i] = array[(front + i) % capacity];
        }
        
        array = newArray;
        front = 0;
        rear = size - 1;
        capacity = newCapacity;
    }
}*/

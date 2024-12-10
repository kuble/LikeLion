using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StackNode<T>
{
    public T Data;
    public StackNode<T> prev;
}

public class CustomStack<T> where T: new()
{
    public StackNode<T> Top;

    public void Push(T data)
    {
        var stackNode = new StackNode<T>();
        stackNode.Data = data;
        stackNode.prev = Top;
        Top = stackNode;
    }

    public T Pop()
    {
        if (Top == null)
        {
            return new T();
        }

        var result = Top.Data;
        Top = Top.prev;
        return result;
    }

    public T Peak()
    {
        if (Top == null)
        {
            return new T();
        }
        return Top.Data;
    }
}
public class DefaultStack : MonoBehaviour
{
    
}
public class BracketChecker
{
    public bool AreBracketsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop();
                if ((c == ')' && top != '(') ||
                    (c == ']' && top != '[') ||
                    (c == '}' && top != '{'))
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}

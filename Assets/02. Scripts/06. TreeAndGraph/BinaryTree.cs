using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MonoBehaviour
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    private Node root;

    public void Preorder(Node node)
    {
        if (node == null) return;

        Debug.Log(node.data + " ");
        Preorder(node.left);
        Preorder(node.right);
    }
    public void Inorder(Node node)
    {
        if (node == null) return;
        
        Inorder(node.left);
        Debug.Log(node.data + " ");
        Inorder(node.right);
    }
    public void Postorder(Node node)
    {
        if (node == null) return;
        
        Postorder(node.left);
        Postorder(node.right);
        Debug.Log(node.data + " ");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        root = new Node(100);
        root.left = new Node(50);
        root.left.left = new Node(40);
        root.left.right = new Node(60);
        root.right = new Node(110);

        Debug.Log("전위 순회 : ");
        Preorder(root);
        
        Debug.Log("중위 순회 : ");
        Inorder(root);
        
        Debug.Log("후위 순회 : ");
        Postorder(root);
    }
}

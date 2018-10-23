using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class BT : MonoBehaviour
{
    public RectTransform[] gameObjects;
    public Text[] texts;
    [SerializeField]
    Node root = null;
    int SIZE = 10;
    public int[] a = new int[10];
    void Start()
    {
        print("隨機生成" + SIZE + "個1-100的亂數");

        Stopwatch watch = Stopwatch.StartNew();

        for (int i = 0; i < SIZE; i++)
        {
            a[i] = UnityEngine.Random.Range(0, 100);
        }

        watch.Stop();

        print("完成。 花費" + (double)watch.ElapsedMilliseconds / 1000.0 + "秒");
        print(" ");
        print("將樹填滿" + SIZE + "個節點");

        watch = Stopwatch.StartNew();

        for (int i = 0; i < SIZE; i++)
        {
            print("===========================執行第" + i + "次===========================");
            root = insert(root, a[i], i, -1, 0);
        }

        watch.Stop();

        print("完畢。 花費" + (double)watch.ElapsedMilliseconds / 1000.0 + "時間");
        print(" ");
        print("遍歷樹裡全部" + SIZE + "個節點");

        watch = Stopwatch.StartNew();
        print("前序遍歷");
        PreorderTraverse(root);
        print("中序遍歷");
        InorderTraverse(root);
        print("後序遍歷");
        PostorderTraverse(root);
        watch.Stop();

        print("完畢。 花費" + (double)watch.ElapsedMilliseconds / 1000.0 + "秒");
        print(" ");
    }
    public Node insert(Node root, int v, int index, int layer, int lr)
    {
        if (root == null)
        {
            root = new Node();
            root.value = v;
            texts[index].text = root.value.ToString();

            gameObjects[index].localPosition = new Vector3(lr + index * 5, 355 - 100 * layer, 0);

            print("root為" + root.value);
            return root;
        }
        else if (v < root.value)
        {
            print("隨機數v小於root.value:" + v + "<" + root.value);
            root.left = insert(root.left, v, index, ++layer, -50 + lr);
            print("將隨機數v放入root.left:" + root.left.value);
            return root;
        }
        else
        {
            print("隨機數v大於root.value:" + v + ">" + root.value);
            root.right = insert(root.right, v, index, ++layer, 50 + lr);
            print("將隨機數v放入root.right:" + root.right.value);
            return root;
        }
    }
    /// <summary>
    /// 前序遍歷
    /// Preorder Traversal 前序遍歷
    /// 理論上的遍歷順序是：根、左子樹、右子樹。根排在前面。
    /// 即是Depth-first Search。
    /// </summary>
    /// <param name="root"></param>
    public void PreorderTraverse(Node root)
    {
        if (root == null)
        {
            return;
        }
        print(root.value);
        PreorderTraverse(root.left);
        PreorderTraverse(root.right);
    }//前序遍歷
    /// <summary>
    /// 中序遍歷
    /// Inorder Traversal 中序遍歷
    /// 理論上的遍歷順序是：左子樹、根、右子樹。根排在中間。
    /// 實際上是採用Depth-first Search，只不過更動了節點的輸出順序。
    /// </summary>
    /// <param name="root"></param>
    public void InorderTraverse(Node root)
    {
        if (root == null)
        {
            return;
        }
        InorderTraverse(root.left);
        print(root.value);
        InorderTraverse(root.right);
    }//中序遍歷
    /// <summary>
    /// 後序遍歷
    /// Postorder Traversal 後序遍歷
    /// 理論上的遍歷順序是：左子樹、右子樹、根。根排在後面。
    /// 實際上是採用Depth-first Search，只不過更動了節點的輸出順序。
    /// </summary>
    /// <param name="root"></param>
    public void PostorderTraverse(Node root)
    {
        if (root == null)
        {
            return;
        }
        PostorderTraverse(root.left);
        PostorderTraverse(root.right);
        print(root.value);
    }//後序遍歷
    /// <summary>
    /// 層序遍歷
    /// Level-order Traversal 層序遍歷
    /// 即是Breath-first Search。
    /// </summary>
    /// <param name="root"></param>
    //public void LevelorderTraverse(Node root)
    //{
    //    InorderTraverse(root.left);
    //    if (root == null)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        print(root.value);
    //    }
    //    InorderTraverse(root.right);
    //}
}
[Serializable]
public class Node
{
    public int value;
    public Node left;
    public Node right;
}
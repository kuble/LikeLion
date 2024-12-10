using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutComponent : MonoBehaviour
{
    [Header("Health")] 
    [Tooltip("data1 입니다.")]
    public string data1;
    [Tooltip("data2 입니다.")]
    public string data2;
    [Header("Mana"), Tooltip("마나에 관한 변수 입니다.")] 
    public string data3;
    public string data4;
    [Header("Power"), Range(10, 100)] 
    public float data5;
    public float data6;
    public float data7;
}

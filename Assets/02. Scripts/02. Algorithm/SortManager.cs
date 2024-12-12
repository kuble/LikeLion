using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SortManager : MonoBehaviour
{
    [SerializeField]
    public int number;
    public List<int> numbers = new List<int>();

    //추가
    public void AddNumber(int num)
    {
        numbers.Add(num);
        LogManager.ClearLog();
        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    
    //삭제
    public void RemoveNumber(int num)
    {
        numbers.Remove(num);
        LogManager.ClearLog();
        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    public RockBuilder rockBuilder;
    
    // 버블 소트 애니메이션
    public IEnumerator BubbleSortWithAnimation()
    {
        int n = numbers.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    // 값 교환
                    (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    
                    // 바위 위치 교환 애니메이션
                    yield return rockBuilder.SwapRocks(j, j + 1);
                }
            }
        }
    }
    
    public IEnumerator QuickSortWithAnimation(int low, int high)
    {
        if (low < high)
        {
            // 피벗을 기준으로 파티션
            int pi = -1;
            yield return StartCoroutine(PartitionWithAnimation(low, high, result => pi = result));
            yield return rockBuilder.SwapRocks(pi, high); // 피벗을 최종 위치로 애니메이션
            
            // 퀵소트 재귀 호출
            yield return StartCoroutine(QuickSortWithAnimation(low, pi - 1));
            yield return StartCoroutine(QuickSortWithAnimation(pi + 1, high));
        }
    }
    
    // 정렬 실행
    public void StartBubbleSort()
    {
        StartCoroutine(BubbleSortWithAnimation());
    }
    
    // 정렬 실행
    public void StartQuickSort()
    {
        StartCoroutine(QuickSortWithAnimation(0, numbers.Count - 1));
    }

    // 리스트 업데이트 시 바위 재구성
    public void UpdateRocks()
    {
        rockBuilder.CreateRocks(numbers);
    }
    
    // 파티션: 기준 피벗을 선택하고, 파티션 후 바위 위치 교환
    private IEnumerator PartitionWithAnimation(int low, int high, System.Action<int> onComplete)
    {
        int pivot = numbers[high]; // 마지막 값을 피벗으로 선택
        int i = low - 1;
        
        // 피벗 색상 변경 (노란색)
        rockBuilder.SetPivotMaterial(high);
        
        // 피벗 선택 후 1초 대기
        StartCoroutine(WaitForSeconds(0.5f));

        
        for (int j = low; j < high; j++)
        {
            // 왼쪽 바위 색상 변경 (빨간색)
            rockBuilder.SetLeftMaterial(i+1);
            rockBuilder.SetRightMaterial(j);
            yield return new WaitForSeconds(0.5f);
            if (numbers[j] < pivot)
            {
                i++;
                // 교환을 수행
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                if (i != j)
                {
                    // 바위 교환 애니메이션
                    StartCoroutine(rockBuilder.SwapRocks(i, j));
                    yield return new WaitForSeconds(3.0f);
                }
            }
            rockBuilder.ResetAllRockColors();
            rockBuilder.SetPivotMaterial(high);
        }
        rockBuilder.ResetAllRockColors();
        // 피벗을 올바른 위치로 교환
        (numbers[i + 1], numbers[high]) = (numbers[high], numbers[i + 1]);
        
        onComplete?.Invoke(i + 1); // 파티션 결과를 콜백으로 전달
    }
    
    // 1초 대기 코루틴
    private IEnumerator WaitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}



[CustomEditor(typeof(SortManager))]
public class SorterSelectionButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SortManager sortManager = (SortManager)target;

        if (GUILayout.Button("삽입"))
        {
            sortManager.AddNumber(sortManager.number);
        }
        if (GUILayout.Button("삭제"))
        {
            sortManager.RemoveNumber(sortManager.number);
        }
        if (GUILayout.Button("Generate Rocks"))
        {
            sortManager.UpdateRocks();
        }

        if (GUILayout.Button("Bubble Sort (Animated)"))
        {
            sortManager.StartBubbleSort();
        }
        
        if (GUILayout.Button("Quick Sort (Animated)"))
        {
            sortManager.StartQuickSort();
        }
    }
}

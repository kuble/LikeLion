using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RockBuilder : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab; // 바위 프리팹
    [SerializeField] private Vector3 startPosition = Vector3.zero; // 시작 위치
    [SerializeField] private Vector3 offset = new Vector3(1, 0, 0); // 간격
    [SerializeField] private Material defaultMaterial; // 기본 재질
    [SerializeField] private Material pivotMaterial; // 피벗 재질 (노란색)
    [SerializeField] private Material leftMaterial; // 왼쪽 바위 재질 (빨간색)
    [SerializeField] private Material rightMaterial; // 오른쪽 바위 재질 (파란색)
    [SerializeField] private Material swapMaterial; // 교환 중 재질 (깜빡이는 효과)
    public List<GameObject> rocks = new List<GameObject>();

    // 바위 생성
    public void CreateRocks(List<int> numbers)
    {
        // 기존 바위 제거
        foreach (var rock in rocks)
        {
            Destroy(rock);
        }
        rocks.Clear();

        // 새 바위 생성
        for (int i = 0; i < numbers.Count; i++)
        {
            GameObject newRock = Instantiate(rockPrefab, startPosition + i * offset, Quaternion.identity, this.transform);
            TMP_Text textMesh = newRock.GetComponentInChildren<TMP_Text>();
            if (textMesh != null)
            {
                // TextMesh의 text 속성을 변경하거나 읽어옵니다.
                textMesh.text = numbers[i].ToString();
                Debug.Log("Num: " + textMesh.text);
            }
            else
            {
                Debug.LogError("TextMesh 컴포넌트를 찾을 수 없습니다.");
            }
            newRock.name = "Rock_" + numbers[i];

            // 바위 텍스처 색상 변경 (기본 색상)
            newRock.GetComponent<Renderer>().material = defaultMaterial;
            rocks.Add(newRock);
        }
    }

    // 두 바위 위치 교환 애니메이션
    public IEnumerator SwapRocks(int index1, int index2)
    {
        GameObject rock1 = rocks[index1];
        GameObject rock2 = rocks[index2];
        LogManager.ClearLog();
        Debug.Log(rock1.name + " : " + rock2.name);
        
        Vector3 pos1 = rock1.transform.position;
        Vector3 pos2 = rock2.transform.position;

        float elapsedTime = 0f;
        float duration = 2f; // 애니메이션 지속 시간

        while (elapsedTime < duration)
        {
            rock1.transform.position = Vector3.Lerp(pos1, pos2, elapsedTime / duration);
            rock2.transform.position = Vector3.Lerp(pos2, pos1, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rock1.transform.position = pos2;
        rock2.transform.position = pos1;

        // 리스트에서 바위 순서 교환
        (rocks[index1], rocks[index2]) = (rocks[index2], rocks[index1]);
    }
    
    // 피벗 텍스처 색상 변경
    public void SetPivotMaterial(int index)
    {
        rocks[index].GetComponent<Renderer>().material = pivotMaterial;
    }

    // 왼쪽 바위 텍스처 색상 변경
    public void SetLeftMaterial(int index)
    {
        rocks[index].GetComponent<Renderer>().material = leftMaterial;
    }

    // 오른쪽 바위 텍스처 색상 변경
    public void SetRightMaterial(int index)
    {
        rocks[index].GetComponent<Renderer>().material = rightMaterial;
    }
    public void SetDefaultMaterial(int index)
    {
        rocks[index].GetComponent<Renderer>().material = defaultMaterial;
    }
    // 모든 바위 색상 초기화
    public void ResetAllRockColors()
    {
        foreach (var rock in rocks)
        {
            Renderer renderer = rock.GetComponent<Renderer>();
            if (renderer != null)
            {
                rock.GetComponent<Renderer>().material = defaultMaterial;
            }
        }
    }
}


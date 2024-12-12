using UnityEngine;
using System.Collections.Generic;

public class Graph : MonoBehaviour
{
    public class Vertex
    {
        public string name;
        public Dictionary<Vertex, float> neighbors;

        public Vertex(string name)
        {
            this.name = name;
            neighbors = new Dictionary<Vertex, float>();
        }
    }

    private Dictionary<string, Vertex> vertices;

    void Start()
    {
        // 정점 추가
        AddVertex("A");
        AddVertex("B");
        AddVertex("C");
        AddVertex("D");
    
        // 간선 추가
        AddEdge("A", "B", 4);
        AddEdge("A", "C", 2);
        AddEdge("B", "C", 1);
        AddEdge("B", "D", 5);
        AddEdge("C", "D", 8);
    
        // 그래프 탐색
        Debug.Log("BFS 탐색 결과:");
        BFS("A");
    
        Debug.Log("DFS 탐색 결과:");
        DFS("A");
    
        Debug.Log("다익스트라 최단 경로:");
        Dijkstra("A");
    }

    // 정점 추가
    public void AddVertex(string name)
    {
        if (!vertices.ContainsKey(name))
        {
            vertices.Add(name, new Vertex(name));
            Debug.Log($"정점 {name}이(가) 추가되었습니다.");
        }
    }

    // 간선 추가 (가중치 있는 방향 그래프)
    public void AddEdge(string fromName, string toName, float weight)
    {
        if (vertices.ContainsKey(fromName) && vertices.ContainsKey(toName))
        {
            Vertex from = vertices[fromName];
            Vertex to = vertices[toName];
            
            if (!from.neighbors.ContainsKey(to))
            {
                from.neighbors.Add(to, weight);
                Debug.Log($"간선 {fromName} -> {toName} (가중치: {weight})가 추가되었습니다.");
            }
        }
    }

    // 너비 우선 탐색 (BFS)
    public void BFS(string startName)
    {
        if (!vertices.ContainsKey(startName)) return;

        HashSet<Vertex> visited = new HashSet<Vertex>();
        Queue<Vertex> queue = new Queue<Vertex>();
        
        Vertex start = vertices[startName];
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            Vertex current = queue.Dequeue();
            Debug.Log($"방문: {current.name}");

            foreach (var neighbor in current.neighbors.Keys)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    // 깊이 우선 탐색 (DFS)
    public void DFS(string startName)
    {
        if (!vertices.ContainsKey(startName)) return;
        HashSet<Vertex> visited = new HashSet<Vertex>();
        DFSUtil(vertices[startName], visited);
    }

    private void DFSUtil(Vertex vertex, HashSet<Vertex> visited)
    {
        visited.Add(vertex);
        Debug.Log($"방문: {vertex.name}");

        foreach (var neighbor in vertex.neighbors.Keys)
        {
            if (!visited.Contains(neighbor))
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    // 다익스트라 최단 경로 알고리즘
    public void Dijkstra(string startName)
    {
        if (!vertices.ContainsKey(startName)) return;

        Dictionary<Vertex, float> distances = new Dictionary<Vertex, float>();
        Dictionary<Vertex, Vertex> previous = new Dictionary<Vertex, Vertex>();
        HashSet<Vertex> unvisited = new HashSet<Vertex>();

        // 초기화
        foreach (var vertex in vertices.Values)
        {
            distances[vertex] = float.MaxValue;
            previous[vertex] = null;
            unvisited.Add(vertex);
        }

        Vertex start = vertices[startName];
        distances[start] = 0;

        while (unvisited.Count > 0)
        {
            // 가장 가까운 미방문 정점 찾기
            Vertex current = null;
            float minDistance = float.MaxValue;
            foreach (var vertex in unvisited)
            {
                if (distances[vertex] < minDistance)
                {
                    current = vertex;
                    minDistance = distances[vertex];
                }
            }

            if (current == null) break;

            unvisited.Remove(current);

            foreach (var neighbor in current.neighbors)
            {
                float alt = distances[current] + neighbor.Value;
                if (alt < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = alt;
                    previous[neighbor.Key] = current;
                }
            }
        }

        // 결과 출력
        foreach (var vertex in vertices.Values)
        {
            Debug.Log($"{startName}에서 {vertex.name}까지의 최단 거리: {distances[vertex]}");
        }
    }
}

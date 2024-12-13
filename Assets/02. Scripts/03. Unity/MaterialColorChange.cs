using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChange : MonoBehaviour
{
    public GameObject cube;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider boxCollider = cube.GetComponent<BoxCollider>();
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,
                boxCollider.bounds.min.x,
                boxCollider.bounds.max.x), 0,
            Mathf.Clamp(
                transform.position.z,
                boxCollider.bounds.min.z,
                boxCollider.bounds.max.z));


        float scaleX = boxCollider.size.x * boxCollider.transform.lossyScale.x;
        float scaleZ = boxCollider.size.z * boxCollider.transform.lossyScale.z;
        
        GetComponent<MeshRenderer>().material.color = new Color(
            (transform.position.x + scaleX * 0.5f) /
            scaleX,
            0,
            (transform.position.z + scaleZ * 0.5f) /
            scaleZ
        );
    }
}
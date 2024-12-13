using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject part;
    public int MinPartCount = 3;
    public int MaxPartCount = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 hitDirection = GetComponent<Rigidbody>().velocity * -1;

        int count = Random.Range(MinPartCount, MaxPartCount + 1);
        if (other.gameObject.layer == 7)
        {
            other.gameObject.GetComponent<Monster>().MonsterHit();
        }
        for (int i = 0; i < count; ++i)
        {
            Vector3 randomDiretion = Random.insideUnitSphere;
            Vector3 lastDiretion = Quaternion.LookRotation(randomDiretion) 
                                   * hitDirection;
        
            GameObject instance = Instantiate(part, transform.position,
                Quaternion.LookRotation(lastDiretion));

            instance.GetComponent<Rigidbody>().AddForce(lastDiretion, ForceMode.Impulse);
            Destroy(this.gameObject);
        }
    }
}

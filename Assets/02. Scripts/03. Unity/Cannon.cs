using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBall;

    public GameObject firePoint;

    public GameObject stick;

    public Slider slider;
    public float maxPower;
    public float currentPower;
    public float fillSpeed;

    public bool isPowerOver;

    //public Camera mainCamera;

    //public Camera subCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (currentPower >= maxPower)
            {
                isPowerOver = true;
            }
            if (currentPower == 0)
            {
                isPowerOver = false;
            }
            if(!isPowerOver)
            {
                currentPower += fillSpeed * Time.deltaTime;
                currentPower = Mathf.Clamp(currentPower, 0, maxPower);
                slider.value = currentPower / maxPower;   
            }
            if(isPowerOver)
            {
                currentPower -= fillSpeed * Time.deltaTime;
                currentPower = Mathf.Clamp(currentPower, 0, maxPower);
                slider.value = currentPower / maxPower;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject cannonBallInstance = Instantiate(cannonBall, firePoint.transform.position, transform.rotation);
            cannonBallInstance.GetComponent<Rigidbody>().AddForce(firePoint.transform.forward * currentPower, ForceMode.Impulse);
            slider.value = 0.0f;
            currentPower = 0.0f;
            //ShowSubView();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stick.transform.localScale += Vector3.up * 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stick.transform.localScale += Vector3.down * 0.1f;
        }
    }
    /*public void ShowMainView() {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }
    
    private void ShowSubView() {
        mainCamera.enabled = false;
        subCamera.enabled = true;
    }*/
}

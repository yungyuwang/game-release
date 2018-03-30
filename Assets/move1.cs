using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class move1 : MonoBehaviour {

    Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;

    public Text myTime;
    int count;
    DateTime curr;


    // Use this for initialization
    void Start () {
        count = 0;
        countText.text = "分數：";
        winText.text = "";

        curr = DateTime.Now;
        myTime.text = "10";

        rb = GetComponent<Rigidbody>();


        
        

    }
	
	// Update is called once per frame
	void Update () {


		float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(x, 0, z)*speed);


        TimeSpan ts = DateTime.Now - curr;
        if (ts.Seconds < 10)
        {
            myTime.text = (10 - ts.Seconds).ToString() + ":" + (1000 - ts.Milliseconds).ToString();
        }
        else
        {
            myTime.text = "0";
            winText.text = "You lose!";
        }


	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("pick"))
        {

            other.gameObject.SetActive(false);
            count++;
            countText.text = "分數："+count.ToString();

            if (count >= 3) {
                winText.text = "You Win!!!!";
            }


        }
    }
}




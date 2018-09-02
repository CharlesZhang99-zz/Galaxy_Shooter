using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5.0f;
  
	// Use this for initialization
	void Start () {

        transform.position = new Vector3(0, 0, 0);
	}

    // Update is called once per frame
    void Update(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed);
        transform.Translate(new Vector3(0, verticalInput, 0) * Time.deltaTime * speed);
    }
}

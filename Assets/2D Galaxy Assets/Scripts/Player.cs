using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] //This allows for the variable to be private but still able to view in Unity Inspector
    private float speed = 5.0f;
  
	// Use this for initialization
	void Start () {

        transform.position = new Vector3(0, 0, 0);
	}

    // Update is called once per frame
    void Update(){
        Movement();

    }


    private void Movement(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed);
        transform.Translate(new Vector3(0, verticalInput, 0) * Time.deltaTime * speed);

        if (transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -4.2f){
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.4){
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }

        if (transform.position.x < -9.4){
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }
    }


}

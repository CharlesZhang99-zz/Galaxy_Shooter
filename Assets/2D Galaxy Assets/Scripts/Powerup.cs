using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3;
	
	void Update () 
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            Debug.Log("Collided with : " + other);
            //access the player
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //enable triple shot
                player.canTripleShot = true;
            }

            //destroy ourselves
            Destroy(this.gameObject);
        }
    }
}

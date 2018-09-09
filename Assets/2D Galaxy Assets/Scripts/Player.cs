using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShot = false;

    [SerializeField] //This allows for the variable to be private but still able to view in Unity Inspector
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _speed = 8f;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    // Use this for initialization
    void Start () {

        transform.position = new Vector3(0, 0, 0);
	}

    // Update is called once per frame
    void Update()
    {

        Movement();

        //if space key is pressed
        //spawn laser at player position
        if ((Input.GetKeyDown(KeyCode.Space)) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        /*
        if (_tripleShotPrefab.transform.position.y > 6)
        {
            Destroy(_tripleShotPrefab.gameObject);
        }
        */
    }


    private void Movement(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * _speed);
        transform.Translate(new Vector3(0, verticalInput, 0) * Time.deltaTime * _speed);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
       
        if (transform.position.x > 9.4)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }

        if (transform.position.x < -9.4)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }

    }


    private void Shoot()
    {
        //check to see if laser can be fired again (cooldown effectif (Time.time > _canFire)
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;

            if (canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }

            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }

        }

    }

}

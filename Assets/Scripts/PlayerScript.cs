using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float _speed = 5.0f;
    private float _defaultSpeed;
    public float _fireRate = 0.5f;
    private float _canFire = -1f;
    private AudioSource _audioSource;
    public AudioClip _shootClip;
    public AudioClip _explosionClip;
    public GameObject _laserPrefab;
    public GameObject _ship;
    public int urScore = 0;
    public bool _cantFire = false;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(0, -3.5f, 0);
        _defaultSpeed = _speed;
    }

    void Update()
    {
       CalculateMovement();
       ChargedUp();

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire && _cantFire == false)
        {
            FireLaser();
        }

        

    }

    void CalculateMovement()
    {
        float xMove = Input.GetAxis("Horizontal");

        float xMovement = xMove * _speed * Time.deltaTime;
        transform.Translate(xMovement, 0, 0);

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, -3.6f, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, -3.6f, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        _audioSource.PlayOneShot(_shootClip);
    }

    void ChargedUp()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 10f;
            _ship.GetComponent<SpriteRenderer>().color = Color.red;
            _cantFire = true;
        }
        else
        {
            _speed = _defaultSpeed;
            _ship.GetComponent<SpriteRenderer>().color = Color.white;
            _cantFire = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("LoserScreen");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public float _speed = 4f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed *Time.deltaTime);

        if (transform.position.y >= 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public float _alienSpeed = -5.0f;
    private GameManager keepScore;


    private void Start()
    {
       
       keepScore  = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        float yPos = _alienSpeed * Time.deltaTime;
        transform.Translate(0,yPos,0);
        //if (transform.position.y < -4.6f)
        //{
            //Destroy(gameObject);
       // }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Laser")
        {
            
            //Debug.Log("IM HIT!");
            Destroy(gameObject);
            keepScore.addScore();
            
            
        }
        
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            keepScore.decreaseScore();
            
            
        }
        

    }
}

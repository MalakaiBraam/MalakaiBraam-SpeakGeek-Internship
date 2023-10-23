using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager gM;
    public float speed;
    public Rigidbody rb;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public int health;
    public bool canJump = false;
    public float jumpForce = 5.0f;
    private float lastJumpTime;
    public float jumpCooldown = 2.0f;

    private void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = gM.MostRecentCheck;
        health = 3;
    }
    private void Update()
    {
        
        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(Vector3.left * speed);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(Vector3.back * speed);
        }

        if (health == 2)
        {
            health1.SetActive(false);
        }
        else if (health == 1)
        {
            health2.SetActive(false);
        }
        else if (health == 0)
        {
            health3.SetActive(false);
            SceneManager.LoadScene(2);
            
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space) && (Time.time - lastJumpTime) >= jumpCooldown)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastJumpTime = Time.time; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            transform.position = gM.MostRecentCheck;

            if (health >= 1)
            {
                health = health - 1;
            }
            
        }


    }
}

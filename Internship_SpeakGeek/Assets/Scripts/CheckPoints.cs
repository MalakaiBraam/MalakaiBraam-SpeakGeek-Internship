using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    private GameManager gM;
    private PlayerController pC;
    public ParticleSystem checkpointEffect;
    public float effectDuration = 2.0f;
    public float timer = 0.0f;
    public bool activated = false;
    


    private void Start()
    {
        gM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        pC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("You have triggered:" + gameObject.name);
            gM.MostRecentCheck = transform.position; 
        }

        if (gameObject.name == "CheckPoint1")
        {
            
            if (pC != null)
            {
                pC.canJump = true; 
            }
        }

        

        if (!activated && other.CompareTag("Player"))
        {
            checkpointEffect.Play();
            activated = true;
        }

        if (gameObject.name == "Finish")
        {

            SceneManager.LoadScene(3);
            
        }
    }

    private void Update()
    {
        if (activated)
        {
            timer += Time.deltaTime;

            if(timer >= effectDuration)
            {
                checkpointEffect.Stop();
                activated = false;
                timer = 0.0f;
            }
        }
    }
}

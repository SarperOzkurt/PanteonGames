using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class opponentcontrol : MonoBehaviour
{
    public NavMeshAgent navemesh; 
    public Transform target1; 
    public Transform target2; 
    Vector3 firsttarget; 
    bool isnavemeshdisabled; 
    float AIspeed; 
    CapsuleCollider cc; 
    bool isSet; 
    float randomf; 
    public Transform finistwopos; 
    public Transform finisthreepos; 
    float AIpeedX; 


    private Animator AIanim;
    // Start is called before the first frame update
    void Start()
    {
        AIpeedX = Random.Range(0, 0.3f);
        isSet = true;
        AIspeed = 0.35f;
        isnavemeshdisabled = false;
        AIanim = GetComponent<Animator>();
        AIanim.SetBool("isGameStart", true);
        navemesh = this.gameObject.GetComponent<NavMeshAgent>();
        firsttarget = new Vector3(target1.transform.position.x + Random.Range(-0.15f, 0.15f), target1.transform.position.y, target1.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isnavemeshdisabled)  
        {
            navemesh.SetDestination(firsttarget);  
        }
        else if (isnavemeshdisabled) 
        {
            if (isSet)
            {
                settings();
            }
            runOnPlartform();
        }
       
        if (gameObject.transform.position.z >= target1.transform.position.z - 0.2f && gameObject.transform.position.z <= target1.transform.position.z + 0.2f)
        {
            isnavemeshdisabled = true;  
        }
        
        else if (gameObject.transform.position.z >= finistwopos.position.z - 0.2f && gameObject.transform.position.z <= finistwopos.position.z + 0.2f)
        {
            
            if (finisthreepos.position.x - gameObject.transform.position.x >= 0)
            {
                gameObject.transform.Translate(AIpeedX * Time.deltaTime, 0, 0); 
               
                if (gameObject.transform.position.x >= finisthreepos.position.x)
                {
                    gameObject.transform.position = new Vector3(finisthreepos.position.x, transform.position.y, transform.position.z);
                }
            }
            else if (finisthreepos.position.x - gameObject.transform.position.x <= 0)
            {
                gameObject.transform.Translate(-AIpeedX * Time.deltaTime, 0, 0); 
                if (gameObject.transform.position.x <= finisthreepos.position.x)
                {
                    
                    gameObject.transform.position = new Vector3(finisthreepos.position.x, transform.position.y, transform.position.z);
                }
            }

        }
    }
   
    void runOnPlartform()
    {
        randomf = Random.Range(0, 0.2f);
        transform.Translate(Random.Range(-randomf, randomf) * AIspeed * Time.deltaTime, 0, AIspeed * Time.deltaTime);
    }

   
    void settings()
    {
        navemesh.enabled = false; 
        gameObject.AddComponent<CapsuleCollider>();
        cc = GetComponent<CapsuleCollider>();
        cc.center = new Vector3(0, 1.206617f, 0);
        cc.height = 2.674153f;
        cc.radius = 0.5f;
        isSet = false;
    }
    void settingof()
    {
        navemesh.enabled = true; 
        navemesh.SetDestination(target2.position); 
        navemesh.speed = 0.032f;
        navemesh.acceleration = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finishthree") 
        {
            settingof(); //then settingoff
        }
        if (other.gameObject.tag == "BoundFinish") 
        {
            Destroy(gameObject);
        }
    }
}
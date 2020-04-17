using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody myBody;
    private bool onWood;

    private KnifeSpawner knifeSpawner;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        knifeSpawner = GameObject.Find("Knife Spawner").GetComponent<KnifeSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !onWood)
        {
            myBody.velocity = new Vector3(0f, speed, 0f);
        }

        
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Wood")
        {
            gameObject.transform.SetParent(target.transform); // it will roatate with the wood
            myBody.velocity = Vector3.zero;
            onWood = true;
            myBody.detectCollisions = false;

            knifeSpawner.SpawnKnife();
            knifeSpawner.IncrementScore();
        }

        if (target.tag == "Knife")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }



} // class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector3 shootDir;
    private string parentShooter;

    public void Setup(Vector3 shootDir, string Parent)
    {
        this.shootDir = shootDir;
        //transform.eulerAngles = new Vector3(rotation.x, rotation.y, 90);
        parentShooter = Parent;
        Destroy(gameObject, 1.5f);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Shooter") && parentShooter == "Player")
        {
            other.GetComponent<EnemieHealth>().damageEnemie(1);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Runner") && parentShooter == "Player")
        {
            other.GetComponent<EnemieHealth>().damageEnemie(1);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Drone") && parentShooter == "Player")
        {
            other.GetComponent<EnemieHealth>().damageEnemie(1);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Car") && parentShooter == "Player")
        {
            print("Not shootable");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && parentShooter == "Shooter")
        {
           
            other.GetComponent<PlayerHealth>().damagePlayer();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Boss") && parentShooter == "Player")
        {
            other.GetComponent<BossHealth>().DamageBoss();
            Destroy(gameObject);
        }
        else if(other.CompareTag("Shield") && parentShooter == "Player")
        {
            Destroy(gameObject);
        }
    }
}

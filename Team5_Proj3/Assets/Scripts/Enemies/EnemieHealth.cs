using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour
{

    [SerializeField] float shooterHealth;
    [SerializeField] float runnerHealth;
    [SerializeField] float droneHealth;
    [SerializeField] float carHealth;
    
    private float iterationHealth;






    // Start is called before the first frame update
    void Start()
    {
        determineEnemie();
        

        if (this.gameObject.transform.position.z > 3.5)
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 3);
        }
        else if(this.gameObject.transform.position.z < -3.5)
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void determineEnemie()
    {
        string tag = this.gameObject.tag;
        switch (tag)
        {
            case "Shooter":
                iterationHealth = shooterHealth;
                
                break;
            case "Runner":
                iterationHealth = runnerHealth;
                
                break;
            case "Drone":
                iterationHealth = droneHealth;

                break;
        }
    }
    public void damageEnemie(float damage)
    {
        iterationHealth -= damage;
        if(iterationHealth <= 0)
        {
            awardPoints();
            Destroy(this.gameObject);
        }
    }
    private void awardPoints()
    {
        if(gameObject.tag == "Runner")
        {
            GameObject.FindWithTag("Player").GetComponent<ScoreKeeper>().scoreKeeper(10);
        }
        else if(gameObject.tag == "Shooter")
        {
            GameObject.FindWithTag("Player").GetComponent<ScoreKeeper>().scoreKeeper(15);
        }
        else if(gameObject.tag == "Drone")
        {
            GameObject.FindWithTag("Player").GetComponent<ScoreKeeper>().scoreKeeper(10);
        }
    }
    private IEnumerator deathWait()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}

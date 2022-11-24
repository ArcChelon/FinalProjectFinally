using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttack : MonoBehaviour
{
    [SerializeField] Transform drivePosition;
    [SerializeField] float carSpeed;
    [SerializeField] AudioSource vroom;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = new Vector3(0, 180, 0);
        transform.eulerAngles = rotation;
        this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z);
        StartCoroutine(moveTowardPosition());
        Destroy(gameObject, 15f);
        vroom.Play();

        if (this.gameObject.transform.position.z > 3.5)
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 3);
        }
        else if (this.gameObject.transform.position.z < -3.5)
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -3);
        }


    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, drivePosition.position, Time.deltaTime * carSpeed);
    }

    private IEnumerator moveTowardPosition()
    {
        yield return new WaitForSeconds(3);
        Vector3 rotation = new Vector3(0, 0, 0);
        transform.eulerAngles = rotation;
        if(transform.position.z == -3)
        {
            int position = Random.Range(1, 2);
            if (position == 1)
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z + 3);
            }
            else
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z + 6);
            }  
            

        }
        else if(transform.position.z == 3)
        {
            int position = Random.Range(1, 2);
            if (position == 1)
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z -3);
            }
            else
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z -6);
            }
        }
        else
        {
            int position = Random.Range(1, 2);
            if (position == 1)
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z + 3);
            }
            else
            {
                this.gameObject.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z - 3);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Runner") || other.CompareTag("Shooter") || other.CompareTag("Drone"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().damagePlayer();
        }
    }
}

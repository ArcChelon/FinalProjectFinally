using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shooter") || other.CompareTag("Runner"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(other.gameObject, 2f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAttack : MonoBehaviour
{

    [SerializeField] Transform moveTarget;
    [SerializeField] float moveSpeed;

    
    


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
            //print("Is targeting");
            this.transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, Time.deltaTime * moveSpeed);
        
        
    }
    
}

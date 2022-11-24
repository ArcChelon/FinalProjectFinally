using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSlick : MonoBehaviour
{
    public PlayerMovement PH;
    public DroneAttack DA;
    // Start is called before the first frame update
    void Start()
    {
        PH = GameObject.Find("Player_PH").GetComponent<PlayerMovement>();
        Destroy(gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PH.moveSpeed = 3;
            DA.moveSpeed = 3;
            StartCoroutine(slickDuration());
            
        }
    }
    private IEnumerator slickDuration()
    {
        yield return new WaitForSeconds(3);
        PH.moveSpeed = 6;
        DA.moveSpeed = 6;
        Destroy(this.gameObject);
    }
}

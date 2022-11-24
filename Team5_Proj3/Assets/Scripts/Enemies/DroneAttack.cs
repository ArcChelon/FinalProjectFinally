using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    [SerializeField] Transform positionToMove;
    [SerializeField] public float moveSpeed;
    [SerializeField] Transform oil;
    [SerializeField] Transform spikes;
    private bool isMoving = false;
    private Vector3 positionStart;
    private Quaternion rotation;
    private Transform first;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToMove());
        first = oil;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, positionToMove.position, Time.deltaTime * moveSpeed);
        }
        positionStart = new Vector3(this.transform.position.x, -0.786f, this.transform.position.z);
        rotation = this.transform.rotation;
    }
    private IEnumerator waitToMove()
    {
        yield return new WaitForSeconds(2);
        isMoving = true;
        StartCoroutine(oilCoolDown());
    }
    private IEnumerator oilCoolDown()
    {
        yield return new WaitForSeconds(2);
        
        if(first == spikes)
        {
            spawnOilSlick();
            first = oil;
        }
        else
        {
            spawnSpike();
            first = spikes;
        }
        
        StartCoroutine(oilCoolDown());
    }
    private void spawnOilSlick()
    {
        Transform slick = Instantiate(oil, positionStart, rotation);
        slick.GetComponent<OilSlick>().DA = this.gameObject.GetComponent<DroneAttack>();
    }
    private void spawnSpike()
    {
        Transform spike = Instantiate(spikes, positionStart, rotation);
        
        
    }
}

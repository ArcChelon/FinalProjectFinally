using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineAttack : MonoBehaviour
{
    [SerializeField] float coolDown;
    private int previous;

    [SerializeField] int gunWeight;
    [SerializeField] int laserWeight;
    [SerializeField] int missileWeight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attackCoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator attackCoolDown()
    {
        print("Cooldown");
        yield return new WaitForSeconds(coolDown);
        determineAttack();
    }
    private void determineAttack()
    {
        int gun = Random.Range(1, 100) + gunWeight;
        int laser = Random.Range(1, 100) + laserWeight;
        int missile = Random.Range(1, 100) + missileWeight;
        //int choice = 3;
        if (gun > laser && gun > missile)
        {
            gameObject.GetComponent<BossShoot>().determineLanes();
            
        }
        else if(laser > gun && laser > missile)
        {
            gameObject.GetComponent<BossLaser>().determineLane();
        }
        else
        {
            gameObject.GetComponent<BossMissile>().startLocking();
        }
    }
    public void cooldown()
    {
        StartCoroutine(attackCoolDown());
    }
}

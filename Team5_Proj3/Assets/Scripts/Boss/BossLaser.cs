using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField] GameObject laserTop;
    [SerializeField] GameObject laserBot;

    [SerializeField] GameObject warningTop;
    [SerializeField] GameObject warningBot;

    [SerializeField] Transform bTop;
    [SerializeField] Transform bBot;
    [SerializeField] Transform bMid;

    [SerializeField] Transform BarTop;
    [SerializeField] Transform BarBot;
    [SerializeField] Transform BarMid;

    [SerializeField] float laserTime;

    [SerializeField] Transform spike;

    private bool isLasing;
    GameObject laser;
    int previouseLane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void determineLane()
    {
        
        GameObject warning;
        int random = Random.Range(1, 3);
        if(random == 1)
        {
            laser = laserTop;
            warning = warningTop;
        }
        else
        {
            laser = laserBot;
            warning = warningBot;
        }
        StartCoroutine(warningLaser(laser, warning));
        
    }
    private IEnumerator warningLaser(GameObject Laser, GameObject warning)
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(3f);
        warning.SetActive(false);
        Laser.SetActive(true);
        isLasing = true;
        StartCoroutine(laserDuration(Laser, warning));
        StartCoroutine(deploySpike(Laser));

    }
    private IEnumerator laserDuration(GameObject laser, GameObject warning)
    {
        yield return new WaitForSeconds(laserTime);
        laser.SetActive(false);
        isLasing = false;
        gameObject.GetComponent<DetermineAttack>().cooldown();
    }
    private IEnumerator deploySpike(GameObject Laser)
    {
        yield return new WaitForSeconds(.75f);
        if (isLasing)
        {
            deploying(Laser);
            StartCoroutine(deploySpike(Laser));
        }
    }
    private void deploying(GameObject Laser)
    {
        int laneIgnore;
        if(Laser == laserTop)
        {
            laneIgnore = 3;
        }
        else
        {
            laneIgnore = 1;
        }
        int laneSelected = Random.Range(1, 4);
        if(laneSelected == laneIgnore || laneSelected == previouseLane)
        {
            while(laneSelected == laneIgnore || laneSelected == previouseLane)
            {
                laneSelected = Random.Range(1, 4);
            }
        }
        if(laneSelected == 1)
        {
            Transform spikes = Instantiate(spike, BarBot.position, BarBot.rotation);
        }
        else if(laneSelected == 2)
        {
            Transform spikes = Instantiate(spike, BarMid.position, BarMid.rotation);
        }
        else
        {
            Transform spikes = Instantiate(spike, BarTop.position, BarTop.rotation);
        }
        previouseLane = laneSelected;
    }
}

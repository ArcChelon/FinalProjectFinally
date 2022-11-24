using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] int shotAmount;
    private int shotAlready;

    [SerializeField] Transform bullet;
    [SerializeField] Transform bMid;
    [SerializeField] Transform bTop;
    [SerializeField] Transform bBot;

    [SerializeField] Transform BarTop;
    [SerializeField] Transform BarMid;
    [SerializeField] Transform BarBot;

    [SerializeField] AudioSource gunSound;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bTop = GameObject.FindWithTag("bTop").GetComponent<Transform>();
        bMid = GameObject.FindWithTag("bMiddle").GetComponent<Transform>();
        bBot = GameObject.FindWithTag("bBottom").GetComponent<Transform>();
    }
    public void determineLanes()
    {
        Transform lane1 = null;
        Transform lane2 = null;
        Transform barrel1 = null;
        Transform barrel2 = null;
        int previous = 0;
        for (int i = 0; i < 2; i++)
        {
            int random = Random.Range(1, 4);
            if(random == previous)
            {
                while(random == previous)
                {
                     random = Random.Range(1, 3);
                }
            }
            if(random == 1)
            {
                if(i == 0)
                {
                    lane1 = bTop;
                    barrel1 = BarTop;
                }
                else
                {
                    lane2 = bTop;
                    barrel2 = BarTop;
                }
            }
            else if(random == 2)
            {
                if (i == 0)
                {
                    lane1 = bMid;
                    barrel1 = BarMid;
                }
                else
                {
                    lane2 = bMid;
                    barrel2 = BarMid;
                }
            }
            else if(random == 3)
            {
                if (i == 0)
                {
                    lane1 = bBot;
                    barrel1 = BarBot;
                }
                else
                {
                    lane2 = bBot;
                    barrel2 = BarBot;

                }
            }
            previous = random;
            
        }
        StartCoroutine(shooting(lane1, barrel1, lane2, barrel2));
        
    }
    private IEnumerator shooting(Transform lane1, Transform barrel1, Transform lane2, Transform barrel2)
    {
        yield return new WaitForSeconds(.1f);
        if(shotAlready < shotAmount)
        {
            bulletHell(lane1, barrel1, lane2, barrel2);
            shotAlready++;
            gunSound.Play();
            StartCoroutine(shooting(lane1, barrel1, lane2, barrel2));
        }
        else
        {
            print("Ended");
            shotAlready = 0;
            gameObject.GetComponent<DetermineAttack>().cooldown();
        }
        
    }
    private void bulletHell(Transform lane1,Transform barrel1, Transform lane2, Transform barrel2)
    {
        Vector3 positionStart1 = new Vector3(barrel1.position.x, barrel1.position.y, barrel1.position.z);
        Vector3 positionStart2 = new Vector3(barrel2.position.x, barrel2.position.y, barrel2.position.z);
        Quaternion bulletRotation1 = barrel1.rotation;
        Quaternion bulletRotation2 = barrel2.rotation;
        
        
            Transform Shot1 = Instantiate(bullet, positionStart1, bulletRotation1);
            Vector3 shootDir1 = (lane1.position - positionStart1).normalized;
            Shot1.GetComponent<Bullet>().Setup(shootDir1, "Shooter");


            Transform Shot2 = Instantiate(bullet, positionStart2, bulletRotation2);
            Vector3 shootDir2 = (lane2.position - positionStart2).normalized;
            Shot2.GetComponent<Bullet>().Setup(shootDir2, "Shooter");

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAttack : MonoBehaviour
{
    private float firstTimeCooldown;

    [SerializeField] float coolDownTime;
    [SerializeField] Transform bullet;
    
    [SerializeField] Transform gunBarrel;

    [SerializeField] Transform beginTargetTop;
    [SerializeField] Transform beginTargetMiddle;
    [SerializeField] Transform beginTargetBottom;

    [SerializeField] AudioSource shoot;

    private Vector3 positionStart;
    private Quaternion bulletRotation;

    private float timesShot;




    // Start is called before the first frame update
    void Start()
    {
        positionStart = new Vector3(gunBarrel.position.x, gunBarrel.position.y, gunBarrel.position.z);
        bulletRotation = gunBarrel.rotation;

        beginTargetTop = GameObject.FindWithTag("bTop").GetComponent<Transform>();
        beginTargetMiddle = GameObject.FindWithTag("bMiddle").GetComponent<Transform>();
        beginTargetBottom = GameObject.FindWithTag("bBottom").GetComponent<Transform>();

        firstTimeCooldown = Random.Range(1,3);
        StartCoroutine(firstTimeCoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator firstTimeCoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        StartCoroutine(tripleShot());
        Destroy(gameObject, 15f);
    }
    private IEnumerator standardCoolDown()
    {
        timesShot = 0;
        yield return new WaitForSeconds(coolDownTime);
        StartCoroutine(tripleShot());
    }
    private IEnumerator tripleShot()
    {
        yield return new WaitForSeconds(0.2f);
        if(timesShot != 3)
        {
            EnemyShoot(this.gameObject.transform.position.z);
            timesShot += 1;
            shoot.Play();
            StartCoroutine(tripleShot());
        }
        else
        {
            StartCoroutine(standardCoolDown());
        }
    }
    private void EnemyShoot(float zPosition)
    {
        if(zPosition >= 3)
        {
            Transform Shot = Instantiate(bullet, positionStart, bulletRotation);

            Vector3 shootDir = (beginTargetTop.position - positionStart).normalized;
            Shot.GetComponent<Bullet>().Setup(shootDir, "Shooter");
        }
        else if (zPosition >= 0 && zPosition < 3)
        {
            Transform Shot = Instantiate(bullet, positionStart, bulletRotation);

            Vector3 shootDir = (beginTargetMiddle.position - positionStart).normalized;
            Shot.GetComponent<Bullet>().Setup(shootDir, "Shooter");
        }
        else
        {
            Transform Shot = Instantiate(bullet, positionStart, bulletRotation);

            Vector3 shootDir = (beginTargetBottom.position - positionStart).normalized;
            Shot.GetComponent<Bullet>().Setup(shootDir, "Shooter");
        }
    }


}

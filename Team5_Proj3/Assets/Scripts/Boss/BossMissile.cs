using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{
    [SerializeField] Transform Missile;
    [SerializeField] public GameObject Target;
    [SerializeField] Transform player;
    [SerializeField] Transform firePosition;

    private Vector3 playerPosition;
    private Vector3 finalPosition;

    private bool isLocked;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.position.x, -0.874f, player.position.z);
        if (isLocked == false)
        {
            Target.transform.position = playerPosition;
            
        }
        

        //2
        
    }
    private IEnumerator locking()
    {
        isLocked = false;
        Target.SetActive(true);
        yield return new WaitForSeconds(2f);
        isLocked = true;
        StartCoroutine(locked());
        print("Locked");

    }
    private IEnumerator locked()
    {
        yield return new WaitForSeconds(1f);
        fireMissile();
    }

    public void startLocking()
    {
        StartCoroutine(locking());
    }

    private void fireMissile()
    {
        Vector3 position = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
        Vector3 start = new Vector3(firePosition.position.x, firePosition.position.y, firePosition.position.z);
        Quaternion rotation = Target.transform.rotation;

        Vector3 shootDir = (position - start).normalized;
        Transform missile = Instantiate(Missile, start, rotation);
        missile.GetComponent<Missile>().Setup(shootDir);
    }
}

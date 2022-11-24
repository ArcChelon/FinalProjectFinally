using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Builder : MonoBehaviour
{
    [SerializeField] Transform prefab;
    [SerializeField] float timeBeforeSpawn;
    private Vector3 currentPosition;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = this.transform.rotation;
        StartCoroutine(BuildLevel());
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector3(this.transform.position.x, -1.47f, 0.070001f);
    }
    private IEnumerator BuildLevel()
    {
        yield return new WaitForSeconds(timeBeforeSpawn);
        Instantiate(prefab,currentPosition,rotation);
        StartCoroutine(BuildLevel());
    }
}

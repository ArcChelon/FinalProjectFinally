using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossHealth : MonoBehaviour
{
    [SerializeField] int bossHealth;
    [SerializeField] TMP_Text healthText;
    [SerializeField] Transform EndZone;
    private Vector3 BossPos;
    private Quaternion BossRot;
    private PlayerHealth PH;
    [SerializeField] GameObject Shield;
    private bool firstTimeOver = false;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem shockwave;
    [SerializeField] AudioSource boom;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = bossHealth.ToString();
        BossRot = gameObject.transform.rotation;
        PH = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        StartCoroutine(firstTimeShield());
    }

    private IEnumerator firstTimeShield()
    {
        Shield.SetActive(true);
        yield return new WaitForSeconds(5f);
        Shield.SetActive(false);
        firstTimeOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        BossPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        if(PH.isDamageAble == false)
        {
            Shield.SetActive(true);
        }
        else if(PH.isDamageAble == true && firstTimeOver == true)
        {
            Shield.SetActive(false);
        }
    }
    public void DamageBoss()
    {
        if(PH.isDamageAble == true)
        {
            bossHealth--;
            healthText.text = bossHealth.ToString();
            if (bossHealth <= 0)
            {
                StartCoroutine(Death());
            }
        }

    }
    private IEnumerator Death()
    {
        explosion.Play();
        shockwave.Play();
        boom.Play();
        yield return new WaitForSeconds(1);
        Transform Zone = Instantiate(EndZone, BossPos, BossRot);
        Destroy(gameObject);
    }


}

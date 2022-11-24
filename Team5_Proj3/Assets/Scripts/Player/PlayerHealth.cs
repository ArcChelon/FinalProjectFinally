using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerLives;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject DeathPanel;
    public bool isDamageAble = true;
    private int countingFrames;
    [SerializeField] int immunityTimesToCount;



    public void damagePlayer()
    {
        if (isDamageAble)
        {
            playerLives -= 1;
            healthText.text = playerLives.ToString() + "/5";
            isDamageAble = false;
            StartCoroutine(immunityFrames());
        }
        
        if (playerLives <= 0)
        {
            // CONNOR DEATH GOES HERE
            print("Player has died");
            DeathPanel.SetActive(true);
            //time stop
            Time.timeScale = 0;
        }
    }
    private IEnumerator immunityFrames()
    {
        SpriteRenderer color = gameObject.transform.Find("PlayerAnim").GetComponent<SpriteRenderer>();
        Color OGColor = color.color;
        color.color = Color.red;
        
        yield return new WaitForSeconds(.5f);
        color.color = OGColor;
        if (countingFrames < immunityTimesToCount)
        {
            print("Counting");
            
            countingFrames += 1;
            StartCoroutine(immunityFrames());
        }
        else
        {
            
            countingFrames = 0;
            isDamageAble = true;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = playerLives.ToString() + "/5";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

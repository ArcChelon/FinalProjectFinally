using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class Shoot : MonoBehaviour
{

    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction shootAction;

    [SerializeField] Transform bullet;
    [SerializeField] Transform gunBarrel;
    [SerializeField] Transform targetPosition;
    [SerializeField] AudioSource shoot;
    [SerializeField] int bullets;
    [SerializeField] TMP_Text bulletText;
    [SerializeField] AudioSource reloadSound;
    private bool isReloading;

   
    private int maxBullets;
    private Vector3 positionStart;
    private Quaternion bulletRotation;


    




    // Start is called before the first frame update
    void Awake()
    {
        
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        shootAction = playerInput.actions["Shoot"];
    }
    private void Start()
    {
        maxBullets = bullets;
        GameObject pBullet = GameObject.Find("Bullet(Clone)");
        if(pBullet != null)
        {
            Destroy(pBullet);
        }
        positionStart = new Vector3(gunBarrel.position.x, gunBarrel.position.y, gunBarrel.position.z);
        bulletRotation = gunBarrel.rotation;
        bulletText.text = bullets.ToString() + "/" + maxBullets.ToString();
        
    }
    private void OnEnable()
    {
        shootAction.performed += _ => OnFire();
    }

    // Update is called once per frame
    void Update()
    {
        positionStart = new Vector3(gunBarrel.position.x, gunBarrel.position.y, gunBarrel.position.z);
        
    }


    private void OnFire()
    {
        if(bullets > 0)
        {
            Transform Shot = Instantiate(bullet, positionStart, bulletRotation);


            Vector3 shootDir = (targetPosition.position - positionStart).normalized;
            Shot.GetComponent<Bullet>().Setup(shootDir, "Player");
            shoot.Play();
            bullets--;
            bulletText.text = bullets.ToString() + "/" + maxBullets.ToString();
            if(bullets <= 0)
            {
                StartCoroutine(reload());
            }
        }
        else
        {
            if(isReloading != true)
            {
                StartCoroutine(reload());
            }
            
        }
        
        
        





    }
    private IEnumerator reload()
    {
        reloadSound.Play();
        isReloading = true;
        yield return new WaitForSeconds(1f);
        bullets = maxBullets;
        bulletText.text = bullets.ToString() + "/" + maxBullets.ToString();
        isReloading = false;
    }

}

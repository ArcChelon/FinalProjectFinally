
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    private static MusicManager musicManagerInstance;


    void Awake()
    {
        

        string Name = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(this);
        
        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
            print("Checking");
        }
        else
        {
            Destroy(gameObject);
            print("Checking");
        }
        
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        string Name = SceneManager.GetActiveScene().name;
        if (Name == "Level_1" || Name == "Level_2")
        {
            print("Why");
            for(int i = 0; i < 3; i++)
            {
                GameObject destroy = GameObject.Find("MenuMusic");
                Destroy(destroy);
            }
        }
    }
}

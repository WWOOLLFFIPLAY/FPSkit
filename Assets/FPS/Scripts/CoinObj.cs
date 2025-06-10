using UnityEngine;
using UnityEngine.UI;

public class CoinObj : MonoBehaviour
{
    Vector3 startPos;
    Vector3 upPos;
    bool isUp;


    [SerializeField] private Text coinsText;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    void Start()
    {
        audioSource.Play();
        startPos = transform.position;
        isUp = true;
        upPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z); 
    }


    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        audioSource.PlayOneShot(clip, volume);
        GlobalData.Coins++;
        coinsText.text = "Coins: " + GlobalData.Coins + "/10";
    }

    void Update()
    {
        
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime);
            
        if (isUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, upPos, 1 * Time.deltaTime);
                
            if (transform.position.y - upPos.y <= 1)
            {
                isUp = false;
            }
        }
        else if (isUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 1 * Time.deltaTime);
            if (transform.position.y <= startPos.y)
            {
               isUp = true;
            }
        }
    }
}

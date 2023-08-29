using UnityEngine;

public class WzdEskill : MonoBehaviour
{
    public GameObject thunderStrikePrefab;
    public Transform attackPoint;
    public KeyCode attackKey = KeyCode.E;
    public AudioClip thunderSound; 
    public float soundVolume = 0.5f; 

    private AudioSource audioSource; 

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.clip = thunderSound;
        audioSource.volume = soundVolume;
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            PerformThunderStrike();
        }
    }

    void PerformThunderStrike()
    {
        GameObject thunderStrike = Instantiate(thunderStrikePrefab, attackPoint.position, attackPoint.rotation);
        Destroy(thunderStrike, 0.54f);

        // 번개 소리 재생
        PlayThunderSound();
    }

    void PlayThunderSound()
    {
        if (thunderSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(thunderSound);
        }
    }
}

using UnityEngine;

public class MiscPersonThings : MonoBehaviour
{
    private AudioSource characterAudioSource;
    [SerializeField] GameObject dialogueText;
    [SerializeField] Vector3 startPos;
    [SerializeField] AudioClip pickUp;

    void Start()
    {
        characterAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            
            characterAudioSource.PlayOneShot(pickUp);
            dialogueText.GetComponent<Scoreboard>().incrementCount();
        }
    }

    public void Reset()
    {
        transform.position = startPos;
        characterAudioSource.Play();
        Debug.Log("hit");
    }
}

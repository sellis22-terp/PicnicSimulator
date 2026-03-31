using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MiscPersonThings : MonoBehaviour
{
    private int count = 0;
    private AudioSource characterAudioSource;
    [SerializeField] int maxCount;
    [SerializeField] TextMeshProUGUI dialogueText;
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
            count++;
            
            characterAudioSource.PlayOneShot(pickUp);
        }

        ChangeText();
    }

    void ChangeText()
    {
        dialogueText.text = count + "/" + maxCount + " collected";
        // Can add stuff to open the door to scene here
    }

    public void Reset()
    {
        transform.position = startPos;
        characterAudioSource.Play();
        Debug.Log("hit");
    }
}

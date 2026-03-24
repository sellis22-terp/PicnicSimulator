using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonControls : MonoBehaviour
{
    Animator animatorLink;
    Vector2 moveInput;
    Rigidbody rigidLink;
    [SerializeField] float speedControl = 1500;
    Vector2 lookInput;
    [SerializeField] GameObject pivotLink;
    bool playerAlinged;
    //[SerializeField] AudioClip leftFootSound;
    //[SerializeField] AudioClip rightFootSound;


    void Start()
    {
        animatorLink = GetComponent<Animator>();
        rigidLink= GetComponent<Rigidbody>();
        rigidLink.maxLinearVelocity = 6;
       // audioLink = GetComponent<AudioSource>();
    }

    void Update()
    {
        RotatePlayer();
        RotatePivot();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveInput.y > 0 && playerAlinged)
        {
            var moveAmount = moveInput.y * speedControl * Time.deltaTime;
            rigidLink.AddRelativeForce(new Vector3(0, 0, moveAmount));
        }
    }

    private void RotatePivot()
    {
        if (lookInput.x != 0)
        {
            var rotateYAmount = lookInput.x * 20 * Time.deltaTime;
            pivotLink.transform.Rotate(new Vector3(0, rotateYAmount, 0));
        }
    }

    private void RotatePlayer()
    {
        if (moveInput.y > 0)
        {
            var pivotRotY = pivotLink.transform.rotation.eulerAngles.y;
            var playerRotY = transform.rotation.eulerAngles.y;

            var rotOffset = pivotRotY - playerRotY;

            if (rotOffset >180)
            {
                rotOffset = rotOffset - 360;
            }

            else if (rotOffset < -180)
            {
                rotOffset = 360 + rotOffset;
            }

            var rotateAmount = 500 * Time.deltaTime;

            playerAlinged = false;

            if (rotOffset >2)
            {
                transform.Rotate(0, rotateAmount, 0);
            }

            else if (rotOffset < -2)
            {
                transform.Rotate(0, -rotateAmount, 0);
            }

            else
            {
                playerAlinged=true;
            }
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        animatorLink.SetFloat("Speed", moveInput.y);

    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();

        if(lookInput.x > 50)
        {
            lookInput.x = 0;
        }
    }

    //public void PlayLeftFootSound ()
    //{
    //    audioLink.PlayOneShot(leftFootSound);
    //}

    //public void PlayRightFootSound()
    //{
    //    audioLink.PlayOneShot(rightFootSound);
    //}
}



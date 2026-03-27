// code to move clouds continually in a
// particular direction and then 
// reset them
//
//



using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform moverParent;
    Transform[] moverObjects;
    int moverCount;
    [SerializeField] Vector3 moveAmount;
    [SerializeField] Vector3 resetAmount;
    void Start()
    {
        moverObjects = moverParent.GetComponentsInChildren<Transform>();
        moverCount = moverObjects.Count();
    }

  
    void Update()
    {
        for (int index = 1; index < moverCount; index++)
        {
            moverObjects[index].Translate(moveAmount * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.IsChildOf(moverParent))
        {
            other.gameObject.transform.Translate(resetAmount);
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField] Transform Camera;
    [SerializeField] Transform TrashSpawn;

    [Space]
    int inventory = 0;
    int TrashCount;

    private void Start()
    {
        TrashSpawner TrashSpawner = TrashSpawn.GetComponent<TrashSpawner>();
        TrashCount = TrashSpawner.MaxTrash;
    }

    void Update()
    {
        PickUp();
    }

    private void PickUp()
    {
        if (Input.GetMouseButtonDown(0) && inventory != TrashCount)
        {
            Vector3 direction = Camera.transform.forward;
            float maxDistance = 3f;
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.transform.position, direction, out hitInfo, maxDistance) && hitInfo.transform.tag == "Trash")
            {
                inventory++;

                GameObject trash = hitInfo.transform.gameObject;
                Destroy(trash);
            }
        }
    }
}
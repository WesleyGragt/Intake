using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] int MaxTrash;
    [SerializeField] int SpawnMinDistance = 75;
    [SerializeField] int SpawnMaxDistance = 150;

    [SerializeField] List<GameObject> Cans;
    [SerializeField] List<GameObject> GlassBottles;
    [SerializeField] List<GameObject> Porcelin;
    List<GameObject> Trash;

    GameObject trashPiece;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < MaxTrash; i++)
        {
            float randomAngle = Random.Range(0f, 2f * Mathf.PI);
            float randomDistance = Random.Range(SpawnMinDistance, SpawnMaxDistance);

            Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)) * randomDistance;

            Instantiate(GetTrashType(i), GetPosition(spawnPosition), Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)), this.transform);
        }
    }

    private GameObject GetTrashType(int i)
    {
        switch (i % 3)
        {
            case 0:
                Trash = Cans;
                break;
            case 1:
                Trash = GlassBottles;
                break;
            case 2:
                Trash = Porcelin;
                break;
        }

        return trashPiece = Trash[Random.Range(0, Trash.Count)];
    }

    Vector3 GetPosition(Vector3 origin)
    {
        Vector3 direction = transform.up * -1;
        float maxDistance = 10f;
        RaycastHit hitInfo;

        //Debug.DrawRay(origin, direction*maxDistance, Color.magenta);

        Physics.Raycast(origin, direction, out hitInfo, maxDistance);
        return hitInfo.point;
    }
}

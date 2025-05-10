using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject BarrierPrefabs;
    public GameObject BMPrefabs;

    private void Start()
    {
        SpawnBarrier();
        SpawnBM();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GroundSpawner.Instance.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

    void SpawnBarrier()
    {
        int barrier = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(barrier).transform;
        Instantiate(BarrierPrefabs, spawnPoint.position, Quaternion.identity, transform);
    }

    void SpawnBM()
    {
        GameObject temp = Instantiate(BMPrefabs, transform);
        temp.transform.position = RandomPos(GetComponent<Collider>());
    }

    Vector3 RandomPos(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = RandomPos(collider);
        }

        point.y = 1;
        return point;
    }
}

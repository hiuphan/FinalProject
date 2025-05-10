using UnityEngine;

public class BanhMi : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager audio = FindObjectOfType<AudioManager>();
            if (audio != null)
            {
                audio.PlaySound("PickUp");
            }

            GameManager.instance.scores++;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}

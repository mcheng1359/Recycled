using UnityEngine;

public class StickyObjects : MonoBehaviour {
    void Update()
    {
        if(transform.parent == null){
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("Player")) {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<MeshCollider>().isTrigger = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(0.4f, 1f), transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && transform.parent == null) {
            transform.SetParent(other.gameObject.transform);
        }
    }
}

//transform.SetParent(collision.gameObject.transform);

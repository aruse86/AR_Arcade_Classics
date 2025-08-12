using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour {
    public float speed = 20f, lifeTime = 2f;

    void Start() {
        GetComponent<Rigidbody>().linearVelocity = transform.up * speed;
        Destroy(gameObject, lifeTime);
    }
    void Update(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

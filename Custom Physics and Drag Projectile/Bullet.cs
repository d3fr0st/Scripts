using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Vector3 velocity, acceleration; // meters per second
    public float dragCoefficient = 0.25f; // adjust as ballisticly appropriate
    public float mass; // in kilograms 
    private Vector3 dragForce, forces, drag; // not in midichlorians
    private float area;


    private Vector3 gravity = new Vector3(0, -9.806f, 0);
    private float airDensity = 1.2252f;

    // Use this for initialization
    void Start () {
        if(GameObject.Find("Athmo"))
        {

        }
        Renderer rend = GetComponent<Renderer>();
        area = Mathf.PI * (rend.bounds.extents.magnitude);
        Debug.Log(area);

        StartCoroutine(PhysicsCoroutine());
	}
	
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Boop");
        Destroy(this.gameObject);
    }

    public void AddForce (Vector3 force)
    {
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
    }


    IEnumerator PhysicsCoroutine()
    {
        while(true)
        {
            Vector3 norm = velocity.normalized;
            drag = 0.47f * (0.5f * (new Vector3(velocity.x * velocity.x, velocity.y * velocity.y, velocity.z * velocity.z) * airDensity)) * area; //https://www.grc.nasa.gov/www/k-12/airplane/drageq.html
            dragForce = new Vector3(drag.x * -norm.x, drag.y * -norm.y, drag.z * -norm.z);

            AddForce(gravity + dragForce);
            //velocity -= dragForce;
            Debug.Log(velocity);

            transform.position += velocity * Time.deltaTime;
            yield return null;
        }
    }
}

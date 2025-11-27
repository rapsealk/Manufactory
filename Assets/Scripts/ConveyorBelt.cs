using UnityEngine;
using System.Collections.Generic;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float conveyorSpeed;

    private Material material;

    [SerializeField]
    private List<GameObject> onBelt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += new Vector2(0, 1) * conveyorSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector3 desiredVelocity = Vector3.right * conveyorSpeed * 10;

        foreach (GameObject obj in onBelt)
        {
            var rigidbody = obj.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                Vector3 velocityChange = desiredVelocity - rigidbody.linearVelocity;
                rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
            }
            // obj.GetComponent<Rigidbody>().AddForce(Vector3.right * conveyorSpeed * 10 * 50, ForceMode.Force);
        }
    }
}

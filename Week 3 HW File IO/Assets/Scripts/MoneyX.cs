using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyX : MonoBehaviour
{
    //how fast obj moves
    public float speed = 2;
    
    //initial position
    private Vector3 initialPos;

    private Transform cachedTransform;

    public int resetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        cachedTransform = transform;
        initialPos = cachedTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        newPos.x += speed * Time.deltaTime;

        transform.position = newPos;

        if (cachedTransform.position.x >= resetPosition)
        {
            cachedTransform.position = initialPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);

            GameManager.Instance.Money++;
        }
    }
}

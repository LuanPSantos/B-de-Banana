using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Renderer mapRenderer;

    private float rightLimit;
    private float leftLimit;
    private float topLimit;
    private float bottomLimit;

    void Start()
    {
        leftLimit = (mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2) + (Camera.main.orthographicSize * Camera.main.aspect);
        rightLimit = (mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2) - (Camera.main.orthographicSize * Camera.main.aspect);
        topLimit = (mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2) - Camera.main.orthographicSize;
        bottomLimit = (mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2) + Camera.main.orthographicSize;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), 5f * Time.deltaTime);

        float limitX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        float limitY = Mathf.Clamp(transform.position.y, bottomLimit, topLimit);

        transform.position = new Vector3(limitX, limitY, transform.position.z);
    }
}

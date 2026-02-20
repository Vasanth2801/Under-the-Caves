using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layerTransform;
        [Range(0,1)] public float parallaxFactor;
    }

    public ParallaxLayer[] parallaxLayers;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - lastCameraPosition;

        foreach(ParallaxLayer layer in parallaxLayers)
        {
           float parallaxX = delta.x * layer.parallaxFactor;
           float parallaxY = delta.y * layer.parallaxFactor;
           layer.layerTransform.position += new Vector3(parallaxX, parallaxY, 0);
        }

        lastCameraPosition = cameraTransform.position;
    }
}
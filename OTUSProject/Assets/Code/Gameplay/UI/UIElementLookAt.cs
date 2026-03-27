
using UnityEngine;
using Zenject;

public class UIElementLookAt : MonoBehaviour
{
    private FreeFlyCamera _freeFlyCamera;

    [Inject]
    public void Construct(FreeFlyCamera freeFlyCamera)
    {
        _freeFlyCamera = freeFlyCamera;
    }

    private void Update()
    {
        transform.LookAt(_freeFlyCamera.transform.position);
    }
}


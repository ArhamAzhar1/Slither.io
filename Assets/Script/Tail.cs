using UnityEngine;

public class Tail : MonoBehaviour
{

    public Transform networkOwner;
    public Transform followTransform;

    [SerializeField] private float delayTime =0.1f;
    [SerializeField] private float distance = 0.3f;
    [SerializeField] private float moveStep = 10f;

    private Vector3 _targetPosition;

    private void Update()
    {
        _targetPosition = followTransform.position - followTransform.forward * distance;
        _targetPosition += (followTransform.position - _targetPosition) * delayTime;
        _targetPosition.z = 0f;

        transform.position = Vector3.Lerp(followTransform.position, _targetPosition, Time.deltaTime * moveStep) ;
    }
}

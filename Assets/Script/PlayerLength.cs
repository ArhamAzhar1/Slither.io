using UnityEngine;
using System.Collections.Generic;
using Unity.Netcode;

public class PlayerLength : NetworkBehaviour
{
    [SerializeField]
    private GameObject tailPrefab;
    public NetworkVariable<ushort> length = new(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private List<GameObject> _tails;
    private Transform _lastTail;
    private Collider2D _collider2D;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        _tails = new List<GameObject>();
        _lastTail = transform;
        _collider2D = GetComponent<Collider2D>();
    }

        private void InsantiateTail()
        {
            GameObject tailGameObject = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            if (tailGameObject.TryGetComponent(out Tail tail))
            {
                tail.networkOwner = transform;
                tailGameObject.followTransform = _lastTail;
                _lastTail = tailGameObject.transform;
                Physics2D.IgnoreCollision(tailGameObject.GetComponent<Collision2D>(), _collider2D);
            }
            _tails.Add(tailGameObject);
        }
}

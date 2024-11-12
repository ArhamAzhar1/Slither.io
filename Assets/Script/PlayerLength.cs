using UnityEngine;
using System.Collections.Generic;
using Unity.Netcode;

public class PlayerLength : NetworkBehaviour
{
    [SerializeField]
    private GameObject tailPrefab;
    public NetworkVariable<ushort> length = new(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private List<GameObject> _tails;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        _tails = new List<GameObject>();
    }

        private void InsantiateTail()
        {
            GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            _tails.Add(tail);
        }
}

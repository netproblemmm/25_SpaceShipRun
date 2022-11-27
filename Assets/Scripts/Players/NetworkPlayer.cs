using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.Networking.NetworkServer;

namespace Players
{
    public class NetworkPlayer : NetworkBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        private GameObject playerCharacter;

        private void Start()
        {
            SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            if (!isServer)
                return;

            playerCharacter = Instantiate(playerPrefab, transform.position, transform.rotation);
            SpawnWithClientAuthority(playerCharacter, connectionToClient);
        }
    }
}

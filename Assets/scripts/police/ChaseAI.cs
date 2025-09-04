using UnityEngine;
using UnityEngine.AI; // Tarvitaan NavMeshAgentille

public class ChaseAI : MonoBehaviour
{
    // Aseta t‰m‰ pelaajaobjektiin Inspectorissa
    public Transform player;

    private NavMeshAgent agent;

    void Start()
    {
        // Haetaan NavMeshAgent-komponentti automaattisesti
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Jos pelaaja on olemassa, aseta h‰net agentin m‰‰r‰np‰‰ksi
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
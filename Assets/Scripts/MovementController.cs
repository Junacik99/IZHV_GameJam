using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;

    private Camera cam;
    private NavMeshAgent agent;
    private Animator animator;

    public bool isPaused = false;

    void Awake()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;

        // Set agent destination on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                agent.SetDestination(raycastHit.point);

                // Instantiate arrow sprite
                var arrowPos = raycastHit.point;
                arrowPos.y += 1;
                var arrows = GameObject.FindGameObjectsWithTag("Arrow");
                foreach (var a in arrows)
                    Destroy(a);
                var arrow = Instantiate(arrowPrefab, arrowPos, Quaternion.identity);
                Destroy(arrow, 1.5f);
            }
        }

        /* TODO: agent sa najskor otoci, az potom pohne*/
        

        // Set animator properties
        animator.SetBool("IsMoving", agent.velocity != Vector3.zero);
        animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
        
    }

    public float GetAgentSpeed() => agent.velocity.magnitude;
}

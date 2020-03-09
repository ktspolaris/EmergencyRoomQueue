using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    //public Dictionary<int, Transform> lobbySeats = new Dictionary<int, Transform>();
    public List<Transform> lobbySeats = new List<Transform>();
    public LinkedList<GameObject> triageList = new LinkedList<GameObject>();
    public LinkedList<GameObject> labList = new LinkedList<GameObject>();
    public LinkedList<GameObject> treatList = new LinkedList<GameObject>();
    public LinkedList<GameObject> emergencyList = new LinkedList<GameObject>();


    public Transform seat;
    public GameObject Lab;
    public GameObject Triage;
    public GameObject Treat;
    public GameObject Emergency;
    public Material triageMaterial;
    public Material TreatMaterial;
    public Material leaveMaterial;
    public Material labMaterial;
    public Material emergencyMaterial;
    private float posX;
    private float posY;
    //private bool firstone = false;
    //private int seatNum;
    private Transform firstFreeSeat;

    //Queueing
    public static int TriaQueue = 0;
    public static int LabQueue = 0;
    public static int TreatQueue = 0;
    public static int ICUQueue = 0;


    // Start is called before the first frame update
    void Start()
    {
        posX = -8f;
        posY = -15f;
        //seatNum = 1;
        for (int i = 0; i < 10; i++) {
            for (int q = 0; q < 5; q++) {
                seat.transform.position = new Vector3(posX, posY, 0);
                GameObject obj = Instantiate(seat.gameObject);
                lobbySeats.Add(obj.transform);
                posX += 1f;
                posY += 2f;
            }
           
            posY = -15f;
            posX = posX - 2f;
        }

        firstFreeSeat = lobbySeats[0];
        Debug.Log(lobbySeats.Count);
        for (int i = 0; i < lobbySeats.Count; i++) {
            Debug.Log(lobbySeats[i].position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //firstone = true;
        if (collider2D.GetComponent<PlayerController>().destination == GameObject.Find("GameObject").transform)
        {
            // Debug.Log("11111");
            triageList.AddLast(collider2D.gameObject);
            collider2D.GetComponent<MeshRenderer>().material = triageMaterial;
            Debug.Log(triageList.Count);

        }
        RecivePatient(collider2D.gameObject);
        Debug.Log("enter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Triage.GetComponent<Triage>().isAvaliable && triageList.First != null)
        {

            SendPatient(Triage.transform);
            Triage.GetComponent<Triage>().isAvaliable = false;

        }
        if (Treat.GetComponent<Treat>().isAvaliable && treatList.First != null) 
        {
            
                SendPatient(Treat.transform);
                Treat.GetComponent<Treat>().isAvaliable = false;
            
        }
        if (Lab.GetComponent<Lab>().isAvaliable && labList.First != null)
        {
            SendPatient(Lab.transform);
            Lab.GetComponent<Lab>().isAvaliable = false;

        }
        if (Emergency.GetComponent<Emergency>().isAvaliable && emergencyList.First != null)
        {
            SendPatient(Emergency.transform);
            Emergency.GetComponent<Emergency>().isAvaliable = false;

        }

        TriaQueue = triageList.Count;
        LabQueue = labList.Count;
        ICUQueue = emergencyList.Count;
        TreatQueue = treatList.Count;


    }

    public void SendPatient(Transform destination)
    {
        // FIND THE PETIENT IN THE FIRST SORT AND SET DESTINATION
        switch (destination.name)
        {
            case "Triage":
                //  if (triageList.First.Value.GetComponent<PlayerController>().isSit == true)
                //{
                triageList.First.Value.GetComponent<PlayerController>().destination = Triage.transform;
                if (triageList.First.Value.GetComponent<PlayerController>().nowSeat != null)
                {

                    triageList.First.Value.GetComponent<PlayerController>().nowSeat.GetComponent<Seat>().isOccupied = false;
                    triageList.First.Value.GetComponent<PlayerController>().nowSeat = null;
                }
                triageList.RemoveFirst();
                //}
                break;
            case "Lab":
                Debug.Log("leave for lab");
                labList.First.Value.GetComponent<PlayerController>().destination = Lab.transform;
                if (labList.First.Value.GetComponent<PlayerController>().nowSeat != null)
                {
                    labList.First.Value.GetComponent<PlayerController>().nowSeat.GetComponent<Seat>().isOccupied = false;
                    labList.First.Value.GetComponent<PlayerController>().nowSeat = null;
                }
                labList.RemoveFirst();
                break;
            case "Treat":
                Debug.Log("leave for treat");

                treatList.First.Value.GetComponent<PlayerController>().destination = Treat.transform;
                if (treatList.First.Value.GetComponent<PlayerController>().nowSeat != null)
                {
                    treatList.First.Value.GetComponent<PlayerController>().nowSeat.GetComponent<Seat>().isOccupied = false;
                    treatList.First.Value.GetComponent<PlayerController>().nowSeat = null;
                }
                treatList.RemoveFirst();
                Debug.Log("treat list after leave for treat" + treatList.Count);
                break;
            case "Emergency":
                emergencyList.First.Value.GetComponent<PlayerController>().destination = Emergency.transform;

                if (emergencyList.First.Value.GetComponent<PlayerController>().nowSeat != null)
                {
                    emergencyList.First.Value.GetComponent<PlayerController>().nowSeat.GetComponent<Seat>().isOccupied = false;
                    emergencyList.First.Value.GetComponent<PlayerController>().nowSeat = null;
                }

                emergencyList.RemoveFirst();
                break;

        }



    }
    public void RecivePatient(GameObject patientIn) {
        // FIND THE FIRST AVLIABLE SEAT AND SET IT AS THE DESTINATION OF THE PATIENT'
        firstFreeSeat = lobbySeats.Find(seat => seat.gameObject.GetComponent<Seat>().isOccupied != true);
        if (firstFreeSeat != null)
        {
            firstFreeSeat.GetComponent<Seat>().isOccupied = true;

            patientIn.GetComponent<PlayerController>().destination = firstFreeSeat;
            patientIn.GetComponent<PlayerController>().nowSeat = firstFreeSeat.transform;
        }
      
        //Debug.Log(triageList.First.Value.name);

    }

   


   
}

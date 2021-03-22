using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasesController : MonoBehaviour
{
    //get a referece link to create or join room canvas 
    [SerializeField]
    private CreateOrJoinRoom createOrJoinRoom;//variable to find from editor
    public CreateOrJoinRoom CreateOrJoinRoom { get { return createOrJoinRoom; } }//variable to get access from other scripts

    //get a reference link to current room canvas
    [SerializeField]
    private CurrentRoom currentRoom;//variable to find from editor
    public CurrentRoom CurrentRoom { get { return currentRoom; } }//variable to get access from other scripts
    
    private void Awake()
    {
        Initialize();
    }
    void Start()
    {
        Master.GameSettings.Id = 0;
        Master.GameSettings.IsOver = false;
        Master.GameSettings.Winner = null;
    }
    private void Initialize()
    {
        createOrJoinRoom.Initialize(this);
        currentRoom.Initialize(this);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    //Variables static
    public static GAMEMANAGER i;


    //Variables "grab"
    [NonSerialized] public string gameState = "Playing";
    [NonSerialized] public double secondsElapsed = 0;
    [NonSerialized] public int STAT_INSECT = 0;
	[NonSerialized] public int STAT_CROISSANCE = 0;
    [NonSerialized] public int STAT_CHAMPI = 0;
	[NonSerialized] public List<GameObject> Bouts = new List<GameObject>();
	[NonSerialized] public List<GameObject> tickReceiver = new List<GameObject>();

	[Header("DEBUG")]
    [SerializeField] private bool doPrint = false;
	[Space]
	[Space]
	[Header("Pr�paration")]
	[SerializeField] private GameObject PF_Champi;
    [Header("Indicateurs")]
    [SerializeField] private List<GameObject> allBouts;
	[Space]
	[Space]
	[Space]
    [Space]
	[Header("Param�tres")]
    [Header("- Ticks")]
    [Tooltip("Toutes les combien de secondes est-ce qu'un tick arrive [D�faut = 1]")]
    public float tickRate = 1;

	//Invokers
	void Awake()
    {
        Init();
    }
	private void Start()
	{
        //D�marrer boucle des ticks
        Invoke("doTick", 1);
	}
	private void Update()
	{
        Indicateurs();
	}

	//Fonctions majeures
	void doTick()
    {
        if (gameState == "Playing")
        {
			foreach (GameObject receiver in tickReceiver)
			{
				switch (receiver.tag)
				{
					case "Racine":
						receiver.GetComponent<Racine>().Tick();
						break;

					case "Enemy_Grillon":
						receiver.GetComponent<Enemy>().Tick();
						break;

					case "Enemy_Ver":
						receiver.GetComponent<Enemy>().Tick();
						break;

					case "Enemy_Fourmi":
						receiver.GetComponent<Enemy>().Tick();
						break;

					case "Champi":
						receiver.GetComponent<Champi>().Tick();
						break;
				}
			}

			//Boucle
			secondsElapsed++;
			Invoke("doTick", 1);
		}
	}

	//Fonctions mineures
	private void Init()
    { 
        //Singletons
        if (i == null)
        {
            i = this;
        }
    }

	private void spawnChampi()
	{
		if (GameObject.Find("Champi") == null || GameObject.Find("Champi (Clone)") == null)
		{
			Instantiate(PF_Champi, new Vector3(0.112f, 3.329f, -0.0077255f), Quaternion.identity);
		}
	}


	private void printer(object message)
    {
        if (doPrint)
        {
            print(message);
        }
    }

    private void Indicateurs()
    {
        allBouts = Bouts;
    }
}

using UnityEngine;
using System.Collections;

public class DemoLevelController : MonoBehaviour {


	public bool disableFirstObstacle;
	public bool disableSecondObstacle;
	public GameObject firstObstacle;
	public GameObject obstacle1BackupLights;
	public GameObject firstObstaclePlatform1;
	public GameObject firstObstaclePlatform2;
	public GameObject secondObstacle;
	public GameObject obstacle2BackupLights;

	// Use this for initialization
	void Start () {
		if (disableFirstObstacle) {
			firstObstacle.SetActive (false);
			obstacle1BackupLights.SetActive(true);
			firstObstaclePlatform1.SetActive(false);
			firstObstaclePlatform2.SetActive(false);
		}
		if (disableSecondObstacle) {
			secondObstacle.SetActive (false);
			//obstacle2BackupLights.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}

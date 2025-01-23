using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour {

    [SerializeField] private GameObject spawnCenter;
    public List<Transform> targets, wallList;
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime = 0.5f;
    private bool wallIsAddedToList, hasAdded;

    private void LateUpdate() {
        if (targets.Count == 0) {
            return;
        }
        //Get center point
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        spawnCenter.transform.position = centerPoint;
        //Raycast for wall fade detection
        RaycastHit hit;
        if (targets.Count >= 0) {
            Ray ray = new Ray(gameObject.transform.position, (centerPoint - gameObject.transform.position).normalized);
            Debug.DrawLine(gameObject.transform.position, centerPoint, Color.green);
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            if (hit.collider.tag == "Wall") {
                wallIsAddedToList = true;
                    Debug.DrawLine(gameObject.transform.position, centerPoint, Color.red);
                    hit.transform.GetComponent<TransparentFader>().willFade = true;
                if (hasAdded == false) {
                    hasAdded = true;
                    RemoveWall(hit.transform);
                    AddWall(hit.transform);
                }
                Debug.Log("Wall hit");
            }
            else {
                wallIsAddedToList = false;
            }
        }
        if (wallIsAddedToList == false){
            foreach(Transform wall in wallList){
                wall.GetComponent<TransparentFader>().willFade = false;
            }
            hasAdded = false;
        }
    }

    //Adds wall to list
    private void AddWall(Transform wl) {
        wallList.Add(wl);
    }

    //Removes wall from list
    private void RemoveWall(Transform wl) {
        wallList = new List<Transform>();
    }

    //Adds player to list
    public void AddPlayer(Transform pl) {
            targets.Add(pl);
    }

    //Removes player form list
    public void RemovePlayer(Transform pl) {
        targets.Remove(pl);
    }

    //Gets the center point between all players
    public Vector3 GetCenterPoint() {
        if(targets.Count == 1) {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position,Vector3.zero);
        for (int i = 0; i < targets.Count;i++) {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}

//Script by Jacob
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordCursor1 : MonoBehaviour {

    public Transform EYE;

    public Vector3 NormalScale = new Vector3(1f, 0.5f, 1f);
    public float NormalDistance = 0.6f;

    private MeshRenderer meshRenderer;
    private const float MAX_DISTANCE = 500;
    private const float MIN_DISTANCE = 0.5f;
    private GameObject TargetGm;
    public GameObject EnginePrefab;
    private bool Play = false;

	// Use this for initialization
	void Start () {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        if(EYE != null)
        {
            var headPosition = EYE.position;
            var gazeDirection = EYE.forward;
            RaycastHit hitInfo;
            if(Physics.Raycast(headPosition, gazeDirection, out hitInfo, MAX_DISTANCE))
            {
                meshRenderer.enabled = true;
                float rdistance = Vector3.Distance(headPosition, hitInfo.point);
                float rscale = rdistance * NormalScale.x / NormalDistance;
                Vector3 rvscale = this.transform.localScale;
                Vector3 nscale = new Vector3(rscale, rvscale.y, rscale);
                this.transform.localScale = nscale;

                this.transform.position = hitInfo.point;
               // this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                TargetGm = hitInfo.collider.gameObject;
            }
            else
            {
                if (TargetGm!=null)
                {
                    Button button = TargetGm.GetComponent<Button>();
                    Image image = TargetGm.GetComponent<Image>();
                    if (image != null && button != null)
                    {
                        image.color = button.colors.normalColor;
                    }
                    TargetGm = null;
                }
               
                meshRenderer.enabled = false;
                Vector3 target = gazeDirection.normalized * NormalDistance + headPosition;
                this.transform.position = target;
      
                //if (Vector3.Distance(headPosition, this.transform.position) > MAX_DISTANCE)
                //{
                //    Vector3 target = gazeDirection.normalized * MAX_DISTANCE + headPosition;
                //    float rdistance = Vector3.Distance(headPosition, target);
                //    float rscale = rdistance * NormalScale.x / NormalDistance;
                //    Vector3 rvscale = this.transform.localScale;
                //    Vector3 nscale = new Vector3(rscale, rvscale.y, rscale);
                //    this.transform.localScale = nscale;

                //    this.transform.position = target;
                //}
                //else if(Vector3.Distance(headPosition, this.transform.position) < MIN_DISTANCE)
                //{
                //    Vector3 target = gazeDirection.normalized * MIN_DISTANCE + headPosition;
                //    float rdistance = Vector3.Distance(headPosition, target);
                //    float rscale = rdistance * NormalScale.x / NormalDistance;
                //    Vector3 rvscale = this.transform.localScale;
                //    Vector3 nscale = new Vector3(rscale, rvscale.y, rscale);
                //    this.transform.localScale = nscale;

                //    this.transform.position = target;
                //}
            }
        }

        if (TargetGm!=null)
        {
            Button button = TargetGm.GetComponent<Button>();
            Image image = TargetGm.GetComponent<Image>();
            if (image != null&&button!=null)
            {
                image.color = button.colors.pressedColor;
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton0)
                  || Input.GetKeyUp(KeyCode.Return)
                  || Input.GetKeyUp(KeyCode.KeypadEnter)
                  || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                  || Input.GetMouseButtonDown(0))
            {
                if (EnginePrefab.transform.parent==null)
                {
                    EnginePrefab.transform.SetParent(EYE);
                }
                else
                {
                    EnginePrefab.transform.parent = null;
                }
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton0)
                  || Input.GetKeyUp(KeyCode.Return)
                  || Input.GetKeyUp(KeyCode.KeypadEnter)
                  || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                  || Input.GetMouseButtonDown(0))
            {
                Debug.Log("Play="+Play);
                Play = !Play;
                EnginePrefab.GetComponent<Animator>().SetBool("Play", Play);
            }
        }
	
	}
}

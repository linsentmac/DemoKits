using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordCursor2 : MonoBehaviour {

    public Transform EYE;
    public ModelPanel modelPanel;

    public Vector3 NormalScale = new Vector3(1f, 0.5f, 1f);
    public float NormalDistance = 0.6f;

  //  private MeshRenderer meshRenderer;
    private const float MAX_DISTANCE = 500;
    private const float MIN_DISTANCE = 0.5f;

    private IModelShow ModelShow;
    private int index = 0;
    private bool play = false;

    private Vector3 tempPos;
	// Use this for initialization
	void Start () {
       // meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
     
        Init();
    }

    void Init()
    {

        if (modelPanel.modelArray[index] != null)
        {
            ModelShow = modelPanel.modelArray[index];
            if (!ModelShow.gameObject.activeSelf)
            {
                ModelShow.gameObject.SetActive(true);
              
            }
            ModelShow.NextModelShow(ModelShow,EYE);
        }
        else
        {
            Debug.LogError("ModelShow Is Null");
        }
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
              //  Debug.LogError("RaycastHit");
           //     meshRenderer.enabled = true;
                float rdistance = Vector3.Distance(headPosition, hitInfo.point);
                float rscale = rdistance * NormalScale.x / NormalDistance;
                Vector3 rvscale = this.transform.localScale;
                Vector3 nscale = new Vector3(rscale, rvscale.y, rscale);
                this.transform.localScale = nscale;

                this.transform.position = hitInfo.point;
                // this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
             
            }
            else
            {
            
            //    meshRenderer.enabled = false;
                Vector3 target = gazeDirection.normalized * NormalDistance + headPosition;
                this.transform.position = target;
            }
        }


        ShowHandle();

    }



    void ShowHandle()
    {
        if (ModelShow != null & ModelShow.gameObject.activeSelf)
        {
            if (tempPos!=ModelShow.transform.position)
            {
                tempPos = ModelShow.transform.position;
                Debug.Log(ModelShow.gameObject.name + " " + ModelShow.transform.position);
            }
           
            if (Input.GetKeyUp(KeyCode.JoystickButton0)
                  || Input.GetKeyUp(KeyCode.Return)
                  || Input.GetKeyUp(KeyCode.KeypadEnter)
                  || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                  || Input.GetMouseButtonDown(0))
            {
                play = !ModelShow.HasNextState;
                if (play)
                {
                    index++;
                    if (index >= modelPanel.modelArray.Count)
                    {
                        index = 0;
                        //Application.Quit();                 
                    }
                    ModelShow.NextModelShow(modelPanel.modelArray[index], EYE);
                    ModelShow = modelPanel.modelArray[index];
                   
                }
                else
                {
                    ModelShow.ShowAnimation(ModelShow);
                }
            }

        }

    }
}

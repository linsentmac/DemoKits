using UnityEngine;
using System.Collections;

public class ViewPointControl : MonoBehaviour {


    public Transform PadView;
    public Transform Eye;

   
   // public float ViewYGap = -0.037f;
    //public float ViewScale = 0.8f;
    public float SlideSpeed = 0.5f;
    public float SlideAngleMAX = 30f;
    public float SlideAngleMIN = 10f;
    public bool OnceMove = true;
    
    private bool hasOnceMove = false;
    private float OnceMoveWait = 0f;

    private float ViewDistance = 0.608f;
    private Vector2 ViewForward = Vector2.zero;
    private Vector2 EyeForward = Vector2.zero;
    private bool IsSliding = false;


    /*
    Vector3 currOffset = TargetOffset - transform.localPosition;
            
            if (currOffset.Equals(Vector3.zero))
            {
                return;
            }
            transform.Translate(currOffset* Time.deltaTime * SPEED, Space.Self);
            */

    // Use this for initialization
    void Start () {
        if(PadView != null && Eye != null)
        {
            ViewForward.Set(PadView.forward.x, PadView.forward.z);
            EyeForward.Set(Eye.forward.x, Eye.forward.z);
            ViewDistance = Vector3.Distance(Eye.position, PadView.position);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (PadView == null || Eye == null) return;

        Vector3 ViewforwardV3 = Vector3.Normalize(PadView.position - Eye.position);
        ViewForward.Set(ViewforwardV3.x, ViewforwardV3.z);
        EyeForward.Set(Eye.forward.x, Eye.forward.z);

        float angleCurr = Mathf.Abs(Vector2.Angle(EyeForward, ViewForward));

        if (OnceMove)
        {
            //Debug.Log("OnceMove : " + angleCurr);
            if (OnceMoveWait <= 0f)
            {
                OnceMoveWait = Time.time;
            }
            if (!hasOnceMove && Time.time > 1f)
            {
                Debug.Log("Start handle angle : "+ angleCurr);
                if(angleCurr > SlideAngleMAX)
                {
                    Vector3 target = (Vector3.Normalize(new Vector3(EyeForward.x, 0, EyeForward.y)) * ViewDistance) + Eye.position;
                    target.Set(target.x, PadView.position.y, target.z);
                    PadView.position = target;

                    Vector3 ViewforwardOnce = Vector3.Normalize(PadView.position - Eye.position);
                    Vector3 V3curr = new Vector3(ViewforwardOnce.x, 0f, ViewforwardOnce.z);
                    PadView.rotation = Quaternion.FromToRotation(Vector3.forward, V3curr);
                }
                hasOnceMove = true;
            }
            return;
        }


        if(IsSliding && angleCurr < SlideAngleMIN && Vector3.Distance(PadView.position, Eye.position) > (ViewDistance-0.2f))
        {
            IsSliding = false;
        }

        if(!IsSliding && angleCurr > SlideAngleMAX)
        {
            IsSliding = true;
        }

        if (IsSliding && Mathf.Abs(EyeForward.x+EyeForward.y) > 0.01f)
        {
            //Debug.Log("IS IsSliding......");
            Vector3 target = (Vector3.Normalize(new Vector3(EyeForward.x, 0, EyeForward.y)) * ViewDistance) + Eye.position;
            target.Set(target.x, PadView.position.y, target.z);
            //if (Vector3.Distance(target, Eye.position) < (ViewDistance *3f /4f)) return;
            Vector3 offset = target - PadView.position;
            PadView.Translate(offset * Time.deltaTime * SlideSpeed, Space.World);
            Vector3 V3curr = new Vector3(ViewforwardV3.x, 0f, ViewforwardV3.z);
            PadView.rotation = Quaternion.FromToRotation(Vector3.forward, V3curr);
        }
        else
        {

        }
    }
}

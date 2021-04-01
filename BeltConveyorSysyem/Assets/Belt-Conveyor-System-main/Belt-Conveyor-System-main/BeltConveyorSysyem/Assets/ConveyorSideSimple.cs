using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSideSimple : MonoBehaviour
{
    public float Eulerspeed;
    public GameObject FlatObj;
    public float FlatSpeed;
    Rigidbody Side_rb;
    Material mymaterial;
    // Start is called before the first frame update
    void Start()
    {
        this.FlatSpeed = this.FlatObj.GetComponent<ConveyorSimple>().speed;//t , FlatSpeed = 向こうのspeed
        this.Eulerspeed = (1 * Mathf.PI) / (400 * FlatSpeed) ;
        /// <summary>
        /// ConveyorSimple.speedはしっかり1m/sなのでこれをt(m/s)とすると,このオブジェクトの直径は0.9なので
        /// 半円を移動したときを考えると0.9*πが半円上の長さになる。これをt秒間で移動だから /t して[20t分の9π](秒)
        /// この時間で180°動くので1°動くには /180 。よって
        /// 9π     1       1
        /// —―― * ―――― = ――――― π
        /// 20t   180     400t
        /// Eulaerspeedは1°動くのにかかる時間(s)
        /// </summary>
        /// <typeparam name="Rigidbody"></typeparam>
        /// <returns></returns>

        this.Side_rb = GetComponent<Rigidbody>();
        this.mymaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //3byougotonikousin
        //if(Time.fixedTime >= 1)UnityEditor.EditorApplication.isPaused = true;
        
        var material                = this.mymaterial;
        Vector2 offset              = material.mainTextureOffset;
        offset                     += Vector2.right*1*Time.deltaTime*Eulerspeed*0.0000000000000000000000000000000000000000000000000000000000000001f/*0.005f;//*/  ;
        material.mainTextureOffset  = offset;
    }

    void FixedUpdate()
    {
        Quaternion pos = Side_rb.rotation;
        /// <summary>
        /// Quartanionのどれか1つの引数に1を入れてやると1秒で51°動くことが分かったので、これを用いて
        /// 1秒で51°回転するにはQuartanion値は1
        /// 1秒で■ °回転するにはQuartanion値は▲  ということになる。■、▲求めるため
        /// まずは■から、上のsummaryより(20t分の9π)秒で180°動くことが分かったので１秒当たり180*(20t/9π)でπ分の400t
        /// そして、５１°はQuartanion値１なので
        /// (π分の400t)°は1 * (π分の400t) = (400t分の51π)[Quartanion値]
        /// </summary>
        /// <param name="Mathf.PI)"></param>
        /// <param name="0"></param>
        /// <returns></returns>
        Quaternion movepos = Quaternion.Euler(0, (400 * FlatSpeed) / (51 * Mathf.PI)  ,  0);
        Side_rb.MoveRotation(pos * movepos);

    }
}

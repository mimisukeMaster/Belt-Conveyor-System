using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSimple : MonoBehaviour
{
    public float speed ;// m/s
    //変更点:選択肢の言葉と実際の上の物体が進む向きが逆である為、正しい向きに名を合わせた
    public enum VectorDirection{
        forward,//back,
        back,//forward,
        right,//left,
        left//right,
    }
    public VectorDirection ChosenVec;
    public bool Reverse = false;
    Rigidbody MyrbBody;
    Material mymaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        this.MyrbBody = this.gameObject.GetComponent<Rigidbody>();
        this.mymaterial = this.gameObject.GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        ScrollUV();
    }

    void FixedUpdate()
    {
        switch(ChosenVec){
            case VectorDirection.forward:
                Vector3 posB = MyrbBody.position;
                MyrbBody.position +=  Vector3.back * speed * Time.fixedDeltaTime;
                MyrbBody.MovePosition(posB);
                break;
            

            case VectorDirection.back:
                Vector3 posU = MyrbBody.position;
                MyrbBody.position +=  Vector3.forward * speed * Time.fixedDeltaTime;
                MyrbBody.MovePosition(posU);
                break;

            case VectorDirection.right:
                Vector3 posL = MyrbBody.position;
                MyrbBody.position +=  Vector3.left * speed * Time.fixedDeltaTime;
                MyrbBody.MovePosition(posL);
                break;

            case VectorDirection.left:
                Vector3 posR = MyrbBody.position;
                MyrbBody.position +=  Vector3.right * speed * Time.fixedDeltaTime;
                MyrbBody.MovePosition(posR);
                break;
        }
        
    }
    /// <summary>
    /// Materialも移動させる
    /// 
    /// offsetは、元々マテリアルのタイリングを移動させる方向を3に拡大させてるので、
    /// 物理的に進ませるのはVector3.back(要は"1")*speed(ここでは"２")*time~~~(両方やってるから無視)
    /// で、1*speed(2)=2 なので、offsetにも同じ値が来るように、3倍してしまってるのを3で割る(/3 = *0.33.…)
    /// 要はテクスチャのｙスケール伸びた分だけ反比例してoffsetかける
    ///  </summary>
    void ScrollUV()
    {
        if(!Reverse){
            var material                = this.mymaterial;
            Vector2 offset              = material.mainTextureOffset;
            offset                     += Vector2.up * speed * Time.deltaTime / material.mainTextureScale.y;
            material.mainTextureOffset  = offset;
        }

        //変更点:逆向きに動くなら^の向きも逆にする処理
        if(Reverse){
            var material                = this.mymaterial;

            Vector2 TextureScale        = this.mymaterial.mainTextureScale;
            TextureScale                = new Vector2(1,-3f);
            material.mainTextureScale   = TextureScale;

            Vector2 offset              = material.mainTextureOffset;
            offset                     += Vector2.down * speed * Time.deltaTime / material.mainTextureScale.y;
            material.mainTextureOffset  = offset;
        }
    }
}

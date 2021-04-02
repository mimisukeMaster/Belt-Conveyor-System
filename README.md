# Belt-Conveyor-System


### > Made with Unity-version:2019.4.20f(LTS)


## unityでのinspectorの操作について
**[注意1]Scene上で複製する際、TransformのRotateを変えても、上に置かれたものの動く方向は変わりません。**
- 例えばBeltconveyorを4つに複製して、四角状に配置した場合(Picture1)
  - そのまま特に設定せずにプレイすると、上の青いCubeは異なるBeltConveyorに乗り移っても同じ方向に移動を続けてしまいます。(Gif1)
#### Picture1
![このように四角状に配置します](https://user-images.githubusercontent.com/81568941/113006553-72ba0f80-91b0-11eb-9bab-64afa3b0034e.png)
#### Gif1
![このように変な挙動をします_2gif](https://user-images.githubusercontent.com/81568941/113430621-73071480-9415-11eb-8d58-84dec7fbe78e.gif)
- これは上側のBeltConveyorが、乗る物体の動く方向をスクリプトで決めていて、**ワールド座標のZ軸**に対してどの向き(前後左右(`forward`,`back`,`left`,`right`))に動かすかを指定しているため、角度をずらすとワールド座標上のZ軸の方向とBeltConveyorの見た目上の前方向がずれる(ローカル座標上のZ軸の向きが変わる)ことにより生じるものです。
- → 対処法として、初めに、それぞれのHierarchy内の`BeltConveyor`の中に含まれる`Onbelt`オブジェクト(上の物体が載るところのオブジェクト)を選択します。(**Picture2**)
次にinspectorにてアタッチされている`BeltConveyorSimple`コンポーネントの`Chosen Vec`パラメータを選択し、表示された向きの選択肢を、***そのBeltConveyorの上にある物体が運ばれる方向の、ワールド座標Z軸から見た向き***に合わせた選択肢にします。(Picture3)
#### Picture2
![このOnBeltをせんたくします](https://user-images.githubusercontent.com/81568941/113010478-d42fad80-91b3-11eb-9f96-f9f8ce844ab3.png)
#### Picture3
![ここをいじってｘ軸に対してどうかを指定します](https://user-images.githubusercontent.com/81568941/113010508-dabe2500-91b3-11eb-8bcf-e7106b7deba2.png)

今回のような四角状に配置した場合、真上から全体を見るとPicture4のようになります。
右上にある軸を見て分かる通り、Z軸は写真上の上側です。よって`1`の`BeltConveyor`の`ChosenVec`をZ軸に対して正の向きに動かしたいので`forward`を選択します。
同様にして`2`の`BeltConveyor`の`ChosenVec`はZ軸に対して右側に動かしたいので`right`を選択し、`3`のはZ軸に対して負の向きに動かしたいので`back`を、`4`のはZ軸に対して左側に動かしたいので`left`を選択します。(Picture5)
- 以上の設定を行うとGif2のような正しい挙動になります。
#### Picture4
![この場合の上から見た向き](https://user-images.githubusercontent.com/81568941/113303649-429f7780-933c-11eb-8dab-819d2f317655.png)
#### Picture5
![1sen](https://user-images.githubusercontent.com/81568941/113421069-65e22980-9405-11eb-83e8-b539b73c74bd.png)
#### Gif2
![Vec指定後](https://user-images.githubusercontent.com/81568941/113430024-6504c400-9414-11eb-9267-7c20d8b4f03e.gif)




**[注意2]Scene内での下側のBeltConveyorのObject(GameObject名:UnderBelt)は_「^(緑の矢印)」マークが逆になるため、ConveyorSimple.csのReverseパラメータにチェックを入れてください**
- 入れなくてもエラーが起こる訳ではありませんが、見た目が変になります。施す前と後で比較します:
#### Before (Picture6)in PlayMode,Gif3
- [ ] Reverse
![Reverse入れないとインプレイ](https://user-images.githubusercontent.com/81568941/113423861-2ff37400-940a-11eb-811d-a59d4b86e451.png)
![Reverseなしgif](https://user-images.githubusercontent.com/81568941/113424070-7e087780-940a-11eb-9279-888bfdb3f36e.gif)

#### After (Picture7)in PlayMode,Gif4
- [x] Reverse
![Reverseありだとインプレイ](https://user-images.githubusercontent.com/81568941/113423891-3da8f980-940a-11eb-8352-f915038adaec.png)
![Reverseありgif](https://user-images.githubusercontent.com/81568941/113424086-852f8580-940a-11eb-8bc5-7a90e063abd2.gif)



## 取り込み上の注意
ZIP形式でDLした後、**Unity**に取り込んだ際に多少のエラーが出てくる場合があるかもしれません。(**Picture8**)
正常通り再生できるのであれば問題いりませんが、万が一再生を阻止されエラーの修正を促されたり、明らかなバグ(画像情報がないなど)があれば、
*GitHub Desktop* を開いて`File-> Clone repository` を選択し、この*repository*を**Clone**して取り込んでください。
#### Picture8
![こんなエラーが発生することがあります](https://user-images.githubusercontent.com/81568941/113005972-e7407e80-91af-11eb-9eed-a690ae25b217.png)


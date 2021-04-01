# Belt-Conveyor-System


### > Made with Unity-version:2019.4.20f(LTS)


## unityでのinspectorの操作について
**[注意]Scene上で複製する際、TransformのRotateを変えても、上に置かれたものの動く方向は変わりません。**
- 例えばBeltconveyorを4つに複製して、四角状に配置した場合(Picture1)
  - そのまま特に設定せずにプレイすると、上の青いCubeは異なるBeltConveyorに乗り移っても同じ方向に移動を続けてしまいます。(Gif1)
#### Picture1
![このように四角状に配置します](https://user-images.githubusercontent.com/81568941/113006553-72ba0f80-91b0-11eb-9bab-64afa3b0034e.png)
#### Gif1
![このように変な挙動をしますよ](https://user-images.githubusercontent.com/81568941/113006997-caf11180-91b0-11eb-94f7-8009017274d4.gif)
- これは上の物体が、動く方向をスクリプトでワールド座標のZ軸に対してどの向き(前後左右(`forward`,`back`,`left`,`right`))に動かすかを決めているため、角度をずらすとワールド座標上のZ軸の方向とローカル座標上のZ軸の方向がずれることにより生じるものです。
- → 対処法として、初めに、それぞれのHierarchy内の`BeltConveyor`の中に含まれる`Onbelt`オブジェクト(上の物体が載るところのオブジェクト)を選択します。(**Picture2**)
次にinspectorにてアタッチされている`BeltConveyorSimple`コンポーネントの`Chosen Vec`パラメータを選択し、表示された向きの選択肢を、***そのBeltConveyorの上にある物体が運ばれるはずの、ワールド座標Z軸における向きの逆***に合わせた選択肢にします。(Picture3)
#### Picture2
![このOnBeltをせんたくします](https://user-images.githubusercontent.com/81568941/113010478-d42fad80-91b3-11eb-9f96-f9f8ce844ab3.png)
#### Picture3
![ここをいじってｘ軸に対してどうかを指定します](https://user-images.githubusercontent.com/81568941/113010508-dabe2500-91b3-11eb-8bcf-e7106b7deba2.png)

今回のような四角状に配置した場合、真上から全体を見るとPicture4のようになります。
右上にある軸を見て分かる通り、Z軸は写真上の上側です。よって`1`の`*BeltConveyor*`の`ChosenVec`をZ軸に対して正の向きに動かしたいので逆の`Back`を選択します。
同様にして`2`の`*BeltConveyor*`の`ChosenVec`はZ軸に対して右側に動かしたいので逆の`left`を選択し、`3`のはZ軸に対して負の向きに動かしたいので逆の`forward`を、`4`のはZ軸に対して左側に動かしたいので逆の`Right`を選択します。(Picture5)
#### Picture4
![この場合の上から見た向き](https://user-images.githubusercontent.com/81568941/113303649-429f7780-933c-11eb-8dab-819d2f317655.png)
#### Picture5
![こういう風に設定します](https://user-images.githubusercontent.com/81568941/113309162-d293f000-9341-11eb-9579-540713596a60.png)



## 取り込み上の注意
ZIP形式でDLした後、**Unity**に取り込んだ際に多少のエラーが出てくる場合があるかもしれません。(**Picture6**)
正常通り再生できるのであれば問題いりませんが、万が一再生を阻止されエラーの修正を促されたり、明らかなバグ(画像情報がないなど)があれば、
*GitHub Desktop* を開いて`File-> Clone repository` を選択し、この*repository*を**Clone**して取り込んでください。
#### Picture6
![こんなエラーが発生することがあります](https://user-images.githubusercontent.com/81568941/113005972-e7407e80-91af-11eb-9eed-a690ae25b217.png)


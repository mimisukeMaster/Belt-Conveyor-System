# Belt-Conveyor-System


### > Unity-version:2019.4.20f(LTS)


## unity上でのinspectorの操作
**TransformのRotateを変えても上に置かれたものの動く方向は変わりません**
 - 例えばBeltconveyorを4つに複製して、四角状に配置した場合
![このように四角状に配置します](https://user-images.githubusercontent.com/81568941/113006553-72ba0f80-91b0-11eb-9bab-64afa3b0034e.png)

そのまま特に設定せずにプレイすると、上の青いCubeは異なるBeltConveyorに乗り移っても同じ方向に移動を続けてしまいます。
![このように変な挙動をしますよ](https://user-images.githubusercontent.com/81568941/113006997-caf11180-91b0-11eb-94f7-8009017274d4.gif)
これは上の物体が動く方向を、スクリプトにてワールド座標のX軸に対してどの向き(前後左右,`forward`,`back`,`left`,`right`)に動かすかを決めているため、角度をずらすとワールド座標上のX軸の方向とローカル座標上のX軸の方向がずれてしまうためにおこるものです。


## 取り込み上の注意
ZIP形式でDLした後、**Unity**に取り込んだ際に多少のエラーが出てくる場合があるかもしれません。(**Picture1**)
正常通り再生できるのであれば問題いりませんが、万が一再生を阻止されエラーの修正を促されたり、明らかなバグ(画像情報がないなど)があれば、
*GitHub Desktop* を開いて`File-> Clone repository` を選択し、この*repository*を**Clone**して取り込んでください。
#### Picture1
![こんなエラーが発生することがあります](https://user-images.githubusercontent.com/81568941/113005972-e7407e80-91af-11eb-9eed-a690ae25b217.png)


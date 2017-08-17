# BubbleProject

这个项目是我大三临近大四实习的时候，学习完cocos2dx的时候想到的一个小游戏吧，
现在才开始准备做，~_~
不管这个游戏是否好玩，是否能挣钱，我都要做上一做，有些回忆一直在，做过了，就结束了吧

游戏很简单，就是一个竖版的类似跑酷的游戏吧

我把它命名为《泡泡》

阳光下的泡沫是彩色的 -- 邓紫棋，《泡沫》

游戏介绍：

1，一个泡沫在海低，一个生物呼出的空气就变成了泡沫，可是泡沫一碰就破，

2，泡沫由于浮力，然后就向上漂泊，慢慢的漂泊，途中会碰到一些小鱼等，一碰就破了，然后就死亡了，还会遇到其他的一些泡沫，增长自己的生命，

3，泡沫会慢慢的变小，通过吸收输出的泡沫来维持自己的形状，维持自己的生命，不让自己渐渐的消失掉，

4，泡沫向上漂浮，想要漂出海面，见到阳光，变成彩色的泡沫，然后结束自己的生命，虽然只有一瞬间，但是拥有了就满足了，

5，道具，不同道具可以有不同的作用，

	道具可以有保护壳，吃到道具就可以触发，出来一条鱼，然后把泡沫吃掉，放到肚子里，玩家控制这条鱼，向上游去，速度加快，多加一条命，鱼也需要吃泡沫来维持肚子中的泡沫的生命，

	还可以是另一个泡沫，通过消耗自己，来维持泡沫的生命，不用吃泡沫，也可以吃泡沫来维持两个泡沫的生命，多一个泡沫就多一个生命

6，玩家可以左右控制泡沫，还可以加速，但是加速的时候消耗泡沫的生命，（可以可以停止泡沫向上的移动，这个还没有想好，看游戏进度吧，可以加，但是要想好加成什么样子，加不好，被吐槽哦）

7，玩家手指点击屏幕时，出现方向盘，玩家可以转动方向盘来控制泡沫的移动方向，但是不能向后旋转方向盘，（此功能依据上面的功能来看是否实现）

8，本游戏类似于跑酷游戏，所以泡沫是不动的，背景，道具，鱼类是从上向下移动的，加速的时候是使其他物体加速向下移动



游戏实现：

按钮实现：

	方式一： 	玩家通过点击屏幕的两侧按钮来实现泡泡的左右移动，
				加速按钮先不考虑，以后有需求可以再加
				
生命实现：
	
	方式一：	生命没秒都在减少一格，最大生命值是10，
				是用滑动条实现，背景是一张泡泡图片 -- 弃用
				使用image控件，ugui下的Image控件，添加一张图片之后，
				在Image Type 中选择Filled 类型，然后就可以控制图片的滑动显示了
				
奖励实现：

	方式一：	奖励的大小增加的生命值也是不一样的，
				奖励是随机出现的，
				奖励的大小也是随机的，
				最好是在一定的范围内，随机产生随机大小的泡泡，
				类似于一条线路

	方式二：	奖励是泡泡，增加生命值，
				在不同位置生成不同大小的气泡，
				气泡以不同的速度运动，玩家需要移动主角泡泡，来吃掉其他泡泡
				吃掉使用两个气泡合并的动画，就是类似于两个水滴合并的样子，
				然后在生命值的地方掉下一滴气泡，来补充生命。

工具：
	创建随机位置的泡泡，序列泡泡
	创建之后使用的是json文件

解析json文件：
	 解析json文件，用来读取关卡信息的，读取奖励泡泡等等的位置信息的
	 
	 
	 
	 
	 

	 
	 
	
	
创建道具：有时间限制的哦

	1. 无敌道具：不死的
	
	2. 吸引道具：在一定范围内的泡泡都会被吸引过来，被吃掉
	
	3. 变小道具：变小，生命也跟着变小
	
	4. 变大道具：变大，生命也跟着变大
	
	5. 加命道具：增加一条命，生命也是随着减少的，但是生命没有的时候，在重新显示，
					增加的一条命，在泡泡的外面增加一个泡泡，最开始生命显示的是外面泡泡的生命，
					外面泡泡每命的时候，显示主角泡泡的生命，
					外面泡泡跟主角泡泡一样，碰到germ也会减少生命值
					
	6. 减速道具：物体移动下落缓慢
	
	7. 加速道具：物体移动速度加快
	
	
	
	
	
	
	
优化游戏物体创建，现在一下创建这么多物体，特别卡，需要优化，
思路：  每秒遍历一次json数组，获取位置信息，跟记录的移动距离作比较，在两个屏幕范围内的创建出来，不在的话就不创建
		创建出来之后，从数组中删除
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
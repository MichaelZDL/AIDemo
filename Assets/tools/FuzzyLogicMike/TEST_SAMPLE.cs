/*-----------------------------------------------------------------------------

 * 名称：FuzzyLogicMike（main()） 测试程序
 * 作者：zhdelong@foxmail.com
 * 日期：2016.5.4

-----------------------------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using FuzzyLogicMike;
using System.IO;
public class TEST_SAMPLE : MonoBehaviour {
	FuzzyModule Fire;
	FuzzyModule Flee;
	public bool log;
	double[,] expectationData;
	void Start()
	{
		Fire = CreatFuzzyModuleFire ();
		Flee = CreatFuzzyModuleFlee ();
		expectationData = new double[101, 101];
		for (int health = 0; health < 100; health++)
			for (int killOdds = 0; killOdds < 10; killOdds++)
				BehaviorTreeLog (killOdds,health);
		writeToTXT ("BehaviorTree");
		expectationData = new double[101, 101];
		for (int health = 0; health < 100; health++)
			for (int killOdds = 0; killOdds < 10; killOdds++)
				MakeDisicionLog (killOdds,health);
		writeToTXT ("MakeDisicionTree");
	}
	FuzzyModule CreatFuzzyModuleFire () {
		/*-----------------------------------------------------------------------------*/
		FuzzyModule Rocket_Weapon = new FuzzyModule();
		/*-----------------------------------------------------------------------------
        Step1(a) 设计“目标的距离”的模糊语言变量：{近，中等，远} 及其隶属函数图
        -----------------------------------------------------------------------------*/
		FuzzyVariable Distance_FLV = Rocket_Weapon.CreateFLV("Distance");
		FzSet DstClose_FzSet = Distance_FLV.AddLeftShoulderSet("LeftShSetOfDist", 0, 1, 7);
		FzSet DstMedium_FzSet = Distance_FLV.AddTriangularSet("TriSetOfDist", 1, 7, 9);
		FzSet DstFar_FzSet = Distance_FLV.AddRightShoulderSet("RightShSetOfDist", 7, 9, 12);
		/*-----------------------------------------------------------------------------
        Step1(b) 设计“武器的弹药量”的模糊语言变量：{（弹药量）低，合适，超载}及其隶属函数图
        -----------------------------------------------------------------------------*/
		FuzzyVariable Health_FLV = Rocket_Weapon.CreateFLV("Health");
		FzSet BulletLow_FzSet = Health_FLV.AddLeftShoulderSet("LeftShSetOfBul", 0, 5, 20);
		FzSet BulletMedium_FzSet = Health_FLV.AddTriangularSet("TriSetOfBul", 5, 50, 80);
		FzSet BulletOver_FzSet = Health_FLV.AddRightShoulderSet("RightShSetOfBul", 50, 80, 100);
		/*-----------------------------------------------------------------------------
        Step1(c) 设计“期望值”的模糊语言变量：{不期望，期望，非常期望}及其隶属函数图
        -----------------------------------------------------------------------------*/
		FuzzyVariable DesirableValue_FLV = Rocket_Weapon.CreateFLV("DesirableValue");
		FzSet Undesirable_FzSet = DesirableValue_FLV.AddLeftShoulderSet("LeftShSetOfDsr", 0, 25, 50);
		FzSet Desirable_FzSet = DesirableValue_FLV.AddTriangularSet("TriSetOfDsr", 25, 50, 75);
		FzSet VeryDesirable_FzSet = DesirableValue_FLV.AddRightShoulderSet("RightShSetOfDsr", 50, 75, 100);
		/*-----------------------------------------------------------------------------
        Step2: 设计规则集，根据“目标的距离”和“武器的弹药量”的各三个模糊语言变量，
               可得出9种情况下的规则：
               如规则1：如果目标距离远与弹药量超载，则不期望，规则2：如果…(详见P325)
         * 行后注释为step3计算出隶属度之后，再进行规则计算的结果预测
        -----------------------------------------------------------------------------*/
		Rocket_Weapon.AddRule(new FzAND(DstFar_FzSet, BulletOver_FzSet), VeryDesirable_FzSet);//该条规则在模糊联想矩阵对应的值为0.0000，下同
		Rocket_Weapon.AddRule(new FzAND(DstFar_FzSet, BulletMedium_FzSet), Undesirable_FzSet);//0.3333
		Rocket_Weapon.AddRule(new FzAND(DstFar_FzSet, BulletLow_FzSet), Undesirable_FzSet);//0.2000
		Rocket_Weapon.AddRule(new FzAND(DstMedium_FzSet, BulletOver_FzSet), VeryDesirable_FzSet);//0.0000
		Rocket_Weapon.AddRule(new FzAND(DstMedium_FzSet, BulletMedium_FzSet), Desirable_FzSet);//0.6667
		Rocket_Weapon.AddRule(new FzAND(DstMedium_FzSet, BulletLow_FzSet), Undesirable_FzSet);//0.2000
		Rocket_Weapon.AddRule(new FzAND(DstClose_FzSet, BulletOver_FzSet), VeryDesirable_FzSet);//0.0000
		Rocket_Weapon.AddRule(new FzAND(DstClose_FzSet, BulletMedium_FzSet), VeryDesirable_FzSet);//0.0000
		Rocket_Weapon.AddRule(new FzAND(DstClose_FzSet, BulletLow_FzSet), Desirable_FzSet);//0.0000
		/*-----------------------------------------------------------------------------
        案例：要求在一堆武器中选取合适的武器，则首先为每种武器添加模糊逻辑模块
     
		/*-----------------------------------------------------------------------------
        Step3: 假设当前条件为目标距离：200像素远，弹药量：8枚。
               接下来我们对火箭发射器进行基于模糊逻辑的“选取期望值”计算。
        
         * 行后注释为结果预测
        -----------------------------------------------------------------------------*/
		//计算每个模糊语言变量的各段隶属函数（FuzzySet）在特定值下的DOM，并存入对于的FuzzySet类中
		/*-----------------------------------------------------------------------------
       /* Step4: 根据Step3.3得到的置信度模糊形，有三种方法进行“去模糊化”：
               最大值均值法(MOM)，中心法，最大值平均（MaxAv）。
               选取一种方法，最终得到火箭发射器在当前条件通过模糊逻辑计算后的期望值。
        
        结果预测: 结果应该是Undesirable_FzSet = 0.3333, Desirable_FzSet = 0.2, VeryDesirable_FzSet = 0.6667
                  中心法去模糊化，抽样点为{10.20.30....100},则期望值计算公式：
                （10*0.333333+20*0.333333+30*0.533333+40*0.533333+50*0.2+60*0.6+70*0.866667+80*0.666667+90*0.666667+100*0.666667）/
                 (0.333333+0.333333+0.533333+0.533333+0.2+0.6+0.866667+0.666667+0.666667+0.666667)=334.00008/5.4=61.8518
        -----------------------------------------------------------------------------*/
		return Rocket_Weapon;
	}
	FuzzyModule CreatFuzzyModuleFlee () {
		/*-----------------------------------------------------------------------------*/
		FuzzyModule Rocket_Weapon = new FuzzyModule();
		/*-----------------------------------------------------------------------------
        Step1(a) 设计“目标的距离”的模糊语言变量：{近，中等，远} 及其隶属函数图
        -----------------------------------------------------------------------------*/
		FuzzyVariable Distance_FLV = Rocket_Weapon.CreateFLV("Distance");
		FzSet DstClose_FzSet = Distance_FLV.AddLeftShoulderSet("LeftShSetOfDist", 0, 1, 7);
		FzSet DstMedium_FzSet = Distance_FLV.AddTriangularSet("TriSetOfDist", 1, 7, 9);
		FzSet DstFar_FzSet = Distance_FLV.AddRightShoulderSet("RightShSetOfDist", 7,9, 12);
		/*-----------------------------------------------------------------------------
        Step1(b) 设计“武器的弹药量”的模糊语言变量：{（弹药量）低，合适，超载}及其隶属函数图
        -----------------------------------------------------------------------------*/
		FuzzyVariable Health_FLV = Rocket_Weapon.CreateFLV("Health");
		FzSet BulletLow_FzSet = Health_FLV.AddLeftShoulderSet("LeftShSetOfBul", 0, 5, 20);
		FzSet BulletMedium_FzSet = Health_FLV.AddTriangularSet("TriSetOfBul", 5, 50, 80);
		FzSet BulletOver_FzSet = Health_FLV.AddRightShoulderSet("RightShSetOfBul", 50, 80, 100);
		/*-----------------------------------------------------------------------------
        Step1(c) 设计“期望值”的模糊语言变量：{不期望，期望，非常期望}及其隶属函数图
        -----------------------------------------------------------------------------*/
		FuzzyVariable DesirableValue_FLV = Rocket_Weapon.CreateFLV("DesirableValue");
		FzSet Undesirable_FzSet = DesirableValue_FLV.AddLeftShoulderSet("LeftShSetOfDsr", 0, 25, 50);
		FzSet Desirable_FzSet = DesirableValue_FLV.AddTriangularSet("TriSetOfDsr", 25, 50, 75);
		FzSet VeryDesirable_FzSet = DesirableValue_FLV.AddRightShoulderSet("RightShSetOfDsr", 50, 75, 100);
		/*-----------------------------------------------------------------------------
        Step2: 设计规则集，根据“目标的距离”和“武器的弹药量”的各三个模糊语言变量，
               可得出9种情况下的规则：
               如规则1：如果目标距离远与弹药量超载，则不期望，规则2：如果…(详见P325)
         * 行后注释为step3计算出隶属度之后，再进行规则计算的结果预测
        -----------------------------------------------------------------------------*/
		Rocket_Weapon.AddRule(new FzAND(DstFar_FzSet, BulletOver_FzSet), Undesirable_FzSet);//该条规则在模糊联想矩阵对应的值为0.0000，下同
		Rocket_Weapon.AddRule(new FzAND(DstFar_FzSet, BulletMedium_FzSet), Desirable_FzSet);//0.3333
		Rocket_Weapon.AddRule(new FzAND(DstFar_FzSet, BulletLow_FzSet), VeryDesirable_FzSet);//0.2000
		Rocket_Weapon.AddRule(new FzAND(DstMedium_FzSet, BulletOver_FzSet), Undesirable_FzSet);//0.0000
		Rocket_Weapon.AddRule(new FzAND(DstMedium_FzSet, BulletMedium_FzSet), Undesirable_FzSet);//0.6667
		Rocket_Weapon.AddRule(new FzAND(DstMedium_FzSet, BulletLow_FzSet), Desirable_FzSet);//0.2000
		Rocket_Weapon.AddRule(new FzAND(DstClose_FzSet, BulletOver_FzSet), Undesirable_FzSet);//0.0000
		Rocket_Weapon.AddRule(new FzAND(DstClose_FzSet, BulletMedium_FzSet), Undesirable_FzSet);//0.0000
		Rocket_Weapon.AddRule(new FzAND(DstClose_FzSet, BulletLow_FzSet), Desirable_FzSet);//0.0000
		/*-----------------------------------------------------------------------------
        案例：要求在一堆武器中选取合适的武器，则首先为每种武器添加模糊逻辑模块
     
		/*-----------------------------------------------------------------------------
        Step3: 假设当前条件为目标距离：200像素远，弹药量：8枚。
               接下来我们对火箭发射器进行基于模糊逻辑的“选取期望值”计算。
        
         * 行后注释为结果预测
        -----------------------------------------------------------------------------*/
		//计算每个模糊语言变量的各段隶属函数（FuzzySet）在特定值下的DOM，并存入对于的FuzzySet类中
		/*-----------------------------------------------------------------------------
        Step4: 根据Step3.3得到的置信度模糊形，有三种方法进行“去模糊化”：
               最大值均值法(MOM)，中心法，最大值平均（MaxAv）。
               选取一种方法，最终得到火箭发射器在当前条件通过模糊逻辑计算后的期望值。
        
        结果预测: 结果应该是Undesirable_FzSet = 0.3333, Desirable_FzSet = 0.2, VeryDesirable_FzSet = 0.6667
                  中心法去模糊化，抽样点为{10.20.30....100},则期望值计算公式：
                （10*0.333333+20*0.333333+30*0.533333+40*0.533333+50*0.2+60*0.6+70*0.866667+80*0.666667+90*0.666667+100*0.666667）/
                 (0.333333+0.333333+0.533333+0.533333+0.2+0.6+0.866667+0.666667+0.666667+0.666667)=334.00008/5.4=61.8518
        -----------------------------------------------------------------------------*/
		return Rocket_Weapon;
	}
	public void writeToTXT(string name) {
		//转置
		double[,] expectationDataT = new double[101, 101];
		for (int i = 0; i < 101; i++) {
			for (int j = 0; j < 101; j++) {
				expectationDataT[j, i] = expectationData[i, j];
			}
		}
		using (StreamWriter sw = new StreamWriter(name+"__expectationData_101X101.txt")) {
			for (int i = 0; i < 101; i++) {
				for (int j = 0; j < 101; j++) {
					sw.Write(expectationDataT[i, j]);
					sw.Write(' ');
				}
				sw.WriteLine();
			}
		}
	}
	public void MakeDisicion(float distance,float health)
	{
		Fire.Fuzzify ("Distance", distance);
		Fire.Fuzzify ("Health", health);
		Flee.Fuzzify ("Distance", distance);
		Flee.Fuzzify ("Health", health);
		//print(distance+" "+health);
		double FireValue = Fire.DeFuzzify("DesirableValue", FuzzyModule.DefuzzifyMethod.centroid);
		double FLeeValue = Flee.DeFuzzify("DesirableValue", FuzzyModule.DefuzzifyMethod.centroid);
		//print (gameObject+"  "+DValue);
		if (FireValue < FLeeValue) {
			GetComponent<actorTest> ().FleeToHome ();
			if(log)
			print ("Flee");
		} 
		else {
			GetComponent<actorTest> ().TestAttack ();
			if(log)
			print ("Fire");
		}

	}
	public void MakeDisicionLog(float distance,float health)
	{
		Fire.Fuzzify ("Distance", distance);
		Fire.Fuzzify ("Health", health);
		Flee.Fuzzify ("Distance", distance);
		Flee.Fuzzify ("Health", health);
		//print(distance+" "+health);
		double FireValue = Fire.DeFuzzify("DesirableValue", FuzzyModule.DefuzzifyMethod.centroid);
		double FLeeValue = Flee.DeFuzzify("DesirableValue", FuzzyModule.DefuzzifyMethod.centroid);
		if (FireValue > FLeeValue) {
			expectationData [(int)health,(int)(distance)] = 1;
		} else {
				expectationData [(int)health,(int)(distance)] = 0;
		}
	}
	public void BehaviorTreeLog(float distance,float health)
	{
		int disiction;
		if (health > 80)
			disiction = 1;
		else if (health > 20) {
			if (distance < 7)
				disiction = 1;
			else
				disiction = 0;
		}
		else
		{
			if (distance < 1)
				disiction = 1;
			else
				disiction = 0;
		}
		expectationData [(int)health, (int)(distance)] = disiction;
	}
	void Update()
	{
		print ("test");
        print("Mike test");
        MakeDisicion(GetComponent<actorTest>().KillOdds(), GetComponent<DataBind> ().selfLife);
	}
}
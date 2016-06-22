/*-----------------------------------------------------------------------------

 * 名称：FuzzyLogicMike（main()） 测试程序
 * 作者：zhdelong@foxmail.com
 * 日期：2016.5.4

-----------------------------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using FuzzyLogicMike;
public class TEST_SAMPLE : MonoBehaviour{

    private double[,] expectationData = new double[101, 101];
    void Start() {
        /*-----------------------------------------------------------------------------
        案例：MOBA游戏中，AI决策追击、加护盾、加血、撤退。
        通过模糊逻辑计算出当前条件：{对方真实伤害，自己血量}，求出受威胁层度
        -----------------------------------------------------------------------------*/
        FuzzyModule AttackDecision = new FuzzyModule();
        /*-----------------------------------------------------------------------------
        Step1(a) 设计“离出生点的距离”的模糊语言变量：{近，中，远} 及其隶属函数图
        -----------------------------------------------------------------------------*/
        FuzzyVariable Distance_FLVAttack = AttackDecision.CreateFLV("Distance");
        FzSet DstClose_FzSetAttack = Distance_FLVAttack.AddLeftShoulderSet("LeftShSetOfDist", 0, 5, 20);
        FzSet DstMedium_FzSetAttack = Distance_FLVAttack.AddTriangularSet("TriSetOfDist", 5, 20, 50);
        FzSet DstFar_FzSetAttack = Distance_FLVAttack.AddRightShoulderSet("RightShSetOfDist", 20, 50, 100);
        /*-----------------------------------------------------------------------------
        Step1(b) 设计“自身血量”的模糊语言变量：{（残血，适中，血多}及其隶属函数图
        -----------------------------------------------------------------------------*/
        FuzzyVariable HP_FLVAttack = AttackDecision.CreateFLV("HP");
        FzSet HPLow_FzSetAttack = HP_FLVAttack.AddLeftShoulderSet("LeftShSetOfHP", 0, 20, 50);
        FzSet HPMedium_FzSetAttack = HP_FLVAttack.AddTriangularSet("TriSetOfHP", 20, 50, 80);
        FzSet HPEnough_FzSetAttack = HP_FLVAttack.AddRightShoulderSet("RightShSetOfBul", 50, 80, 100);
        /*-----------------------------------------------------------------------------
        Step1(c) 设计“追击期望值”的模糊语言变量：{不期望追击，期望追击，非常期望追击}及其隶属函数图
        -----------------------------------------------------------------------------*/
        FuzzyVariable DesirableValue_FLVAttack = AttackDecision.CreateFLV("DesirableValue");
        FzSet Undesirable_FzSetAttack = DesirableValue_FLVAttack.AddLeftShoulderSet("LeftShSetOfDsr", 0, 25, 50);
        FzSet Desirable_FzSetAttack = DesirableValue_FLVAttack.AddTriangularSet("TriSetOfDsr", 25, 50, 75);
        FzSet VeryDesirable_FzSetAttack = DesirableValue_FLVAttack.AddRightShoulderSet("RightShSetOfDsr", 50, 75, 100);
        /*-----------------------------------------------------------------------------
        Step2: 设计规则集，根据“离出生点的距离”和“自身血量”的各三个模糊语言变量，
               可得出9种情况下的规则：
               如规则1：如果出生距离近与残血，则不期望追击，规则2：如果…(详见P325)
         * 行后注释为step3计算出隶属度之后，再进行规则计算的结果预测
        -----------------------------------------------------------------------------*/
        AttackDecision.AddRule(new FzAND(DstClose_FzSetAttack, HPLow_FzSetAttack), Desirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstClose_FzSetAttack, HPMedium_FzSetAttack), Undesirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstClose_FzSetAttack, HPEnough_FzSetAttack), Undesirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstMedium_FzSetAttack, HPLow_FzSetAttack), VeryDesirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstMedium_FzSetAttack, HPMedium_FzSetAttack), Desirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstMedium_FzSetAttack, HPEnough_FzSetAttack), Undesirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstFar_FzSetAttack, HPLow_FzSetAttack), VeryDesirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstFar_FzSetAttack, HPMedium_FzSetAttack), VeryDesirable_FzSetAttack);
        AttackDecision.AddRule(new FzAND(DstFar_FzSetAttack, HPEnough_FzSetAttack), Desirable_FzSetAttack);

        /*-----------------------------------------------------------------------------
        Step3: 模糊化。当前条件为 离出生点距离：35，血量：30
        -----------------------------------------------------------------------------*/
        for(int i = 0; i < 100; i++)
        {
            for(int j = 0; j < 100; j++)
            {   
                AttackDecision.Fuzzify("Distance", j);
                AttackDecision.Fuzzify("HP", i);
                expectationData[i,j] = AttackDecision.DeFuzzify("DesirableValue",
                    FuzzyModule.DefuzzifyMethod.centroid);
            }
        }
        writeToTXT();
    }
    public void writeToTXT() {
        //转置
        double[,] expectationDataT = new double[101, 101];
        for (int i = 0; i < 101; i++) {
            for (int j = 0; j < 101; j++) {
                expectationDataT[j, i] = expectationData[i, j];
            }
        }
            using (StreamWriter sw = new StreamWriter("TheatData_101X101.txt")) {
                for (int i = 0; i < 101; i++) {
                    for (int j = 0; j < 101; j++) {
                        sw.Write(expectationDataT[i, j]);
                        sw.Write(' ');
                    }
                    sw.WriteLine();
                }
            }
    }

}
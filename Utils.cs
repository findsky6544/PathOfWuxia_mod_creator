using Heluo;
using Heluo.Battle;
using Heluo.Data;
using Heluo.Flow;
using Heluo.Flow.Battle;
using Heluo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using UnityEngine;
using static RootMotion.FinalIK.IKSolver;
using DescriptionAttribute = Heluo.Flow.DescriptionAttribute;
using DisplayNameAttribute = Heluo.DisplayNameAttribute;
using MessageBox = System.Windows.Forms.MessageBox;

namespace 侠之道mod制作器
{
    internal class Utils
    {

        public static string[] getFieldsList(string fields)
        {
            List<string> array = new List<string>();
            try
            {
                fields = fields.Trim();
                while (fields.Length > 0)
                {
                    string field = null;


                    while (fields.StartsWith(","))
                    {
                        fields = fields.Substring(1, fields.Length - 1).Trim();
                    }

                    if (fields.StartsWith("\""))
                    {
                        field = fields.Substring(1, fields.IndexOf('\"', 1) - 1).Trim();
                        fields = fields.Substring(fields.IndexOf('\"', 1) + 1).Trim();
                    }
                    else if (fields.StartsWith("\\\""))
                    {
                        field = fields.Substring(2, fields.IndexOf('\"', 2) - 3).Trim();
                        fields = fields.Substring(fields.IndexOf('\"', 2) + 1).Trim();
                    }
                    else
                    {
                        int length = fields.Length;
                        if (fields.IndexOf(',') >= 0)
                        {
                            length = fields.IndexOf(',');
                        }
                        if (fields.IndexOf(':') >= 0)
                        {
                            length = Math.Min(length, fields.IndexOf(':'));
                        }

                        field = fields.Substring(0, length).Trim();
                        fields = fields.Substring(length).Trim();
                    }

                    while (field.StartsWith("{") || field.StartsWith("[") || field.StartsWith("(") || field.StartsWith(",") || field.StartsWith(":") || field.StartsWith("\"") || field.StartsWith("\\\""))
                    {
                        field = field.Substring(1, field.Length - 1).Trim();
                    }
                    while (field.EndsWith("}") || field.EndsWith("]") || field.EndsWith(")") || field.EndsWith("\"") || field.EndsWith("\\\""))
                    {
                        field = field.Substring(0, field.Length - 1).Trim();
                    }

                    if (field != null)
                    {
                        array.Add(field.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return array.ToArray();
        }

        public static string getBufferStr(string[] discriptionArray, BufferNode bufferNode)
        {
            string bufferStr = discriptionArray[discriptionArray.Length - 1] + ":";

            //赋予战斗属性
            if (bufferNode.GetType() == typeof(BufferPropertyAction))
            {
                BufferPropertyAction bufferPropertyAction = (BufferPropertyAction)bufferNode;

                BattleProperty battleProperty = bufferPropertyAction.Property;

                if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.Max_HP)
                {
                    bufferStr += EnumData.GetDisplayName(BattleProperty.HP);
                }
                else if (battleProperty == BattleProperty.MP || battleProperty == BattleProperty.Max_MP)
                {
                    bufferStr += EnumData.GetDisplayName(BattleProperty.MP);
                }
                else
                {
                    bufferStr += EnumData.GetDisplayName(bufferPropertyAction.Property);
                }

                string valueStr = bufferPropertyAction.Value.ToString();
                if (bufferPropertyAction.Method == Method.Clear)
                {
                    valueStr = "";
                }


                if (bufferPropertyAction.Method != Method.Multiply)
                {
                    bufferStr += " " + EnumData.GetDisplayName(bufferPropertyAction.Method) + " " + valueStr;
                }
                else
                {
                    bufferStr += " 增加 " + EnumData.GetDisplayName(bufferPropertyAction.Property) + " 的基础值的 " + bufferPropertyAction.Value + "%";
                }

            }
            //增益重数
            else if (bufferNode.GetType() == typeof(BufferOverlayAction))
            {
                BufferOverlayAction bufferOverlayAction = (BufferOverlayAction)bufferNode;

                string valueStr = bufferOverlayAction.Value.ToString();
                if (bufferOverlayAction.Method == Method.Clear)
                {
                    valueStr = "";
                }

                if (bufferOverlayAction.Method != Method.Multiply)
                {
                    bufferStr += EnumData.GetDisplayName(bufferOverlayAction.Method) + " " + valueStr;
                }
                else
                {
                    bufferStr += " 增加 " + bufferOverlayAction.Value + "%";
                }
            }
            //增益次数
            else if (bufferNode.GetType() == typeof(BufferTimesAction))
            {
                BufferTimesAction bufferTimesAction = (BufferTimesAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(bufferTimesAction.Method) + (bufferTimesAction.Method == Method.Clear ? "" : (" " + bufferTimesAction.Value));
            }
            //条件式范围增加Buff(持续性)
            else if (bufferNode.GetType() == typeof(AuraPromoteAction))
            {
                AuraPromoteAction auraPromoteAction = (AuraPromoteAction)bufferNode;
                bufferStr = "距离 " + auraPromoteAction.Distance + " 内的 " + EnumData.GetDisplayName(auraPromoteAction.UnitFaction)
                    + (auraPromoteAction.Gender == Gender.All ? "" : " " + EnumData.GetDisplayName(auraPromoteAction.Gender))
                    + " 添加 " + DataManager.getBuffersName(auraPromoteAction.BuffId) + "" + (auraPromoteAction.HasSelf ? " 包含自身" : " 不包含自身");
            }
            //条件式范围增加Buff(单次触发)
            else if (bufferNode.GetType() == typeof(SingleAuraPromoteAction))
            {
                SingleAuraPromoteAction singleAuraPromoteAction = (SingleAuraPromoteAction)bufferNode;
                bufferStr = "距离 " + singleAuraPromoteAction.Distance + " 内的 " + EnumData.GetDisplayName(singleAuraPromoteAction.UnitFaction)
                    + (singleAuraPromoteAction.Gender == Gender.All ? "" : " " + EnumData.GetDisplayName(singleAuraPromoteAction.Gender))
                    + " 添加 " + DataManager.getBuffersName(singleAuraPromoteAction.BuffId) + " " + (singleAuraPromoteAction.HasSelf ? "" : "不") + "包含自身";
            }
            //赋予解放状态
            else if (bufferNode.GetType() == typeof(BufferLiberatedStateAction))
            {
                BufferLiberatedStateAction bufferLiberatedStateAction = (BufferLiberatedStateAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(bufferLiberatedStateAction.Staus);
                if (bufferLiberatedStateAction.Staus >= BattleLiberatedState.Lock_HP_Percent && bufferLiberatedStateAction.Staus <= BattleLiberatedState.Lock_MP_Value)
                {
                    bufferStr += " " + bufferLiberatedStateAction.Value;
                }
            }
            //赋予限制状态
            else if (bufferNode.GetType() == typeof(BufferRestrictedStateAction))
            {
                BufferRestrictedStateAction bufferRestrictedStateAction = (BufferRestrictedStateAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(bufferRestrictedStateAction.State);
            }
            //转换阵营
            else if (bufferNode.GetType() == typeof(ChanageFaction))
            {
                ChanageFaction chanageFaction = (ChanageFaction)bufferNode;
                bufferStr += EnumData.GetDisplayName(chanageFaction.faction);
            }
            //增加buff
            else if (bufferNode.GetType().IsSubclassOf(typeof(AddBuffAction)))
            {
                AddBuffAction addBuffAction = (AddBuffAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(addBuffAction.Type) + " " + DataManager.getBuffersName(addBuffAction.BuffId) + " " + addBuffAction.Count + " 次";
            }
            //指定清除自身Buff
            else if (bufferNode.GetType() == typeof(AttacherClearBuffAction))
            {
                AttacherClearBuffAction attacherClearBuffAction = (AttacherClearBuffAction)bufferNode;
                bufferStr += DataManager.getBuffersName(attacherClearBuffAction.BuffId);
            }
            //随机清除自身Buff
            else if (bufferNode.GetType() == typeof(AttacherRandomClearBuffAction))
            {
                AttacherRandomClearBuffAction attacherRandomClearBuffAction = (AttacherRandomClearBuffAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(attacherRandomClearBuffAction.Oriented) + " " + attacherRandomClearBuffAction.Count + " 个";
            }
            //随机清除攻击者Buff
            else if (bufferNode.GetType() == typeof(AttackerRandomClearBuffAction))
            {
                AttackerRandomClearBuffAction attackerRandomClearBuffAction = (AttackerRandomClearBuffAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(attackerRandomClearBuffAction.Oriented) + " " + attackerRandomClearBuffAction.Count + " 个";
            }
            //随机清除防御者Buff
            else if (bufferNode.GetType() == typeof(DefenderRandomClearBuffAction))
            {
                DefenderRandomClearBuffAction defenderRandomClearBuffAction = (DefenderRandomClearBuffAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(defenderRandomClearBuffAction.Oriented) + " " + defenderRandomClearBuffAction.Count + " 个";
            }
            //随机增加buff或debuff
            else if (bufferNode.GetType() == typeof(RandomBuffAction))
            {
                RandomBuffAction randomBuffAction = (RandomBuffAction)bufferNode;
                bufferStr += DataManager.getBuffersName(randomBuffAction.Buffers) + " 中的 " + randomBuffAction.RandomTime + " 个,每个增加 " + randomBuffAction.MinAddTime + "-" + randomBuffAction.MaxAddTime + " 次," + (randomBuffAction.IsRepeat ? "" : "不") + "可重复";
            }
            //赋予正面状态(迭加类型)
            else if (bufferNode.GetType() == typeof(BufferPositiveStateAction))
            {
                BufferPositiveStateAction bufferPositiveStateAction = (BufferPositiveStateAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(bufferPositiveStateAction.state);
            }
            //赋予负面状态(迭加类型)
            else if (bufferNode.GetType() == typeof(BufferNegativeStateAction))
            {
                BufferNegativeStateAction bufferNegativeStateAction = (BufferNegativeStateAction)bufferNode;
                bufferStr += EnumData.GetDisplayName(bufferNegativeStateAction.state);
            }
            //激励部队
            else if (bufferNode.GetType() == typeof(EncourageAction))
            {
            }
            //指定ID增加Buff
            else if (bufferNode.GetType() == typeof(AddBuffWithUnitIdAction))
            {
                AddBuffWithUnitIdAction addBuffWithUnitIdAction = (AddBuffWithUnitIdAction)bufferNode;

                bufferStr += DataManager.getUnitsName(addBuffWithUnitIdAction.UnitID) + " 添加 " + DataManager.getBuffersName(addBuffWithUnitIdAction.BuffId);
            }
            //指定ID移除Buff
            else if (bufferNode.GetType() == typeof(RemoveBuffWithUnitIdAction))
            {
                RemoveBuffWithUnitIdAction removeBuffWithUnitIdAction = (RemoveBuffWithUnitIdAction)bufferNode;

                bufferStr += DataManager.getUnitsName(removeBuffWithUnitIdAction.UnitID) + " 移除 " + DataManager.getBuffersName(removeBuffWithUnitIdAction.BuffId);
            }
            //指定ID范围增加Buff
            else if (bufferNode.GetType() == typeof(AssignAuraPromoteAction))
            {
                AssignAuraPromoteAction assignAuraPromoteAction = (AssignAuraPromoteAction)bufferNode;
                bufferStr = "距离 " + DataManager.getUnitsName(assignAuraPromoteAction.UnitID) + " " + assignAuraPromoteAction.Distance + " 格内的 " + EnumData.GetDisplayName(assignAuraPromoteAction.UnitFaction)
                    + (assignAuraPromoteAction.Gender == Gender.All ? "" : " " + EnumData.GetDisplayName(assignAuraPromoteAction.Gender))
                    + " 添加 " + DataManager.getBuffersName(assignAuraPromoteAction.BuffId) + (assignAuraPromoteAction.HasSelf ? " 包含自身" : " 不包含自身");
            }
            //依攻击者属性加入Buff
            else if (bufferNode.GetType() == typeof(AttackerElementAddBuff))
            {
                AttackerElementAddBuff attackerElementAddBuff = (AttackerElementAddBuff)bufferNode;
                bufferStr += "无:" + DataManager.getBuffersName(attackerElementAddBuff.NoneId) + ";" +
                    "金:" + DataManager.getBuffersName(attackerElementAddBuff.MetalId) + ";" +
                    "木:" + DataManager.getBuffersName(attackerElementAddBuff.WoodId) + ";" +
                    "水:" + DataManager.getBuffersName(attackerElementAddBuff.WaterId) + ";" +
                    "火:" + DataManager.getBuffersName(attackerElementAddBuff.FireId) + ";" +
                    "土:" + DataManager.getBuffersName(attackerElementAddBuff.EarthId);
            }
            //依防御者属性加入Buff
            else if (bufferNode.GetType() == typeof(DefenderElementAddBuff))
            {
                DefenderElementAddBuff defenderElementAddBuff = (DefenderElementAddBuff)bufferNode;
                bufferStr += "无:" + DataManager.getBuffersName(defenderElementAddBuff.NoneId) + ";" +
                    "金:" + DataManager.getBuffersName(defenderElementAddBuff.MetalId) + ";" +
                    "木:" + DataManager.getBuffersName(defenderElementAddBuff.WoodId) + ";" +
                    "水:" + DataManager.getBuffersName(defenderElementAddBuff.WaterId) + ";" +
                    "火:" + DataManager.getBuffersName(defenderElementAddBuff.FireId) + ";" +
                    "土:" + DataManager.getBuffersName(defenderElementAddBuff.EarthId) + "";
            }
            //指定清除攻击者Buff
            else if (bufferNode.GetType() == typeof(AttackerClearBuffAction))
            {
                AttackerClearBuffAction attackerClearBuffAction = (AttackerClearBuffAction)bufferNode;
                bufferStr += DataManager.getBuffersName(attackerClearBuffAction.BuffId);
            }
            //指定清除防御者Buff
            else if (bufferNode.GetType() == typeof(DefenderClearBuffAction))
            {
                DefenderClearBuffAction defenderClearBuffAction = (DefenderClearBuffAction)bufferNode;
                bufferStr += DataManager.getBuffersName(defenderClearBuffAction.BuffId);
            }
            //debug
            else if (bufferNode.GetType() == typeof(DebugBufferAction))
            {
                DebugBufferAction debugBufferAction = (DebugBufferAction)bufferNode;
                bufferStr += debugBufferAction.message;
            }
            //条件判断
            else if (bufferNode.GetType().IsSubclassOf(typeof(BufferCondition)))
            {
                //判断移动
                if (bufferNode.GetType() == typeof(BufferMoveCondition))
                {
                    BufferMoveCondition bufferMoveCondition = (BufferMoveCondition)bufferNode;
                    bufferStr += bufferMoveCondition.IsMoved ? "是" : "否";
                }
                //判断攻击者武器类型
                else if (bufferNode.GetType() == typeof(BufferAttackerWeaponTypeCondition))
                {
                    BufferAttackerWeaponTypeCondition bufferAttackerWeaponTypeCondition = (BufferAttackerWeaponTypeCondition)bufferNode;
                    bufferStr += (bufferAttackerWeaponTypeCondition.IsReverse ? "不" : "") + "是 " + EnumData.GetDisplayName(bufferAttackerWeaponTypeCondition.propsCategory);
                }
                //判断防御者武器类型
                else if (bufferNode.GetType() == typeof(BufferDefenderWeaponTypeCondition))
                {
                    BufferDefenderWeaponTypeCondition bufferDefenderWeaponTypeCondition = (BufferDefenderWeaponTypeCondition)bufferNode;
                    bufferStr += (bufferDefenderWeaponTypeCondition.IsReverse ? "不" : "") + "是 " + EnumData.GetDisplayName(bufferDefenderWeaponTypeCondition.propsCategory);
                }
                //判断武学武器类型
                else if (bufferNode.GetType() == typeof(BufferSkillTypeCondition))
                {
                    BufferSkillTypeCondition bufferSkillTypeCondition = (BufferSkillTypeCondition)bufferNode;
                    bufferStr += (bufferSkillTypeCondition.IsReverse ? "不" : "") + "是 " + EnumData.GetDisplayName(bufferSkillTypeCondition.propsCategory);
                }
                //判断机率
                else if (bufferNode.GetType() == typeof(ProbabilityCondition))
                {
                    ProbabilityCondition probabilityCondition = (ProbabilityCondition)bufferNode;
                    bufferStr += probabilityCondition.Value + "%";
                }
                //攻击者是否存在指定buff
                else if (bufferNode.GetType() == typeof(AttackerHasBufferCondition))
                {
                    AttackerHasBufferCondition attackerHasBufferCondition = (AttackerHasBufferCondition)bufferNode;
                    bufferStr += (attackerHasBufferCondition.IsExist ? "存在" : "不存在") + " " + DataManager.getBuffersName(attackerHasBufferCondition.buffid);
                }
                //防御者是否存在指定buff
                else if (bufferNode.GetType() == typeof(DefendeHasBufferCondition))
                {
                    DefendeHasBufferCondition defendeHasBufferCondition = (DefendeHasBufferCondition)bufferNode;
                    bufferStr += (defendeHasBufferCondition.IsExist ? "存在" : "不存在") + " " + DataManager.getBuffersName(defendeHasBufferCondition.buffid);
                }
                //判断增益者是否为攻击者
                else if (bufferNode.GetType() == typeof(BufferAttackCondition))
                {
                    bufferStr += "是";
                }
                //判断增益者是否为防御者
                else if (bufferNode.GetType() == typeof(BufferDefenderCondition))
                {
                    bufferStr += "是";
                }
                //判断是否致死
                else if (bufferNode.GetType() == typeof(IsLethalCondition))
                {
                    bufferStr += "是";
                }
                //判断防御者是否闪避
                else if (bufferNode.GetType() == typeof(DefenderIsDodgeCondition))
                {
                    DefenderIsDodgeCondition defenderIsDodgeCondition = (DefenderIsDodgeCondition)bufferNode;
                    bufferStr += defenderIsDodgeCondition.IsDodge ? "是" : "否";
                }
                //判断攻击者是否剋防御者
                else if (bufferNode.GetType() == typeof(IsAttackerSuperiorityDefenderCondition))
                {
                    IsAttackerSuperiorityDefenderCondition isAttackerSuperiorityDefenderCondition = (IsAttackerSuperiorityDefenderCondition)bufferNode;
                    bufferStr += isAttackerSuperiorityDefenderCondition.IsReverse ? "否" : "是";
                }
                //判断防御者是否剋攻击者
                else if (bufferNode.GetType() == typeof(IsDefenderSuperiorityAttackrCondition))
                {
                    IsDefenderSuperiorityAttackrCondition isDefenderSuperiorityAttackrCondition = (IsDefenderSuperiorityAttackrCondition)bufferNode;
                    bufferStr += isDefenderSuperiorityAttackrCondition.IsReverse ? "否" : "是";
                }
                //判断是否已经行动
                else if (bufferNode.GetType() == typeof(IsEndUnitCondition))
                {
                    IsEndUnitCondition isEndUnitCondition = (IsEndUnitCondition)bufferNode;
                    bufferStr += isEndUnitCondition.IsEnd ? "是" : "否";
                }
                //判断攻击者ID
                else if (bufferNode.GetType() == typeof(AttackerIDCondition))
                {
                    AttackerIDCondition attackerIDCondition = (AttackerIDCondition)bufferNode;
                    bufferStr += (attackerIDCondition.IsReverse ? "不是" : "是") + " " + DataManager.getUnitsName(attackerIDCondition.attackerId);
                }
                //判断防御者ID
                else if (bufferNode.GetType() == typeof(DefenderIDCondition))
                {
                    DefenderIDCondition defenderIDCondition = (DefenderIDCondition)bufferNode;
                    bufferStr += (defenderIDCondition.IsReverse ? "不是" : "是") + " " + DataManager.getUnitsName(defenderIDCondition.defenderId);
                }
                //判断攻击者阵营
                else if (bufferNode.GetType() == typeof(AttackerFactionCondition))
                {
                    AttackerFactionCondition attackerFactionCondition = (AttackerFactionCondition)bufferNode;
                    bufferStr += (attackerFactionCondition.IsReverse ? "不是" : "是") + " " + EnumData.GetDisplayName(attackerFactionCondition.faction);
                }
                //判断防御者阵营
                else if (bufferNode.GetType() == typeof(DefenderFactionCondition))
                {
                    DefenderFactionCondition defenderFactionCondition = (DefenderFactionCondition)bufferNode;
                    bufferStr += (defenderFactionCondition.IsReverse ? "不是" : "是") + " " + EnumData.GetDisplayName(defenderFactionCondition.faction);
                }
                //判断攻击者是否同阵营
                else if (bufferNode.GetType() == typeof(AttackerIsSameFactionCondition))
                {
                    AttackerIsSameFactionCondition defenderIsSameFactionCondition = (AttackerIsSameFactionCondition)bufferNode;
                    bufferStr += defenderIsSameFactionCondition.IsSameFaction ? "是" : "否";
                }
                //判断防御者是否同阵营
                else if (bufferNode.GetType() == typeof(DefenderIsSameFactionCondition))
                {
                    DefenderIsSameFactionCondition defenderIsSameFactionCondition = (DefenderIsSameFactionCondition)bufferNode;
                    bufferStr += defenderIsSameFactionCondition.IsSameFaction ? "是" : "否";
                }
                //判断持有者状态
                else if (bufferNode.GetType() == typeof(SelfBufferOrientedCondition))
                {
                    SelfBufferOrientedCondition selfBufferOrientedCondition = (SelfBufferOrientedCondition)bufferNode;
                    bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + "持有 " + EnumData.GetDisplayName(selfBufferOrientedCondition.oriented) + " buff";
                }
                //判断自身持有特定BUFF
                else if (bufferNode.GetType() == typeof(IsHasBufferCondition))
                {
                    IsHasBufferCondition isHasBufferCondition = (IsHasBufferCondition)bufferNode;
                    bufferStr += DataManager.getBuffersName(isHasBufferCondition.BufferIDs);
                }
                //攻击面向判断
                else if (bufferNode.GetType() == typeof(DamageDirectionCondition))
                {
                    DamageDirectionCondition damageDirectionCondition = (DamageDirectionCondition)bufferNode;
                    bufferStr += EnumData.GetDisplayName(damageDirectionCondition.dir);
                }
                //比较判断
                else if (bufferNode.GetType().IsSubclassOf(typeof(BufferCompareCondition)))
                {
                    BufferCompareCondition bufferCompareCondition = (BufferCompareCondition)bufferNode;
                    bufferStr = EnumData.GetDisplayName(bufferCompareCondition.op) + " " + bufferCompareCondition.value;

                    //自身战斗属性
                    if (bufferNode.GetType() == typeof(BufferPropertyCondition))
                    {
                        BufferPropertyCondition bufferPropertyCondition = (BufferPropertyCondition)bufferNode;


                        BattleProperty battleProperty = bufferPropertyCondition.Property;
                        string percentStr = "";

                        if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.MP)
                        {
                            percentStr = "%";
                        }

                        bufferStr = "判断" + discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(bufferPropertyCondition.Property) + " " + bufferStr + percentStr;
                    }
                    //自身气血
                    else if (bufferNode.GetType() == typeof(BufferSelfHPCondition))
                    {
                        BufferSelfHPCondition bufferSelfHPCondition = (BufferSelfHPCondition)bufferNode;
                        bufferStr = "判断" + discriptionArray[discriptionArray.Length - 1] + ":" + bufferStr;
                        if (!bufferSelfHPCondition.IsAbsolute)
                        {
                            bufferStr += "%";
                        }
                    }
                    //自身气血(值)
                    else if (bufferNode.GetType() == typeof(BufferSelfHPValueCondition))
                    {
                        bufferStr = "判断" + discriptionArray[discriptionArray.Length - 1] + ":" + bufferStr;
                    }
                    //敌方属性
                    else if (bufferNode.GetType() == typeof(BufferEnemyPropertyCondition))
                    {
                        BufferEnemyPropertyCondition bufferEnemyPropertyCondition = (BufferEnemyPropertyCondition)bufferNode;

                        BattleProperty battleProperty = bufferEnemyPropertyCondition.Property;
                        string percentStr = "";

                        if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.MP)
                        {
                            percentStr = "%";
                        }

                        bufferStr = "判断" + discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(bufferEnemyPropertyCondition.Property) + " " + bufferStr + percentStr;
                    }
                    //双方属性比较(HP&MP是绝对值)
                    else if (bufferNode.GetType() == typeof(BufferBothPropertyCondition))
                    {
                        BufferBothPropertyCondition bufferBothPropertyCondition = (BufferBothPropertyCondition)bufferNode;
                        bufferStr = "判断" + discriptionArray[discriptionArray.Length - 1] + ":" + "攻击者 " + EnumData.GetDisplayName(bufferBothPropertyCondition.Property) + " " + EnumData.GetDisplayName(bufferBothPropertyCondition.op)
                            + " 防御者 " + EnumData.GetDisplayName(bufferBothPropertyCondition.Property);
                    }
                    //判断自身正面状态
                    else if (bufferNode.GetType() == typeof(SelfPositiveStateCondition))
                    {
                        SelfPositiveStateCondition selfPositiveStateCondition = (SelfPositiveStateCondition)bufferNode;
                        bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(selfPositiveStateCondition.prop) + " " + bufferStr + " 重";
                    }
                    //判断自身负面状态
                    else if (bufferNode.GetType() == typeof(SelfNegativeStateCondition))
                    {
                        SelfNegativeStateCondition selfNegativeStateCondition = (SelfNegativeStateCondition)bufferNode;
                        bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(selfNegativeStateCondition.prop) + " " + bufferStr + " 重";
                    }
                    //判断攻击者正面状态
                    else if (bufferNode.GetType() == typeof(AttackerPositiveStateCondition))
                    {
                        AttackerPositiveStateCondition attackerPositiveStateCondition = (AttackerPositiveStateCondition)bufferNode;
                        bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(attackerPositiveStateCondition.prop) + " " + bufferStr + " 重";
                    }
                    //判断攻击者负面状态
                    else if (bufferNode.GetType() == typeof(AttackerNegativeStateCondition))
                    {
                        AttackerNegativeStateCondition attackerNegativeStateCondition = (AttackerNegativeStateCondition)bufferNode;
                        bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(attackerNegativeStateCondition.prop) + " " + bufferStr + " 重";
                    }
                    //判断防御者正面状态
                    else if (bufferNode.GetType() == typeof(DefenderPositiveStateCondition))
                    {
                        DefenderPositiveStateCondition defenderPositiveStateCondition = (DefenderPositiveStateCondition)bufferNode;
                        bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(defenderPositiveStateCondition.prop) + " " + bufferStr + " 重";
                    }
                    //判断防御者负面状态
                    else if (bufferNode.GetType() == typeof(DefenderNegativeStateCondition))
                    {
                        DefenderNegativeStateCondition defenderNegativeStateCondition = (DefenderNegativeStateCondition)bufferNode;
                        bufferStr = discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(defenderNegativeStateCondition.prop) + " " + bufferStr + " 重";
                    }
                    //自身养成属性
                    else if (bufferNode.GetType() == typeof(BufferNurturancePropertyCondition))
                    {
                        BufferNurturancePropertyCondition bufferNurturancePropertyCondition = (BufferNurturancePropertyCondition)bufferNode;
                        bufferStr = "判断" + discriptionArray[discriptionArray.Length - 1] + ":" + EnumData.GetDisplayName(bufferNurturancePropertyCondition.Property) + " " + bufferStr;
                    }
                    else
                    {
                        bufferStr += "---未完成---";
                    }
                }
                else
                {
                    bufferStr += "---未完成---";
                }
            }
            //增益效果
            else if (bufferNode.GetType().IsSubclassOf(typeof(BufferPromoteAction)))
            {
                BufferPromoteAction bufferPromoteAction = (BufferPromoteAction)bufferNode;

                BattleProperty battleProperty = bufferPromoteAction.Property;

                if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.Max_HP)
                {
                    bufferStr += EnumData.GetDisplayName(BattleProperty.HP);
                }
                else if (battleProperty == BattleProperty.MP || battleProperty == BattleProperty.Max_MP)
                {
                    bufferStr += EnumData.GetDisplayName(BattleProperty.MP);
                }
                else
                {
                    bufferStr += EnumData.GetDisplayName(bufferPromoteAction.Property);
                }


                string valueStr = bufferPromoteAction.Value.ToString();
                if (bufferPromoteAction.Method == Method.Clear)
                {
                    valueStr = "";
                }

                if (bufferPromoteAction.Method != Method.Multiply)
                {
                    bufferStr += " " + EnumData.GetDisplayName(bufferPromoteAction.Method)
                        + " " + valueStr
                         + " 上限 " + bufferPromoteAction.ValueLimit;
                }
                else
                {
                    bufferStr += " 增加 " + EnumData.GetDisplayName(bufferPromoteAction.Property) + " 的基础值的 " + bufferPromoteAction.Value + "%" + " 上限 "
                        + bufferPromoteAction.ValueLimit;
                }

                //移动距离提升属性
                if (bufferNode.GetType() == typeof(BufferMovePromoteAction))
                {
                    bufferStr = "每1移动距离 " + bufferStr;
                }
                //回合数提升属性
                else if (bufferNode.GetType() == typeof(BufferTurnPromoteAction))
                {
                    bufferStr = "每1回合 " + bufferStr;
                }
                //部队数提升属性
                else if (bufferNode.GetType() == typeof(BufferUnitPromoteAction))
                {
                    BufferUnitPromoteAction bufferUnitPromoteAction = (BufferUnitPromoteAction)bufferNode;
                    bufferStr = "距离 " + bufferUnitPromoteAction.Distance + " 格内每有1个 " + EnumData.GetDisplayName(bufferUnitPromoteAction.UnitFaction)
                        + (bufferUnitPromoteAction.Gender == Gender.All ? "" : " " + EnumData.GetDisplayName(bufferUnitPromoteAction.Gender))
                        + ", " + bufferStr;
                }
                //战斗行动数值数提升属性
                else if (bufferNode.GetType() == typeof(BufferNumberOfBattleActionsPromoteAction))
                {
                    BufferNumberOfBattleActionsPromoteAction bufferNumberOfBattleActionsPromoteAction = (BufferNumberOfBattleActionsPromoteAction)bufferNode;
                    bufferStr = "每1" + EnumData.GetDisplayName(bufferNumberOfBattleActionsPromoteAction.actions) + " " + bufferStr;
                }
                //正面状态重数提升属性
                else if (bufferNode.GetType() == typeof(BufferPositiveStatePromoteAction))
                {
                    BufferPositiveStatePromoteAction bufferPositiveStatePromoteAction = (BufferPositiveStatePromoteAction)bufferNode;
                    bufferStr = "每有1重 " + EnumData.GetDisplayName(bufferPositiveStatePromoteAction.Staus) + " " + bufferStr;
                }
                //负面状态重数提升属性
                else if (bufferNode.GetType() == typeof(BufferNegativeStatePromoteAction))
                {
                    BufferNegativeStatePromoteAction bufferNegativeStatePromoteAction = (BufferNegativeStatePromoteAction)bufferNode;
                    bufferStr = "每有1重 " + EnumData.GetDisplayName(bufferNegativeStatePromoteAction.Staus) + " " + bufferStr;
                }
                //攻击距离提升属性
                else if (bufferNode.GetType() == typeof(BufferDistancePromoteAction))
                {
                    BufferDistancePromoteAction bufferDistancePromoteAction = (BufferDistancePromoteAction)bufferNode;
                    bufferStr = "超过 " + bufferDistancePromoteAction.MinDis + " 格每1格" + " " + bufferStr;
                }
                //攻击者剩馀移动数提升属性
                else if (bufferNode.GetType() == typeof(NumberOfMovementsPromoteAction))
                {
                    bufferStr = "每1格剩余移动数 " + bufferStr;
                }
                //重数提升属性
                else if (bufferNode.GetType() == typeof(BufferOverlayPromoteAction))
                {
                    BufferOverlayPromoteAction bufferOverlayPromoteAction = (BufferOverlayPromoteAction)bufferNode;
                    bufferStr = (bufferOverlayPromoteAction.isTarget ? "目标" : "自身") + " 每有1重 " + DataManager.getBuffersName(bufferOverlayPromoteAction.bufferid) + " " + bufferStr;
                }
                else
                {
                    bufferStr += "---未完成---";
                }
            }
            //增益效果
            //HP/MP百分比修改属性
            else if (bufferNode.GetType().IsSubclassOf(typeof(PercentPromoteAction)))
            {
                PercentPromoteAction percentPromoteAction = (PercentPromoteAction)bufferNode;
                bufferStr = "相较 " + percentPromoteAction.Percent + "% 每 " + EnumData.GetDisplayName(percentPromoteAction.Op) + " " + +percentPromoteAction.PercentGap + "%, "
                    + EnumData.GetDisplayName(percentPromoteAction.Property) + " 提升 " + percentPromoteAction.Value;
            }
            else
            {
                if (bufferNode.GetType() != typeof(BufferEventNode) && !bufferNode.GetType().IsSubclassOf(typeof(BufferCompositeNode)))
                {
                    bufferStr += "---未完成---";
                }
                //bufferStr = bufferNode.ToString();
            }

            return bufferStr;
        }

        public static string getFlowNodeStr(BaseFlowGraph condition)
        {
            string str = "";

            if (condition != null)
            {
                DescriptionAttribute description = (DescriptionAttribute)condition.Output.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray = description.Value.Split('/');
                str = Utils.getFlowNodeStr(discriptionArray, (OutputNode)condition.Output, 0);
            }
            return str;
        }

        public static string getFlowNodeStr(string[] discriptionArray, OutputNode cinematicNode, int deep)
        {
            if (deep >= 10)
            {
                return "存在递归,结束";
            }
            string cinematicStr = "";
            if (discriptionArray.Length > 0)
            {
                cinematicStr = discriptionArray[discriptionArray.Length - 1] + ":";
            }

            //分歧
            if (cinematicNode.GetType() == typeof(BranchAction))
            {
                BranchAction branchAction = (BranchAction)cinematicNode;
                LogicalNode logicalNode = (LogicalNode)branchAction.conditionNode;

                cinematicStr += getFlowNodeStr(discriptionArray, logicalNode, deep + 1);
            }
            else if (cinematicNode.GetType() == typeof(LogicalNode))
            {
                LogicalNode logicalNode = (LogicalNode)cinematicNode;
                List<OutputNode<bool>> inputListNode = logicalNode.inputListNode;
                cinematicStr = "(";
                foreach (OutputNode<bool> inputNode in inputListNode)
                {
                    DescriptionAttribute description = (DescriptionAttribute)inputNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                    string[] discriptionArray1 = description.Value.Split('/');
                    cinematicStr += getFlowNodeStr(discriptionArray1, inputNode, deep + 1) + (logicalNode.op == LogicalOperator.And ? " 且 " : " 或 ");
                }
                if (cinematicStr.Length > 1)
                {
                    cinematicStr = cinematicStr.Substring(0, cinematicStr.Length - 2);
                }
                cinematicStr += ")";
            }
            else if (cinematicNode.GetType() == typeof(MultiLogicaAction))
            {
                MultiLogicaAction multiLogicaAction = (MultiLogicaAction)cinematicNode;
                List<OutputNode<bool>> listNode = multiLogicaAction.listNode;
                cinematicStr = "(";
                foreach (OutputNode<bool> inputNode in listNode)
                {
                    DescriptionAttribute description = (DescriptionAttribute)inputNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                    string[] discriptionArray1 = description.Value.Split('/');
                    cinematicStr += getFlowNodeStr(discriptionArray1, inputNode, deep + 1) + ",";
                }
                cinematicStr = cinematicStr.Substring(0, cinematicStr.Length - 1);
                cinematicStr += ")";
            }
            //复数动作
            else if (cinematicNode.GetType() == typeof(MultiAction))
            {
                MultiAction multiLogicaAction = (MultiAction)cinematicNode;
                List<ActionNode> listNode = multiLogicaAction.actionListNode;
                cinematicStr = "(";
                foreach (ActionNode inputNode in listNode)
                {
                    DescriptionAttribute description = (DescriptionAttribute)inputNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                    string[] discriptionArray1 = description.Value.Split('/');
                    cinematicStr += getFlowNodeStr(discriptionArray1, inputNode, deep + 1) + ",";
                }
                cinematicStr = cinematicStr.Substring(0, cinematicStr.Length - 1);
                cinematicStr += ")";
            }
            //玩家進入Collider
            else if (cinematicNode.GetType() == typeof(TriggerEnterNode))
            {
                TriggerEnterNode node = (TriggerEnterNode)cinematicNode;

                MultiAction inputNode = (MultiAction)node.actionNode;
                cinematicStr = "(";
                DescriptionAttribute description = (DescriptionAttribute)inputNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray1 = description.Value.Split('/');
                cinematicStr += getFlowNodeStr(discriptionArray1, inputNode, deep + 1);
                cinematicStr += ")";

                cinematicStr = "玩家进入collider: " + cinematicStr;
            }
            //点击
            else if (cinematicNode.GetType() == typeof(ClickNode))
            {
                ClickNode node = (ClickNode)cinematicNode;

                MultiAction inputNode = (MultiAction)node.actionNode;
                cinematicStr = "(";
                DescriptionAttribute description = (DescriptionAttribute)inputNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray1 = description.Value.Split('/');
                cinematicStr += getFlowNodeStr(discriptionArray1, inputNode, deep + 1);
                cinematicStr += ")";

                cinematicStr = "点击: " + cinematicStr;
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(Comparator)))
            {
                Comparator node1 = (Comparator)cinematicNode;
                string comparatorStr = " " + EnumData.GetDisplayName(node1.op) + " " + node1.value;

                //檢查完成任務數量
                if (cinematicNode.GetType() == typeof(CheckCompleteQuestCount))
                {
                    CheckCompleteQuestCount node = (CheckCompleteQuestCount)cinematicNode;
                    cinematicStr += "id包含 " + node.id + " 的传书数量";
                }
                //檢查玩家疲勞值
                else if (cinematicNode.GetType() == typeof(CheckEmotion))
                {
                }
                //檢查 NPC 好感階段
                else if (cinematicNode.GetType() == typeof(CheckFavorabilityRank))
                {
                    CheckFavorabilityRank node = (CheckFavorabilityRank)cinematicNode;
                    cinematicStr += DataManager.getNpcsName(node.npcId) + " 的好感阶段 ";
                }
                //檢查旗標
                else if (cinematicNode.GetType() == typeof(CheckFlag))
                {
                    CheckFlag node = (CheckFlag)cinematicNode;
                    cinematicStr += node.flagName;
                }
                //檢查 Player 十階武學與心法總數
                else if (cinematicNode.GetType() == typeof(CheckPlayerLevelMaxMantrasAndSkills))
                {
                    CheckPlayerLevelMaxMantrasAndSkills node = (CheckPlayerLevelMaxMantrasAndSkills)cinematicNode;
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckMantraLevel)))
                {
                    CheckMantraLevel node2 = (CheckMantraLevel)cinematicNode;
                    //檢查 Player 心法等級
                    if (cinematicNode.GetType() == typeof(CheckPlayerMantraLevel))
                    {
                        CheckPlayerMantraLevel node = (CheckPlayerMantraLevel)cinematicNode;
                        cinematicStr += DataManager.getMantraName(node2.mantra_Id) + " 的等级";
                    }
                    //檢查 NPC 心法等級
                    else if (cinematicNode.GetType() == typeof(CheckNpcMantraLevel))
                    {
                        CheckNpcMantraLevel node = (CheckNpcMantraLevel)cinematicNode;

                        cinematicStr += DataManager.getCharacterExteriorName(node.npcId) + " 的 " + DataManager.getMantraName(node2.mantra_Id) + " 的等级";
                    }
                }
                //檢查金錢
                else if (cinematicNode.GetType() == typeof(CheckMoney))
                {
                    CheckMoney node = (CheckMoney)cinematicNode;
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckProperty)))
                {
                    CheckProperty node2 = (CheckProperty)cinematicNode;
                    string propertyStr = EnumData.GetDisplayName(node2.property);
                    //檢查 Player 次級屬性
                    if (cinematicNode.GetType() == typeof(CheckPlayerProperty))
                    {
                        CheckPlayerProperty node = (CheckPlayerProperty)cinematicNode;
                        cinematicStr += propertyStr;
                    }
                    //檢查 NPC 次級屬性
                    else if (cinematicNode.GetType() == typeof(CheckNpcProperty))
                    {
                        CheckNpcProperty node = (CheckNpcProperty)cinematicNode;

                        cinematicStr += DataManager.getCharacterExteriorName(node.npcId) + " 的 " + propertyStr;
                    }
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckSkillLevel)))
                {
                    CheckSkillLevel node2 = (CheckSkillLevel)cinematicNode;
                    string SkillStr = DataManager.getSkillsName(node2.skillid);
                    //檢查 Player 技能等級
                    if (cinematicNode.GetType() == typeof(CheckPlayerSkillLevel))
                    {
                        CheckPlayerSkillLevel node = (CheckPlayerSkillLevel)cinematicNode;
                        cinematicStr += SkillStr + " 的等级 ";
                    }
                    //檢查 NPC 技能等級
                    else if (cinematicNode.GetType() == typeof(CheckNpcSkillLevel))
                    {
                        CheckNpcSkillLevel node = (CheckNpcSkillLevel)cinematicNode;

                        cinematicStr += DataManager.getCharacterExteriorName(node.npcId) + " 的 " + SkillStr + " 的等级 ";
                    }
                }
                //檢查 Player 技能類型總和
                else if (cinematicNode.GetType() == typeof(CheckPlayerTotalSkillLevel))
                {
                    CheckPlayerTotalSkillLevel node = (CheckPlayerTotalSkillLevel)cinematicNode;
                    cinematicStr = "检查 Player 的 " + EnumData.GetDisplayName(node.Type) + " 类型技能等级总和";
                }
                //檢查 Player 四藝總和
                else if (cinematicNode.GetType() == typeof(CheckPlayerTotalArtProperty))
                {
                    CheckPlayerTotalArtProperty node = (CheckPlayerTotalArtProperty)cinematicNode;
                }
                //檢查 Player 四軸總和
                else if (cinematicNode.GetType() == typeof(CheckPlayerTotalPersonalityProperty))
                {
                    CheckPlayerTotalPersonalityProperty node = (CheckPlayerTotalPersonalityProperty)cinematicNode;
                }
                //檢查 Player 四維總和
                else if (cinematicNode.GetType() == typeof(CheckPlayerTotalUpgradableProperty))
                {
                    CheckPlayerTotalUpgradableProperty node = (CheckPlayerTotalUpgradableProperty)cinematicNode;
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckUpgradableProperty)))
                {
                    CheckUpgradableProperty node2 = (CheckUpgradableProperty)cinematicNode;
                    string propertyStr = EnumData.GetDisplayName(node2.property);
                    //檢查 Player 升級屬性
                    if (cinematicNode.GetType() == typeof(CheckPlayerUpgradableProperty))
                    {
                        CheckPlayerUpgradableProperty node = (CheckPlayerUpgradableProperty)cinematicNode;
                        cinematicStr += propertyStr;
                    }
                    //檢查 NPC 升級屬性
                    else if (cinematicNode.GetType() == typeof(CheckNpcUpgradableProperty))
                    {
                        CheckNpcUpgradableProperty node = (CheckNpcUpgradableProperty)cinematicNode;

                        cinematicStr += DataManager.getNpcsName(node.npcId) + " 的 " + propertyStr;
                    }
                }
                //檢查 Player 背包
                else if (cinematicNode.GetType() == typeof(PlayerInventoryCondition))
                {
                    PlayerInventoryCondition node = (PlayerInventoryCondition)cinematicNode;

                    cinematicStr += DataManager.getPropssName(node.id) + " 的数量";
                }

                cinematicStr += comparatorStr;


                //檢查 NPC 是否是摯友
                if (cinematicNode.GetType() == typeof(CheckFavorabilityBestFriend))
                {
                    CheckFavorabilityBestFriend node = (CheckFavorabilityBestFriend)cinematicNode;
                    cinematicStr = DataManager.getNpcsName(node.npcId) + " 是挚友";
                }
                //檢查 NPC 是否可升階
                else if (cinematicNode.GetType() == typeof(CheckFavorabilityCacRankUp))
                {
                    CheckFavorabilityCacRankUp node = (CheckFavorabilityCacRankUp)cinematicNode;
                    cinematicStr = DataManager.getNpcsName(node.npcId) + " 可升阶";
                }
                //檢查 NPC 是否是戀人
                else if (cinematicNode.GetType() == typeof(CheckFavorabilityIsLover))
                {
                    CheckFavorabilityIsLover node = (CheckFavorabilityIsLover)cinematicNode;
                    cinematicStr = DataManager.getNpcsName(node.npcId) + " " + (node.IsReverse ? "不是" : "是") + "恋人";
                }
                //檢查目前輸入裝置
                else if (cinematicNode.GetType() == typeof(InputTypeCondition))
                {
                    InputTypeCondition node = (InputTypeCondition)cinematicNode;

                    cinematicStr = discriptionArray[discriptionArray.Length - 1] + ":" + "为 " + EnumData.GetDisplayName(node.type);
                }
            }
            //檢查當前回合
            else if (cinematicNode.GetType() == typeof(CheckCurrentRound))
            {
                CheckCurrentRound node = (CheckCurrentRound)cinematicNode;
                cinematicStr += "符合大于等于 " + DataManager.getRoundStr(node.round) + " 且小于等于 " + DataManager.getRoundStr(node.max) + " 的 " + node.multiple + " 倍数回合";
                if (!string.IsNullOrEmpty(node.other))
                {
                    cinematicStr += " 或是 " + node.other + " 回合";
                }
            }
            //檢查當前階段
            else if (cinematicNode.GetType() == typeof(CheckCurrentStage))
            {
                CheckCurrentStage node = (CheckCurrentStage)cinematicNode;
                cinematicStr += "符合 " + EnumData.GetDisplayName(node.stage);
            }
            //檢查當前時間
            else if (cinematicNode.GetType() == typeof(CheckCurrentTime))
            {
                CheckCurrentTime node = (CheckCurrentTime)cinematicNode;
                cinematicStr += "符合 " + EnumData.GetDisplayName(node.time);
            }
            //檢查當前天氣
            else if (cinematicNode.GetType() == typeof(CheckCurrentWeather))
            {
                CheckCurrentWeather node = (CheckCurrentWeather)cinematicNode;
                cinematicStr += "符合 " + EnumData.GetDisplayName(node.weather);
            }
            //檢查當前地圖編號
            else if (cinematicNode.GetType() == typeof(CheckMapId))
            {
                CheckMapId node = (CheckMapId)cinematicNode;

                cinematicStr += "符合 " + DataManager.getMapsName(node.mapId);
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckMantra)))
            {
                CheckMantra node1 = (CheckMantra)cinematicNode;
                string mantraStr = (node1.isContains ? "具备" : "不具备") + "心法 " + DataManager.getMantraName(node1.mantra_Id);
                //檢查 Player 心法
                if (cinematicNode.GetType() == typeof(CheckPlayerMantra))
                {
                    CheckPlayerMantra node = (CheckPlayerMantra)cinematicNode;
                    cinematicStr += mantraStr;
                }
                //檢查 NPC 心法
                else if (cinematicNode.GetType() == typeof(CheckNpcMantra))
                {
                    CheckNpcMantra node = (CheckNpcMantra)cinematicNode;

                    cinematicStr += DataManager.getCharacterExteriorName(node.npcId) + " " + mantraStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckSkill)))
            {
                CheckSkill node1 = (CheckSkill)cinematicNode;
                string SkillStr = (node1.isContains ? "具备" : "不具备") + "技能 " + DataManager.getSkillsName(node1.skill_Id);
                //檢查 Player 技能
                if (cinematicNode.GetType() == typeof(CheckPlayerSkill))
                {
                    CheckPlayerSkill node = (CheckPlayerSkill)cinematicNode;
                    cinematicStr += SkillStr;
                }
                //檢查 NPC 技能
                else if (cinematicNode.GetType() == typeof(CheckNpcSkill))
                {
                    CheckNpcSkill node = (CheckNpcSkill)cinematicNode;

                    cinematicStr += DataManager.getCharacterExteriorName(node.npcId) + " " + SkillStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(CheckTrait)))
            {
                CheckTrait node1 = (CheckTrait)cinematicNode;
                string traitStr = (node1.isContains ? "具备" : "不具备") + "特质 " + DataManager.getTraitName(node1.trait_Id);
                //檢查 Player 特质
                if (cinematicNode.GetType() == typeof(CheckPlayerTrait))
                {
                    CheckPlayerTrait node = (CheckPlayerTrait)cinematicNode;
                    cinematicStr += traitStr;
                }
                //檢查 NPC 特质
                else if (cinematicNode.GetType() == typeof(CheckNpcTrait))
                {
                    CheckNpcTrait node = (CheckNpcTrait)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + traitStr;
                }
            }
            //檢查當前養成待機編號
            else if (cinematicNode.GetType() == typeof(CheckNurturanceIdleId))
            {
                CheckNurturanceIdleId node = (CheckNurturanceIdleId)cinematicNode;

                cinematicStr += "为 " + node.id;
            }
            //檢查玩家性別
            else if (cinematicNode.GetType() == typeof(CheckPlayerGender))
            {
                CheckPlayerGender node = (CheckPlayerGender)cinematicNode;

                cinematicStr += "为 " + (node.isMale ? "男" : "女");
            }
            //檢查任務狀態
            else if (cinematicNode.GetType() == typeof(CheckQuestState))
            {
                CheckQuestState node = (CheckQuestState)cinematicNode;

                cinematicStr += DataManager.getQuestName(node.id) + " 的状态为 " + EnumData.GetDisplayName(node.state);
            }
            //檢查玩家武器種類
            else if (cinematicNode.GetType() == typeof(CheckWeapon))
            {
                CheckWeapon node = (CheckWeapon)cinematicNode;

                cinematicStr += "为 " + EnumData.GetDisplayName(node.PropsCategory);
            }
            //檢查隊友是否在隊
            else if (cinematicNode.GetType() == typeof(TeammateCondition))
            {
                TeammateCondition node = (TeammateCondition)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.id) + " " + (node.isContains ? "在" : "不在") + "队伍中";
            }
            //檢查几率
            else if (cinematicNode.GetType() == typeof(Probability))
            {
                Probability node = (Probability)cinematicNode;

                cinematicStr += node.value + "%";
            }
            //技能條件/心法等级
            else if (cinematicNode.GetType() == typeof(MantraLevel))
            {
                MantraLevel node = (MantraLevel)cinematicNode;

                cinematicStr += EnumData.GetDisplayName(node.op) + " " + node.Level;
            }
            //技能條件/招式等級
            else if (cinematicNode.GetType() == typeof(SkillLevel))
            {
                SkillLevel node = (SkillLevel)cinematicNode;

                cinematicStr += EnumData.GetDisplayName(node.op) + " " + node.Level;
            }
            //開啟整備介面
            else if (cinematicNode.GetType() == typeof(OpenUIAdjustmentAction))
            {
                OpenUIAdjustmentAction node = (OpenUIAdjustmentAction)cinematicNode;

                cinematicStr += DataManager.getAdjustmentName(node.AdjustmentId);
            }
            //開啟傳書介面
            else if (cinematicNode.GetType() == typeof(OpenUICommissionAction))
            {
                OpenUICommissionAction node = (OpenUICommissionAction)cinematicNode;

            }
            //開啟選課介面(直接接選課對話)
            else if (cinematicNode.GetType() == typeof(OpenUIElectiveAction))
            {
                OpenUIElectiveAction node = (OpenUIElectiveAction)cinematicNode;

            }
            //開啟評價介面
            else if (cinematicNode.GetType() == typeof(OpenUIEvaluationAction))
            {
                OpenUIEvaluationAction node = (OpenUIEvaluationAction)cinematicNode;


                cinematicStr += DataManager.getEvaluationName(node.id) + " 接续的movieId:" + DataManager.getCinematicName(node.movieid);
            }
            //開啟鍛造介面
            else if (cinematicNode.GetType() == typeof(OpenUIForgeAction))
            {
                OpenUIForgeAction node = (OpenUIForgeAction)cinematicNode;

            }
            //開啟養成介面
            else if (cinematicNode.GetType() == typeof(OpenUINurturanceAction))
            {
                OpenUINurturanceAction node = (OpenUINurturanceAction)cinematicNode;
            }
            //開啟閱讀介面
            else if (cinematicNode.GetType() == typeof(OpenUIReadingAction))
            {
                OpenUIReadingAction node = (OpenUIReadingAction)cinematicNode;
            }
            //開啟当铺介面
            else if (cinematicNode.GetType() == typeof(OpenUIPawnShopAction))
            {
                OpenUIPawnShopAction node = (OpenUIPawnShopAction)cinematicNode;
            }
            //開啟煉藥介面
            else if (cinematicNode.GetType() == typeof(OpenUIRefiningAction))
            {
                OpenUIRefiningAction node = (OpenUIRefiningAction)cinematicNode;
            }
            //開啟商店介面
            else if (cinematicNode.GetType() == typeof(OpenUIShopAction))
            {
                OpenUIShopAction node = (OpenUIShopAction)cinematicNode;
            }
            //一次定位多個 NPC (限定演出用)
            else if (cinematicNode.GetType() == typeof(GroupTransformAction))
            {
                GroupTransformAction node = (GroupTransformAction)cinematicNode;

                string infosStr = "";
                for (int i = 0; i < node.infos.Count; i++)
                {
                    GroupTransformAction.TransformInfo info = node.infos[i];
                    infosStr += DataManager.getNpcsName(info.id) + " 位置" + info.position + " 方向 " + info.rotation + ";";
                }

                cinematicStr += infosStr;
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ObjectTransformAction)))
            {
                ObjectTransformAction node1 = (ObjectTransformAction)cinematicNode;

                string transformStr = (node1.isMove ? node1.moveDuration + " 秒移动到 " + node1.position : "不移动") + ";" + (node1.isRotate ? node1.rotateDuration + " 秒旋转到 " + node1.rotation : "不旋转");

                //EventCube 移動 + 旋轉
                if (cinematicNode.GetType() == typeof(EventCubeTransformAction))
                {
                    EventCubeTransformAction node = (EventCubeTransformAction)cinematicNode;

                    cinematicStr += DataManager.getEventCubesName(node.evnetCubeId) + " " + transformStr;
                }
                //Camera 移動 + 旋轉
                else if (cinematicNode.GetType() == typeof(CameraTransformAction))
                {
                    CameraTransformAction node = (CameraTransformAction)cinematicNode;

                    cinematicStr += transformStr;
                }
                //NPC 移動 + 旋轉
                else if (cinematicNode.GetType() == typeof(NPCTransformAction))
                {
                    NPCTransformAction node = (NPCTransformAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + transformStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(CharacterArcMoveAction)))
            {
                CharacterArcMoveAction node1 = (CharacterArcMoveAction)cinematicNode;

                string transformStr = " 用 " + node1.duration + " 秒通过 " + node1.relayPoint + " 到达 " + node1.location;

                //Player弧線移動
                if (cinematicNode.GetType() == typeof(PlayerArcMoveAction))
                {
                    PlayerArcMoveAction node = (PlayerArcMoveAction)cinematicNode;

                    cinematicStr += " Player " + transformStr;
                }
                //Npc弧線移動
                else if (cinematicNode.GetType() == typeof(NpcArcMoveAction))
                {
                    NpcArcMoveAction node = (NpcArcMoveAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + transformStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ChangeAccessoryAction)))
            {
                ChangeAccessoryAction node1 = (ChangeAccessoryAction)cinematicNode;

                string transformStr = "装上配件 " + node1.accessory;

                //Player 隱藏武器並裝上配件
                if (cinematicNode.GetType() == typeof(PlayerChangeAccessoryAction))
                {
                    PlayerChangeAccessoryAction node = (PlayerChangeAccessoryAction)cinematicNode;

                    cinematicStr += transformStr;
                }
                //NPC 隱藏武器並裝上配件
                else if (cinematicNode.GetType() == typeof(NpcChangeAccessoryAction))
                {
                    NpcChangeAccessoryAction node = (NpcChangeAccessoryAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + transformStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ChangeWeaponPointAction)))
            {
                ChangeWeaponPointAction node1 = (ChangeWeaponPointAction)cinematicNode;

                string transformStr = node1.isHandheld ? "手持武器" : "佩戴武器";

                //Player 變更武器裝備狀態
                if (cinematicNode.GetType() == typeof(PlayerChangeWeaponPointAction))
                {
                    PlayerChangeWeaponPointAction node = (PlayerChangeWeaponPointAction)cinematicNode;

                    cinematicStr += transformStr;
                }
                //NPC 變更武器裝備狀態
                else if (cinematicNode.GetType() == typeof(NpcChangeWeaponPointAction))
                {
                    NpcChangeWeaponPointAction node = (NpcChangeWeaponPointAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + transformStr;
                }
            }
            //NPC 面向or背向 NPC	
            else if (cinematicNode.GetType() == typeof(NpcFaceToNPC))
            {
                NpcFaceToNPC node = (NpcFaceToNPC)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.turnid) + " " + EnumData.GetDisplayName(node.type) + " " + DataManager.getNpcsName(node.faceid) + "";
            }
            //NPC 面向or背向 Player	
            else if (cinematicNode.GetType() == typeof(NpcFaceToPlayer))
            {
                NpcFaceToPlayer node = (NpcFaceToPlayer)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcid) + " " + EnumData.GetDisplayName(node.type) + " Player";
            }
            //Player 面向or背向 NPC
            else if (cinematicNode.GetType() == typeof(PlayerFaceToNPC))
            {
                PlayerFaceToNPC node = (PlayerFaceToNPC)cinematicNode;

                cinematicStr += " Player " + EnumData.GetDisplayName(node.type) + " " + DataManager.getNpcsName(node.faceid);
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(NurturanceLocateAction)))
            {
                NurturanceLocateAction node1 = (NurturanceLocateAction)cinematicNode;
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                string transformStr = "位置 " + node1.position + " 方向 " + node1.rotation;

                //养成/Player 定位
                if (cinematicNode.GetType() == typeof(PlayerLocateAction))
                {
                    PlayerLocateAction node = (PlayerLocateAction)cinematicNode;

                    cinematicStr += transformStr;
                }
                //养成/NPC 定位
                else if (cinematicNode.GetType() == typeof(NpcLocateAction))
                {
                    NpcLocateAction node = (NpcLocateAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + transformStr;
                }
            }
            //Player 路徑移動(限演出使用)
            else if (cinematicNode.GetType() == typeof(PlayerPathMoveAction))
            {
                PlayerPathMoveAction node = (PlayerPathMoveAction)cinematicNode;

                cinematicStr += "用 " + node.duration + " 秒根据路径 " + DataManager.getMovePathDescription(node.pathId) + " 移动";
            }
            //NPC 路徑移動
            else if (cinematicNode.GetType() == typeof(NpcPathMoveAction))
            {
                NpcPathMoveAction node = (NpcPathMoveAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId) + " 用 " + node.duration + " 秒根据路径 " + DataManager.getMovePathDescription(node.pathId) + " 移动";
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ResetWeaponAction)))
            {
                ResetWeaponAction node1 = (ResetWeaponAction)cinematicNode;
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";


                //外觀/Player 重置武器
                if (cinematicNode.GetType() == typeof(PlayerResetWeaponAction))
                {
                    PlayerResetWeaponAction node = (PlayerResetWeaponAction)cinematicNode;

                }
                //外觀/NPC 重置武器
                else if (cinematicNode.GetType() == typeof(NpcResetWeaponAction))
                {
                    NpcResetWeaponAction node = (NpcResetWeaponAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId);
                }
            }
            //Player 簡單移動 + 轉向(限定演出用)
            else if (cinematicNode.GetType() == typeof(PlayerSimpleTransformAction))
            {
                PlayerSimpleTransformAction node = (PlayerSimpleTransformAction)cinematicNode;
                cinematicStr += (node.isMove ? "用 " + node.duration + " 秒移动至 " + node.position : "不移动") + ";然后 " + (node.isRotate ? "旋转至 " + node.rotation : "不旋转");
            }
            //NPC 簡單移動 + 轉向
            else if (cinematicNode.GetType() == typeof(NpcSimpleTransformAction))
            {
                NpcSimpleTransformAction node = (NpcSimpleTransformAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId) + " " + (node.isMove ? "用 " + node.duration + " 秒移动至 " + node.position : "不移动") + ";然后 " + (node.isRotate ? "旋转至 " + node.rotation : "不旋转");
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(CharaacterTransformAction)))
            {
                CharaacterTransformAction node1 = (CharaacterTransformAction)cinematicNode;


                //Player 瞬移 + 瞬轉(限定演出用)
                if (cinematicNode.GetType() == typeof(PlayerTransformAction))
                {
                    PlayerTransformAction node = (PlayerTransformAction)cinematicNode;

                    cinematicStr += (node.isMove ? "瞬移到 " + node.position : "不瞬移") + ";" + (node.isRotate ? "瞬转到 " + node.rotation : "不瞬转");
                }
                //NPC 瞬移 + 瞬轉
                else if (cinematicNode.GetType() == typeof(NpcTransformAction))
                {
                    NpcTransformAction node = (NpcTransformAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + (node.isMove ? "瞬移到 " + node.position : "不瞬移") + ";" + (node.isRotate ? "瞬转到 " + node.rotation : "不瞬转");
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(WeaponActiveAction)))
            {
                WeaponActiveAction node1 = (WeaponActiveAction)cinematicNode;
                string isActiveStr = node1.isActive ? "打开武器" : "关闭武器";

                //Player 武器開關
                if (cinematicNode.GetType() == typeof(PlayerWeaponActiveAction))
                {
                    PlayerWeaponActiveAction node = (PlayerWeaponActiveAction)cinematicNode;

                    cinematicStr += isActiveStr;
                }
                //NPC 武器開關
                else if (cinematicNode.GetType() == typeof(NpcWeaponActiveAction))
                {
                    NpcWeaponActiveAction node = (NpcWeaponActiveAction)cinematicNode;


                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + isActiveStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(PlayAnimationAction)))
            {
                PlayAnimationAction node1 = (PlayAnimationAction)cinematicNode;
                string animationStr = "";
                for (int i = 0; i < node1.animationClipInfos.Count; i++)
                {
                    AnimationCilpInfo aci = node1.animationClipInfos[i];

                    if (aci == null)
                    {
                        continue;
                    }

                    string playTypeStr = "";
                    switch (aci.PlayType)
                    {
                        case AnimationPlayType.Loop:
                            playTypeStr = "循环"; break;
                        case AnimationPlayType.Duration:
                            playTypeStr = aci.Value + " " + "秒"; break;
                        case AnimationPlayType.Times:
                            playTypeStr = aci.Value + " " + "次"; break;
                    }

                    animationStr += aci.ClipName + " " + playTypeStr + ",";
                }
                if (animationStr.Length > 0)
                {
                    animationStr = animationStr.Substring(0, animationStr.Length - 1);
                }

                //播放 Player 動畫
                if (cinematicNode.GetType() == typeof(PlayPlayerAnimationAction))
                {
                    PlayPlayerAnimationAction node = (PlayPlayerAnimationAction)cinematicNode;

                    cinematicStr += animationStr;
                }
                //播放 NPC 動畫
                else if (cinematicNode.GetType() == typeof(PlayNpcAnimationAction))
                {
                    PlayNpcAnimationAction node = (PlayNpcAnimationAction)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " " + "播放动画 " + animationStr;
                }
            }
            //NPC 設定/動畫
            else if (cinematicNode.GetType() == typeof(SetNpcAnimationAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcAnimationAction node = (SetNpcAnimationAction)cinematicNode;

                cinematicStr += DataManager.getCharacterBehaviourRemark(node.characterBehaviourId) + " 的动画变为 " + node.animation + " 对话时" + (node.isTurn ? "" : "不") + "转身";
            }
            //NPC 設定/行為互動類型(必須過loading)
            else if (cinematicNode.GetType() == typeof(SetNpcCurrentBehaviourClickType))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcCurrentBehaviourClickType node = (SetNpcCurrentBehaviourClickType)cinematicNode;

                cinematicStr += DataManager.getCharacterBehaviourRemark(node.behaviourId) + " 的行为互动类型变为 " + EnumData.GetDisplayName(node.ClickType);
            }
            //NPC 設定/行為互動名稱(必須過loading)
            else if (cinematicNode.GetType() == typeof(SetNpcCurrentBehaviourRemark))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcCurrentBehaviourRemark node = (SetNpcCurrentBehaviourRemark)cinematicNode;

                cinematicStr += DataManager.getCharacterBehaviourRemark(node.behaviourId) + " 的行为互动名称变为 " + node.remarks;
            }
            //NPC 設定/當前行為排程
            else if (cinematicNode.GetType() == typeof(SetNpcCurrentSchedulerIdAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcCurrentSchedulerIdAction node = (SetNpcCurrentSchedulerIdAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId) + " 的排程编号变为 " + DataManager.getConfigScheduleName(node.schedulerId);
            }
            //NPC 設定/當前行為预设位置与预设面向
            else if (cinematicNode.GetType() == typeof(SetNpcCurrentTransformAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcCurrentTransformAction node = (SetNpcCurrentTransformAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId) + " 位置 " + node.position + " 方向 " + node.rotation;
            }
            //NPC 設定/排程
            else if (cinematicNode.GetType() == typeof(SetNpcSchedulerIdAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcSchedulerIdAction node = (SetNpcSchedulerIdAction)cinematicNode;

                cinematicStr += DataManager.getCharacterBehaviourRemark(node.characterBehaviourId) + " 的排程变为 " + DataManager.getConfigScheduleName(node.schedulerId);
            }
            //NPC 設定/對話
            else if (cinematicNode.GetType() == typeof(SetNpcTalkIdAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcTalkIdAction node = (SetNpcTalkIdAction)cinematicNode;

                cinematicStr += DataManager.getCharacterBehaviourRemark(node.characterBehaviourId) + " 的对话变为 " + DataManager.getTalkMessage(node.talkId);
            }
            //NPC 設定/預設位置和預設面向
            else if (cinematicNode.GetType() == typeof(SetNpcTransformAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                SetNpcTransformAction node = (SetNpcTransformAction)cinematicNode;

                cinematicStr += DataManager.getCharacterBehaviourRemark(node.characterBehaviourId) + " 位置 " + node.position + " 方向 " + node.rotation;
            }
            //整理特定 Eventcube
            else if (cinematicNode.GetType() == typeof(SortOutDesignatedEventCubeAction))
            {
                SortOutDesignatedEventCubeAction node = (SortOutDesignatedEventCubeAction)cinematicNode;

                cinematicStr += DataManager.getEventCubesName(node.eventCubeId);
            }
            //整理特定 NPC
            else if (cinematicNode.GetType() == typeof(SortOutDesignatedNpcAction))
            {
                SortOutDesignatedNpcAction node = (SortOutDesignatedNpcAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId);
            }
            //整理所有 NPC + EventCube
            else if (cinematicNode.GetType() == typeof(SortOutNpcAndEventCubeAction))
            {
                SortOutNpcAndEventCubeAction node = (SortOutNpcAndEventCubeAction)cinematicNode;

            }
            //新增養成指令
            else if (cinematicNode.GetType() == typeof(NurturanceOpenOrder))
            {
                NurturanceOpenOrder node = (NurturanceOpenOrder)cinematicNode;

                cinematicStr += DataManager.getNurturancesName(node.orderid);
            }
            //刪除養成指令
            else if (cinematicNode.GetType() == typeof(NurturanceCloseOrder))
            {
                NurturanceCloseOrder node = (NurturanceCloseOrder)cinematicNode;

                cinematicStr += DataManager.getNurturancesName(node.orderid);
            }
            //開啟鍛造
            else if (cinematicNode.GetType() == typeof(LearnForgeAction))
            {
                LearnForgeAction node = (LearnForgeAction)cinematicNode;

                cinematicStr += DataManager.getForgesRemark(node.id);
            }
            //取得書籍
            else if (cinematicNode.GetType() == typeof(LearnReadingAction))
            {
                LearnReadingAction node = (LearnReadingAction)cinematicNode;

                cinematicStr += DataManager.getBooksName(node.id);
            }
            //學習煉藥
            else if (cinematicNode.GetType() == typeof(LearnRefiningAction))
            {
                LearnRefiningAction node = (LearnRefiningAction)cinematicNode;

                cinematicStr += DataManager.getAlchemysRemark(node.id);
            }
            //給獎勵
            else if (cinematicNode.GetType() == typeof(RewardAction))
            {
                RewardAction node = (RewardAction)cinematicNode;

                cinematicStr += DataManager.getRewardsStr(node.Rewardid, deep + 1);
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(Heluo.Flow.CalculatorAction)))
            {
                Heluo.Flow.CalculatorAction node1 = (Heluo.Flow.CalculatorAction)cinematicNode;
                string calculatorStr = EnumData.GetDisplayName(node1.method) + (node1.method == Method.Clear ? "" : (" " + node1.value));

                //疲勞度增減
                if (cinematicNode.GetType() == typeof(RewardEmotionAction))
                {
                    RewardEmotionAction node = (RewardEmotionAction)cinematicNode;

                    cinematicStr += calculatorStr;
                }
                //金錢
                else if (cinematicNode.GetType() == typeof(RewardMoney))
                {
                    RewardMoney node = (RewardMoney)cinematicNode;

                    cinematicStr += calculatorStr;
                }
                //道具
                else if (cinematicNode.GetType() == typeof(RewardProps))
                {
                    RewardProps node = (RewardProps)cinematicNode;

                    cinematicStr += DataManager.getPropssName(node.propsId) + " " + calculatorStr;
                }
                //社群經驗
                else if (cinematicNode.GetType() == typeof(SetFavorabilityEXP))
                {
                    SetFavorabilityEXP node = (SetFavorabilityEXP)cinematicNode;

                    cinematicStr += DataManager.getNpcsName(node.npcId) + " 好感度 " + calculatorStr;
                }
                //設定旗標
                else if (cinematicNode.GetType() == typeof(SetFlagAction))
                {
                    SetFlagAction node = (SetFlagAction)cinematicNode;

                    cinematicStr += node.flagName + " " + calculatorStr;
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(SetCharacterProperty)))
                {
                    SetCharacterProperty node2 = (SetCharacterProperty)cinematicNode;
                    string propertyStr = EnumData.GetDisplayName(node2.property) + " " + EnumData.GetDisplayName(node1.method) + (node1.method == Method.Clear ? "" : " " + node1.value);

                    //NPC/屬性
                    if (cinematicNode.GetType() == typeof(SetNpcPropertyAction))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetNpcPropertyAction node = (SetNpcPropertyAction)cinematicNode;

                        cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + propertyStr;
                    }
                    //玩家/屬性
                    else if (cinematicNode.GetType() == typeof(SetPlayerPropertyAction))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetPlayerPropertyAction node = (SetPlayerPropertyAction)cinematicNode;

                        cinematicStr += " " + propertyStr;
                    }
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(SetCharacterUpgradableProperty)))
                {
                    SetCharacterUpgradableProperty node2 = (SetCharacterUpgradableProperty)cinematicNode;
                    string propertyStr = EnumData.GetDisplayName(node2.property) + " " + EnumData.GetDisplayName(node1.method) + (node1.method == Method.Clear ? "" : " " + (float)node1.value / 100);

                    //NPC/升級屬性
                    if (cinematicNode.GetType() == typeof(SetNpcUpgradableProperty))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetNpcUpgradableProperty node = (SetNpcUpgradableProperty)cinematicNode;

                        cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + propertyStr;
                    }
                    //玩家/升級屬性
                    else if (cinematicNode.GetType() == typeof(SetPlayerUpgradableProperty))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetPlayerUpgradableProperty node = (SetPlayerUpgradableProperty)cinematicNode;

                        cinematicStr += " " + propertyStr;
                    }
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(SetMantraEXP)))
                {
                    SetMantraEXP node2 = (SetMantraEXP)cinematicNode;
                    string propertyStr = DataManager.getMantraName(node2.Id) + " 的经验 " + calculatorStr;

                    //NPC/心法經驗
                    if (cinematicNode.GetType() == typeof(SetNpcMantraEXP))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetNpcMantraEXP node = (SetNpcMantraEXP)cinematicNode;

                        cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + propertyStr;
                    }
                    //玩家/心法經驗
                    else if (cinematicNode.GetType() == typeof(SetPlayerMantraEXP))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetPlayerMantraEXP node = (SetPlayerMantraEXP)cinematicNode;

                        cinematicStr += " " + propertyStr;
                    }
                }
                else if (cinematicNode.GetType().IsSubclassOf(typeof(SetSkillEXP)))
                {
                    SetSkillEXP node2 = (SetSkillEXP)cinematicNode;
                    string propertyStr = DataManager.getSkillsName(node2.Id) + " 的经验 " + calculatorStr;

                    //NPC/技能經驗
                    if (cinematicNode.GetType() == typeof(SetNpcSkillEXP))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetNpcSkillEXP node = (SetNpcSkillEXP)cinematicNode;

                        cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + propertyStr;
                    }
                    //玩家/技能經驗
                    else if (cinematicNode.GetType() == typeof(SetPlayerSkillEXP))
                    {
                        cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";

                        SetPlayerSkillEXP node = (SetPlayerSkillEXP)cinematicNode;

                        cinematicStr += " " + propertyStr;
                    }
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(RewardRandom)))
            {
                RewardRandom node1 = (RewardRandom)cinematicNode;
                string calculatorStr = node1.RandomCount + " 次 每次增加 " + node1.RandomMin + "-" + node1.RandomMax + " " + (node1.IsRepeat ? "可" : "不") + "重复";

                //隨機金錢
                if (cinematicNode.GetType() == typeof(RewardReadomMoney))
                {
                    RewardReadomMoney node = (RewardReadomMoney)cinematicNode;

                    cinematicStr += calculatorStr;
                }
                //隨機道具
                else if (cinematicNode.GetType() == typeof(RewardReadomProps))
                {
                    RewardReadomProps node = (RewardReadomProps)cinematicNode;

                    cinematicStr += DataManager.getPropssName(node.propsId) + " " + calculatorStr;
                }
            }
            //盟友
            else if (cinematicNode.GetType() == typeof(RewardAllyMember))
            {
                RewardAllyMember node = (RewardAllyMember)cinematicNode;
                string methodStr = "";
                if (node.method > Method.Add)
                {
                    if (node.method - Method.Sub <= 1)
                    {
                        methodStr = "退出队伍";
                    }
                    else
                    {
                        methodStr = "修改方式错误";
                    }

                }
                else
                {
                    methodStr = "加入队伍";
                }

                cinematicStr += DataManager.getNpcsName(node.memberid) + " " + methodStr;
            }
            //队友
            else if (cinematicNode.GetType() == typeof(RewardTeamMember))
            {
                RewardTeamMember node = (RewardTeamMember)cinematicNode;
                string methodStr = "";
                if (node.method > Method.Add)
                {
                    if (node.method - Method.Sub <= 1)
                    {
                        methodStr = "退出队伍";
                    }
                    else
                    {
                        methodStr = "修改方式错误";
                    }

                }
                else
                {
                    methodStr = "加入队伍";
                }

                cinematicStr += DataManager.getNpcsName(node.memberid) + " " + methodStr + (node.isNeed ? " 必带" : "");
            }
            //設定戀人
            else if (cinematicNode.GetType() == typeof(SetFavorabilityLover))
            {
                SetFavorabilityLover node = (SetFavorabilityLover)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId);
            }
            //關閉戀人
            else if (cinematicNode.GetType() == typeof(SetFavorabilityNotLover))
            {
                SetFavorabilityNotLover node = (SetFavorabilityNotLover)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId);
            }
            //提升階段
            else if (cinematicNode.GetType() == typeof(SetFavorabilityRank))
            {
                SetFavorabilityRank node = (SetFavorabilityRank)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId);
            }
            //增加or移除社交對象
            else if (cinematicNode.GetType() == typeof(CommunityAction))
            {
                CommunityAction node = (CommunityAction)cinematicNode;

                cinematicStr += (node.isAdd ? "增加" : "移除") + " " + DataManager.getNpcsName(node.id);
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(SetMantra)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                SetMantra node1 = (SetMantra)cinematicNode;
                string methodStr = "";
                if (node1.method == Method.Assign || node1.method == Method.Add)
                {
                    methodStr = "增加";
                }
                else if (node1.method == Method.Sub || node1.method == Method.Clear)
                {
                    methodStr = "删除";
                }
                else
                {
                    methodStr = "错误操作";
                }

                string mantraStr = methodStr + " " + DataManager.getMantraName(node1.value);

                //NPC/習得心法
                if (cinematicNode.GetType() == typeof(SetNpcMantra))
                {

                    SetNpcMantra node = (SetNpcMantra)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + mantraStr;
                }
                //玩家/習得心法
                else if (cinematicNode.GetType() == typeof(SetPlayerMantra))
                {

                    SetPlayerMantra node = (SetPlayerMantra)cinematicNode;

                    cinematicStr += " " + mantraStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ReplaceMantra)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                ReplaceMantra node1 = (ReplaceMantra)cinematicNode;

                string mantraStr = DataManager.getMantraName(node1.OldID) + " 取代成 " + DataManager.getMantraName(node1.NewID);

                //NPC/取代心法
                if (cinematicNode.GetType() == typeof(ReplaceNPCMantra))
                {

                    ReplaceNPCMantra node = (ReplaceNPCMantra)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " 的 " + mantraStr;
                }
                //玩家/取代心法
                else if (cinematicNode.GetType() == typeof(ReplacePlayerMantra))
                {

                    ReplacePlayerMantra node = (ReplacePlayerMantra)cinematicNode;

                    cinematicStr += " " + mantraStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(SetSkill)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                SetSkill node1 = (SetSkill)cinematicNode;
                string methodStr = "";
                if (node1.method == Method.Assign || node1.method == Method.Add)
                {
                    methodStr = "增加";
                }
                else if (node1.method == Method.Sub || node1.method == Method.Clear)
                {
                    methodStr = "删除";
                }
                else
                {
                    methodStr = "错误操作";
                }

                string SkillStr = methodStr + " " + DataManager.getSkillsName(node1.value);

                //NPC/習得技能
                if (cinematicNode.GetType() == typeof(SetNpcSkill))
                {

                    SetNpcSkill node = (SetNpcSkill)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + SkillStr;
                }
                //玩家/習得技能
                else if (cinematicNode.GetType() == typeof(SetPlayerSkill))
                {

                    SetPlayerSkill node = (SetPlayerSkill)cinematicNode;

                    cinematicStr += " " + SkillStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ReplaceSkill)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                ReplaceSkill node1 = (ReplaceSkill)cinematicNode;

                string SkillStr = DataManager.getSkillsName(node1.OldID) + " 取代成 " + DataManager.getSkillsName(node1.NewID);

                //NPC/取代技能
                if (cinematicNode.GetType() == typeof(ReplaceNPCSkill))
                {

                    ReplaceNPCSkill node = (ReplaceNPCSkill)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + SkillStr;
                }
                //玩家/取代技能
                else if (cinematicNode.GetType() == typeof(ReplacePlayerSkill))
                {

                    ReplacePlayerSkill node = (ReplacePlayerSkill)cinematicNode;

                    cinematicStr += " " + SkillStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(SetSpecial)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                SetSpecial node1 = (SetSpecial)cinematicNode;
                string methodStr = "";
                if (node1.method == Method.Assign || node1.method == Method.Add)
                {
                    methodStr = "增加";
                }
                else if (node1.method == Method.Sub || node1.method == Method.Clear)
                {
                    methodStr = "删除";
                }
                else
                {
                    methodStr = "错误操作";
                }

                string specialStr = methodStr + " " + DataManager.getSkillsName(node1.value);

                //NPC/習得特技
                if (cinematicNode.GetType() == typeof(SetNpcSpecial))
                {

                    SetNpcSpecial node = (SetNpcSpecial)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + specialStr;
                }
                //玩家/習得特技
                else if (cinematicNode.GetType() == typeof(SetPlayerSpecial))
                {

                    SetPlayerSpecial node = (SetPlayerSpecial)cinematicNode;

                    cinematicStr += " " + specialStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ReplaceSpecial)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                ReplaceSpecial node1 = (ReplaceSpecial)cinematicNode;

                string specialStr = "特技取代成 " + DataManager.getSkillsName(node1.NewID);

                //NPC/取代特技
                if (cinematicNode.GetType() == typeof(ReplaceNPCSpecial))
                {

                    ReplaceNPCSpecial node = (ReplaceNPCSpecial)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + specialStr;
                }
                //玩家/取代特技
                else if (cinematicNode.GetType() == typeof(ReplacePlayerSpecial))
                {

                    ReplacePlayerSpecial node = (ReplacePlayerSpecial)cinematicNode;

                    cinematicStr += " " + specialStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(SetTrait)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                SetTrait node1 = (SetTrait)cinematicNode;
                string methodStr = "";
                if (node1.method == Method.Assign || node1.method == Method.Add)
                {
                    methodStr = "增加";
                }
                else if (node1.method == Method.Sub || node1.method == Method.Clear)
                {
                    methodStr = "删除";
                }
                else
                {
                    methodStr = "错误操作";
                }

                string traitStr = methodStr + " " + DataManager.getTraitName(node1.value);

                //NPC/習得特质
                if (cinematicNode.GetType() == typeof(SetNpcTrait))
                {

                    SetNpcTrait node = (SetNpcTrait)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + traitStr;
                }
                //玩家/習得特质
                else if (cinematicNode.GetType() == typeof(SetPlayerTrait))
                {

                    SetPlayerTrait node = (SetPlayerTrait)cinematicNode;

                    cinematicStr += " " + traitStr;
                }
            }
            else if (cinematicNode.GetType().IsSubclassOf(typeof(ReplaceTrait)))
            {
                cinematicStr = discriptionArray[2] + "\\" +discriptionArray[3] + ":";
                ReplaceTrait node1 = (ReplaceTrait)cinematicNode;

                string traitStr = DataManager.getTraitName(node1.OldID) + " 取代成 " + DataManager.getTraitName(node1.NewID);

                //NPC/取代特质
                if (cinematicNode.GetType() == typeof(ReplaceNPCTrait))
                {

                    ReplaceNPCTrait node = (ReplaceNPCTrait)cinematicNode;

                    cinematicStr += DataManager.getCharacterInfoRemark(node.npcId) + " " + traitStr;
                }
                //玩家/取代特质
                else if (cinematicNode.GetType() == typeof(ReplacePlayerTrait))
                {

                    ReplacePlayerTrait node = (ReplacePlayerTrait)cinematicNode;

                    cinematicStr += " " + traitStr;
                }
            }
            //NPC使用道具
            else if (cinematicNode.GetType() == typeof(SetNpcEquip))
            {

                SetNpcEquip node = (SetNpcEquip)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.NpcId) + " 使用 " + DataManager.getPropssName(node.propsId);
            }
            //养成/轉場
            else if (cinematicNode.GetType() == typeof(NurturanceTransitionsAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                NurturanceTransitionsAction node = (NurturanceTransitionsAction)cinematicNode;

                cinematicStr += node.isTransitionOut ? "转出" : "转入";
            }
            //選修課演出
            else if (cinematicNode.GetType() == typeof(ElectiveCinematicAction))
            {
                ElectiveCinematicAction node = (ElectiveCinematicAction)cinematicNode;

                cinematicStr += "";
            }
            //執行演出
            else if (cinematicNode.GetType() == typeof(RunCinematicAction))
            {
                RunCinematicAction node = (RunCinematicAction)cinematicNode;

                cinematicStr += DataManager.getCinematicName(node.cinematicId);
            }
            //養成演出
            else if (cinematicNode.GetType() == typeof(RunNurturanceAction))
            {
                RunNurturanceAction node = (RunNurturanceAction)cinematicNode;

                cinematicStr += DataManager.getCinematicName(node.cinematicId);
            }
            //進入結局
            else if (cinematicNode.GetType() == typeof(ProcessAction))
            {
                ProcessAction node = (ProcessAction)cinematicNode;

                string stayStr = " ";
                if (!string.IsNullOrEmpty(node.cinematicId))
                {
                    stayStr += (node.isMandatoryStay ? "" : "不") + "强制停留";
                }

                cinematicStr += node.endgameid + "; 音乐:" + node.music + "; 接续的cinematic编号:" + DataManager.getCinematicName(node.cinematicId) + "; 接续的movie编号:" + (node.movieId == "" ? "(空)" : node.movieId) + "; " + stayStr;
            }
            //鏡頭/鎖定 NPC
            else if (cinematicNode.GetType() == typeof(CameraLockNpcAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                CameraLockNpcAction node = (CameraLockNpcAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.npcId);
            }
            //鏡頭/鎖定 Player
            else if (cinematicNode.GetType() == typeof(CameraLockPlayerAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                CameraLockPlayerAction node = (CameraLockPlayerAction)cinematicNode;

                cinematicStr += "";
            }
            //鏡頭/解鎖 NPC 或  Player
            else if (cinematicNode.GetType() == typeof(CameraUnLockAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                CameraUnLockAction node = (CameraUnLockAction)cinematicNode;

                cinematicStr += "";
            }
            //鏡頭/開始震動
            else if (cinematicNode.GetType() == typeof(CameraShakeAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                CameraShakeAction node = (CameraShakeAction)cinematicNode;

                cinematicStr += "持续时间 " + node.duration + " 秒 强度 " + node.level + " 速度 " + node.vibrato + " " + (node.fadeOut ? "" : "不") + "淡出";
            }
            //鏡頭/停止震動
            else if (cinematicNode.GetType() == typeof(CameraUnShakeAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                CameraUnShakeAction node = (CameraUnShakeAction)cinematicNode;

                cinematicStr += "";
            }
            //切換場景、階段、日夜
            else if (cinematicNode.GetType() == typeof(LoadScenesAction))
            {
                LoadScenesAction node = (LoadScenesAction)cinematicNode;

                cinematicStr += "场景:" + DataManager.getMapsName(node.mapId) + " 玩家位置:" + node.position + "  玩家方向:" + node.rotation + " 载入类型:" + EnumData.GetDisplayName(node.loadType) + " " + (node.isNextTime ? "" : "不") + "切换日夜" + " 切换阶段:" + EnumData.GetDisplayName(node.timeStage) + " 音乐:" + node.orderMusic + " 音量:" + node.orderVolume;
            }
            //切換日夜(不會跳回合)	
            else if (cinematicNode.GetType() == typeof(ChangeDayAndNightAction))
            {
                ChangeDayAndNightAction node = (ChangeDayAndNightAction)cinematicNode;

                cinematicStr += "切换到 " + EnumData.GetDisplayName(node.timeType) + "(" + (node.IsReal ? "确实切换" : "仅环境") + ")";
            }
            //养成/切換階段、日夜	
            else if (cinematicNode.GetType() == typeof(NurturanceLoadScenesAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                NurturanceLoadScenesAction node = (NurturanceLoadScenesAction)cinematicNode;

                cinematicStr += "场景:" + DataManager.getMapsName(node.mapId) + " 玩家位置:" + node.position + "  玩家方向:" + node.rotation + " 载入类型:" + EnumData.GetDisplayName(node.loadType) + " " + (node.isNextTime ? "" : "不") + "切换日夜" + " 切换阶段:" + EnumData.GetDisplayName(node.timeStage);
            }
            //播放or停止音樂
            else if (cinematicNode.GetType() == typeof(MusicAction))
            {
                MusicAction node = (MusicAction)cinematicNode;

                cinematicStr += (node.IsStop ? "停止" : "播放 " + node.MusicName) + " " + (node.IsStop ? "淡出" : "切换") + "时间:" + (node.IsStop ? node.FadeOutTime : node.FadeTime) + " 秒" + (node.IsStop ? "" : " 音量大小:" + node.Volume + " " + (node.Continuous ? "" : "不") + "连续");
            }
            //播放音效
            else if (cinematicNode.GetType() == typeof(SoundAction))
            {
                SoundAction node = (SoundAction)cinematicNode;

                cinematicStr += node.SoundName + " 类型:" + EnumData.GetDisplayName(node.Type) + " 延迟:" + node.Delay + " 秒" + " 音量;" + node.Volume;
            }
            //轉換演出背景
            else if (cinematicNode.GetType() == typeof(NurturanceChangeBackground))
            {
                NurturanceChangeBackground node = (NurturanceChangeBackground)cinematicNode;

                cinematicStr += node.backid;
            }
            //养成/畫面淡出或淡入
            else if (cinematicNode.GetType() == typeof(NurturanceFadeAction))
            {
                cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";

                NurturanceFadeAction node = (NurturanceFadeAction)cinematicNode;

                cinematicStr += (node.isFadeIn ? "淡入" : "淡出") + " " + node.duration + " 秒";
            }
            //镜头/畫面模糊淡出或淡入
            else if (cinematicNode.GetType() == typeof(ScreenBlurAction))
            {
                //cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                ScreenBlurAction node = (ScreenBlurAction)cinematicNode;

                cinematicStr += (node.isFadeIn ? "淡入" : "淡出") + " " + node.duration + " 秒";
            }
            //镜头/畫面淡出或淡入
            else if (cinematicNode.GetType() == typeof(ScreenFadeAction))
            {
                //cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                ScreenFadeAction node = (ScreenFadeAction)cinematicNode;

                cinematicStr += (node.isFadeIn ? "淡入" : "淡出") + " " + node.duration + " 秒";
            }
            //镜头/畫面像素化淡出或淡入
            else if (cinematicNode.GetType() == typeof(ScreenPixlateAction))
            {
                //cinematicStr = discriptionArray[1] + "\\" +discriptionArray[2] + ":";
                ScreenPixlateAction node = (ScreenPixlateAction)cinematicNode;

                cinematicStr += (node.isFadeIn ? "淡入" : "淡出") + " " + node.duration + " 秒";
            }
            //變更姓名
            else if (cinematicNode.GetType() == typeof(ChangCharactereName))
            {
                ChangCharactereName node = (ChangCharactereName)cinematicNode;

                cinematicStr += DataManager.getCharacterExteriorName(node.id) + " 的姓名变更为 " + node.surName + node.name;
            }
            //變更角色描述
            else if (cinematicNode.GetType() == typeof(ChangeCharacterDescription))
            {
                ChangeCharacterDescription node = (ChangeCharacterDescription)cinematicNode;

                cinematicStr += DataManager.getCharacterExteriorName(node.id) + " 的描述变更为 " + node.description;
            }
            //變更角色身分
            else if (cinematicNode.GetType() == typeof(ChangeCharacterIdentity))
            {
                ChangeCharacterIdentity node = (ChangeCharacterIdentity)cinematicNode;

                cinematicStr += DataManager.getCharacterExteriorName(node.id) + " 的身份变更为 " + EnumData.GetDisplayName(node.Type);
            }
            //變更立繪與模型
            else if (cinematicNode.GetType() == typeof(ChangeCharacterProtraitAndModel))
            {
                ChangeCharacterProtraitAndModel node = (ChangeCharacterProtraitAndModel)cinematicNode;

                cinematicStr += DataManager.getCharacterExteriorName(node.id) + (node.isChangeProtrait ? " 立绘变更为 " + node.protrait : " 不变更立绘") + (node.isChangeModel ? " 模型变更为 " + node.model : " 不变更模型");
            }
            //修改NPC的CharacterInfo
            else if (cinematicNode.GetType() == typeof(SetNpcChatacterInfoAction))
            {
                SetNpcChatacterInfoAction node = (SetNpcChatacterInfoAction)cinematicNode;

                cinematicStr += DataManager.getNpcsName(node.NpcId) + " 角色资讯编号变更为 " + DataManager.getCharacterInfoRemark(node.InfoId);
            }
            //開始任務
            else if (cinematicNode.GetType() == typeof(StartQuestAction))
            {
                StartQuestAction node = (StartQuestAction)cinematicNode;

                cinematicStr += DataManager.getQuestName(node.id);
            }
            //接下一個任務 or 結束任務
            else if (cinematicNode.GetType() == typeof(NextOrEndQuestAction))
            {
                NextOrEndQuestAction node = (NextOrEndQuestAction)cinematicNode;

                cinematicStr += "";
            }
            //自動存檔
            else if (cinematicNode.GetType() == typeof(SaveAction))
            {
                SaveAction node = (SaveAction)cinematicNode;

                cinematicStr += "";
            }
            //給定評價
            else if (cinematicNode.GetType() == typeof(SetEvaluationAction))
            {
                SetEvaluationAction node = (SetEvaluationAction)cinematicNode;

                cinematicStr += DataManager.getEvaluationName(node.id) + " " + EnumData.GetDisplayName(node.evaluationPoint) + " 评价点 " + DataManager.getEvaluationPointInfo(node.id, node.evaluationPoint) + " 通过";
            }
            //進入戰鬥
            else if (cinematicNode.GetType() == typeof(BattleAction))
            {
                BattleAction node = (BattleAction)cinematicNode;

                cinematicStr += DataManager.getBattleAreaRemark(node.battleId);
            }
            //等待 N 秒
            else if (cinematicNode.GetType() == typeof(TimerAction))
            {
                TimerAction node = (TimerAction)cinematicNode;

                cinematicStr += "等待 " + node.delay + " 秒";
            }
            //開啟對話
            else if (cinematicNode.GetType() == typeof(TalkAction))
            {
                TalkAction node = (TalkAction)cinematicNode;

                cinematicStr += DataManager.getTalkMessage(node.talkId);
            }
            //获得成就
            else if (cinematicNode.GetType() == typeof(RewardAchievementAction))
            {
                RewardAchievementAction node = (RewardAchievementAction)cinematicNode;

                cinematicStr += DataManager.getAchievementName(node.Achievementid);
            }
            //技能條件/技能等级
            else if (cinematicNode.GetType() == typeof(SkillLevel))
            {
                SkillLevel node = (SkillLevel)cinematicNode;

                cinematicStr = "判断" + cinematicStr + " " + EnumData.GetDisplayName(node.op) + " " + node.Level;
            }
            //提升升級屬性(經驗)
            else if (cinematicNode.GetType().IsSubclassOf(typeof(AbilityCalculatorAction)))
            {
                AbilityCalculatorAction node = (AbilityCalculatorAction)cinematicNode;
                string calculatorStr = EnumData.GetDisplayName(node.method) + " " + node.value;

                if (cinematicNode.GetType() == typeof(CharacterUpgradablePropertyAbilityAction))
                {
                    CharacterUpgradablePropertyAbilityAction node1 = (CharacterUpgradablePropertyAbilityAction)cinematicNode;

                    cinematicStr += EnumData.GetDisplayName(node1.property) + " " + calculatorStr;
                }

            }
            else
            {
                cinematicStr += "---未完成---";
                //cinematicStr = cinematicNode.ToString();
            }



            return cinematicStr;
        }

        public static string getScheduleStr(string[] discriptionArray, BattleNode scheduleNode, int deep)
        {
            string scheduleStr = discriptionArray[discriptionArray.Length - 1] + ":";

            //事件
            if (scheduleNode.GetType() == typeof(BattleEventNode))
            {
                BattleEventNode node = (BattleEventNode)scheduleNode;

                scheduleStr = EnumData.GetDisplayName(node.eventType) + ":优先级 " + node.priority;
            }
            else if (scheduleNode.GetType() == typeof(StepByStepNode))
            {
                scheduleStr = "单步执行";
            }
            else if (scheduleNode.GetType() == typeof(SequenceNode))
            {
                scheduleStr = "执行到失败";
            }
            else if (scheduleNode.GetType() == typeof(BattleBranchNode))
            {
                BattleBranchNode node = (BattleBranchNode)scheduleNode;
                scheduleStr = "条件分歧: " + (node.isGlobal ? "全域旗标" : "战斗旗标") + " " + node.flagName + " " + EnumData.GetDisplayName(node.op) + " " + node.value + "(" + node.Desc + ")";
            }
            //一次性节点
            else if (scheduleNode.GetType() == typeof(ExecuteOnceNode))
            {
            }
            //条件判断
            else if (scheduleNode.GetType().IsSubclassOf(typeof(Heluo.Flow.Battle.ConditionNode)))
            {
                //比较判断
                if (scheduleNode.GetType().IsSubclassOf(typeof(CompareCondition)))
                {
                    CompareCondition bufferCompareCondition = (CompareCondition)scheduleNode;
                    string compareStr = EnumData.GetDisplayName(bufferCompareCondition.op) + " " + bufferCompareCondition.value;

                    //判断全域旗标
                    if (scheduleNode.GetType() == typeof(BattleFactorGlobalFlag))
                    {
                        BattleFactorGlobalFlag node = (BattleFactorGlobalFlag)scheduleNode;
                        scheduleStr = "判断" + scheduleStr + " " + node.flagName + " " + compareStr + (node.Desc.Length > 0 ? "(" + node.Desc + ")" : "");
                    }
                    //判断战斗旗标
                    else if (scheduleNode.GetType() == typeof(BattleFactorLocalFlag))
                    {
                        BattleFactorLocalFlag node = (BattleFactorLocalFlag)scheduleNode;
                        scheduleStr = "判断" + scheduleStr + " " + node.flagName + " " + compareStr + (node.Desc.Length > 0 ? "(" + node.Desc + ")" : "");
                    }
                    //判断战斗单位血量
                    else if (scheduleNode.GetType() == typeof(BattleFactorTargetHp))
                    {
                        BattleFactorTargetHp node = (BattleFactorTargetHp)scheduleNode;
                        scheduleStr = "判断" + scheduleStr + " " + DataManager.getUnitsName(node.unitId) + " 的HP " + compareStr + "%";
                    }
                    //判断回合数
                    else if (scheduleNode.GetType() == typeof(BattleFactorTurn))
                    {
                        BattleFactorTurn node = (BattleFactorTurn)scheduleNode;
                        scheduleStr = "判断" + scheduleStr + " " + compareStr;
                    }
                }
                //部队A是否攻击部队B
                else if (scheduleNode.GetType() == typeof(BattleAttackUnitCondition))
                {
                    BattleAttackUnitCondition node = (BattleAttackUnitCondition)scheduleNode;
                    scheduleStr = "判断 " + DataManager.getUnitsName(node.UnitAID) + " 是否攻击 " + DataManager.getUnitsName(node.UnitBID) + ":是";
                }
                //格子上有阵营
                else if (scheduleNode.GetType() == typeof(BattleFactorCellFaction))
                {
                    BattleFactorCellFaction node = (BattleFactorCellFaction)scheduleNode;
                    scheduleStr = "判断 " + node.cellIndex + " 格子上是否有 " + EnumData.GetDisplayName(node.faction) + ":是";
                }
                //判断格子上有unit
                else if (scheduleNode.GetType() == typeof(BattleFactorUnitCell))
                {
                    BattleFactorUnitCell node = (BattleFactorUnitCell)scheduleNode;
                    scheduleStr = "判断 " + node.cellIndex + " 格子上是否有 " + DataManager.getUnitsName(node.unitId) + ":是";
                }
                //目标到达格子
                else if (scheduleNode.GetType() == typeof(BattleFactorCharacterTile))
                {
                    BattleFactorCharacterTile node = (BattleFactorCharacterTile)scheduleNode;

                    scheduleStr = "判断目标 " + DataManager.getUnitsName(node.IDs) + " 是否到达格子 " + node.Tiles + ":是";
                }
                //判断当前阵营
                else if (scheduleNode.GetType() == typeof(BattleFactorCurrentFaction))
                {
                    BattleFactorCurrentFaction node = (BattleFactorCurrentFaction)scheduleNode;
                    scheduleStr += " " + (node.IsReverse ? "不是" : "是") + " " + EnumData.GetDisplayName(node.Faction);
                }
                //判断阵营全灭
                else if (scheduleNode.GetType() == typeof(BattleFactorFactionDefeat))
                {
                    BattleFactorFactionDefeat node = (BattleFactorFactionDefeat)scheduleNode;
                    scheduleStr = "判断 " + EnumData.GetDisplayName(node.Faction) + " 是否全灭:是";
                }
                //判断主角功体
                else if (scheduleNode.GetType() == typeof(BattleFactorPlayerElement))
                {
                    BattleFactorPlayerElement node = (BattleFactorPlayerElement)scheduleNode;
                    scheduleStr = "判断" + scheduleStr + " " + (node.exiat ? "不是" : "是") + " " + EnumData.GetDisplayName(node.element);
                }
                //判断目标死亡
                else if (scheduleNode.GetType() == typeof(BattleFactorTargetDestroy))
                {
                    BattleFactorTargetDestroy node = (BattleFactorTargetDestroy)scheduleNode;

                    scheduleStr = "判断 " + DataManager.getUnitsName(node.IDs) + " 是否死亡:是";
                }
                //战斗单位是否使用技能
                else if (scheduleNode.GetType() == typeof(BattleUseSkillCondition))
                {
                    BattleUseSkillCondition node = (BattleUseSkillCondition)scheduleNode;
                    scheduleStr = "判断 " + DataManager.getUnitsName(node.UnitID) + " 是否使用技能 " + node.SkillId + "(" + DataManager.getSkillsName(node.SkillId) + ") : 是";
                }
                //战斗单位是否使用特技
                else if (scheduleNode.GetType() == typeof(BattleUseSpecialSkillCondition))
                {
                    BattleUseSpecialSkillCondition node = (BattleUseSpecialSkillCondition)scheduleNode;
                    scheduleStr = "判断 " + DataManager.getUnitsName(node.UnitID) + " 是否使用特技:是";
                }
            }
            //单位加入增益
            else if (scheduleNode.GetType() == typeof(BattleResultAddBuff))
            {
                BattleResultAddBuff node = (BattleResultAddBuff)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitIds) + " 加入 " + (node.isbuffer ? "增益" : "减益") + " " + DataManager.getBuffersName(node.buffId) + " " + (node.showeffect ? "" : "不") + "显示特效";
            }
            //阵营加入增益
            else if (scheduleNode.GetType() == typeof(BattleResultAddFactionBuff))
            {
                BattleResultAddFactionBuff node = (BattleResultAddFactionBuff)scheduleNode;
                scheduleStr += EnumData.GetDisplayName(node.faction) + " 加入 " + (node.isbuffer ? "增益" : "减益") + " " + DataManager.getBuffersName(node.buffId) + " " + (node.showeffect ? "" : "不") + "显示特效";
            }
            //单位移除增益
            else if (scheduleNode.GetType() == typeof(BattleResultRmoveBuff))
            {
                BattleResultRmoveBuff node = (BattleResultRmoveBuff)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitIds) + " 移除增益 " + DataManager.getBuffersName(node.buffId);
            }
            //阵营移除增益
            else if (scheduleNode.GetType() == typeof(BattleResultRmoveFactionBuff))
            {
                BattleResultRmoveFactionBuff node = (BattleResultRmoveFactionBuff)scheduleNode;
                scheduleStr += EnumData.GetDisplayName(node.faction) + " 移除增益 " + DataManager.getBuffersName(node.buffId);
            }
            //转换AI类型
            else if (scheduleNode.GetType() == typeof(BattlChanageAItype))
            {
                BattlChanageAItype node = (BattlChanageAItype)scheduleNode;
                scheduleStr += DataManager.getUnitsName(node.unitId) + " AI类型转换为 " + node.aitype;
            }
            //转换阵营
            else if (scheduleNode.GetType() == typeof(BattlChanageFaction))
            {
                BattlChanageFaction node = (BattlChanageFaction)scheduleNode;
                scheduleStr += DataManager.getUnitsName(node.unitId) + " 转换为 " + EnumData.GetDisplayName(node.faction);
            }
            else if (scheduleNode.GetType().IsSubclassOf(typeof(Heluo.Flow.Battle.CalculatorAction)))
            {
                Heluo.Flow.Battle.CalculatorAction node1 = (Heluo.Flow.Battle.CalculatorAction)scheduleNode;
                string calculatorStr = "";

                if (node1.method == Method.Assign || node1.method == Method.Add || node1.method == Method.Sub)
                {
                    calculatorStr = EnumData.GetDisplayName(node1.method) + " " + node1.value + "%";
                }
                else if (node1.method == Method.Clear)
                {
                    calculatorStr = EnumData.GetDisplayName(node1.method);
                }
                else
                {
                    calculatorStr = "不变";
                }

                //调整血量（百分比）
                if (scheduleNode.GetType() == typeof(BattleResultUnitHP))
                {
                    BattleResultUnitHP node = (BattleResultUnitHP)scheduleNode;

                    scheduleStr += " " + DataManager.getUnitsName(node.unitid) + " 的HP " + calculatorStr;
                }
                //调整内力
                else if (scheduleNode.GetType() == typeof(BattleResultUnitMP))
                {
                    BattleResultUnitMP node = (BattleResultUnitMP)scheduleNode;

                    scheduleStr += " " + DataManager.getUnitsName(node.unitid) + " 的MP " + calculatorStr;
                }
            }
            //设定目标点
            else if (scheduleNode.GetType() == typeof(BattlSetTargetCell))
            {
                BattlSetTargetCell node = (BattlSetTargetCell)scheduleNode;
                scheduleStr += DataManager.getUnitsName(node.unitId) + " 的目标点为 " + node.cells;
            }
            //指定单位播放动画
            else if (scheduleNode.GetType() == typeof(BattleResultPlayAction))
            {
                BattleResultPlayAction node = (BattleResultPlayAction)scheduleNode;

                scheduleStr += " " + DataManager.getUnitsName(node.UnitID) + " 播放动画 " + node.AnimationID;
            }
            //加入部队
            else if (scheduleNode.GetType() == typeof(BattleResultAddUnit))
            {
                BattleResultAddUnit node = (BattleResultAddUnit)scheduleNode;
                scheduleStr += " 加入 " + EnumData.GetDisplayName(node.Faction) + " " + DataManager.getUnitsName(node.UnitID) + " 至 " + node.CellNumber + " 放大倍率: " + node.Magnification + " 面向角度: " + node.Angle;
            }
            //加入复数部队
            else if (scheduleNode.GetType() == typeof(BattleResultAddUnits))
            {
                BattleResultAddUnits node = (BattleResultAddUnits)scheduleNode;

                scheduleStr += "  加入 " + EnumData.GetDisplayName(node.Faction) + " " + DataManager.getUnitsName(node.UnitID) + " 至 " + node.CellNumber;
            }
            //移除部队
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveUnit))
            {
                BattleResultRemoveUnit node = (BattleResultRemoveUnit)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.UnitID) + " 并 " + (node.IsDead ? "死亡" : "离开");
            }
            //移除复数部队
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveUnits))
            {
                BattleResultRemoveUnits node = (BattleResultRemoveUnits)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.UnitID) + " 并 " + (node.IsDead ? "死亡" : "离开");
            }
            //移除格子上的部队
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveTileUnit))
            {
                BattleResultRemoveTileUnit node = (BattleResultRemoveTileUnit)scheduleNode;

                scheduleStr += "移除 " + node.Tiles + " 上的部队并 " + (node.IsDead ? "死亡" : "离开");
            }
            //取代部队
            else if (scheduleNode.GetType() == typeof(BattleResultrReplaceUnit))
            {
                BattleResultrReplaceUnit node = (BattleResultrReplaceUnit)scheduleNode;
                scheduleStr += DataManager.getUnitsName(node.AddID) + " 取代 " + DataManager.getUnitsName(node.UnitID) + " 放大倍率: " + node.Magnification + " 面向角度: " + node.Angle;
            }
            //新增布阵点
            else if (scheduleNode.GetType() == typeof(BattleResultAddDistributionPoint))
            {
                BattleResultAddDistributionPoint node = (BattleResultAddDistributionPoint)scheduleNode;

                scheduleStr += node.tileNumbers + " 可布阵数: " + node.DistributionCount + " 排除 " + DataManager.getUnitsName(node.unitid);
            }
            //删除布阵点
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveDistributionPoint))
            {
                BattleResultRemoveDistributionPoint node = (BattleResultRemoveDistributionPoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //新增事件点
            else if (scheduleNode.GetType() == typeof(BattleResultEventPoint))
            {
                BattleResultEventPoint node = (BattleResultEventPoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //删除事件点
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveEventPoint))
            {
                BattleResultRemoveEventPoint node = (BattleResultRemoveEventPoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //新增逃出点
            else if (scheduleNode.GetType() == typeof(BattleResultExitPoint))
            {
                BattleResultExitPoint node = (BattleResultExitPoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //删除逃出点
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveExitPoint))
            {
                BattleResultRemoveExitPoint node = (BattleResultRemoveExitPoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //新增宝藏点
            else if (scheduleNode.GetType() == typeof(BattleResultTreasurePoint))
            {
                BattleResultTreasurePoint node = (BattleResultTreasurePoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //删除宝藏点
            else if (scheduleNode.GetType() == typeof(BattleResultRemoveTreasurePoint))
            {
                BattleResultRemoveTreasurePoint node = (BattleResultRemoveTreasurePoint)scheduleNode;
                scheduleStr += node.tileNumbers;
            }
            //修改行走点
            else if (scheduleNode.GetType() == typeof(BattleResultWalkable))
            {
                BattleResultWalkable node = (BattleResultWalkable)scheduleNode;
                scheduleStr += node.tileNumbers + " 为 " + (node.Walkable ? "" : "不") + "可行走";
            }
            //胜败
            else if (scheduleNode.GetType().IsSubclassOf(typeof(BattleResultWinLose)))
            {
                BattleResultWinLose node1 = (BattleResultWinLose)scheduleNode;
                scheduleStr = discriptionArray[discriptionArray.Length - 1] + ":" + (node1.WinLoseID == "" ? "" : "id:" + node1.WinLoseID);

                //直接获胜
                if (scheduleNode.GetType() == typeof(BattleResultWin))
                {
                }
                //直接失败
                else if (scheduleNode.GetType() == typeof(BattleResultLose))
                {
                }
                //增加勝利條件/角色到達目標點
                else if (scheduleNode.GetType() == typeof(BattleResultWinCharacterExit))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultWinCharacterExit node = (BattleResultWinCharacterExit)scheduleNode;

                    scheduleStr += DataManager.getUnitsName(node.TargetID) + " 到达目标点";
                }
                //增加失敗條件/角色到達目標點
                else if (scheduleNode.GetType() == typeof(BattleResultLoseCharacterExit))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultLoseCharacterExit node = (BattleResultLoseCharacterExit)scheduleNode;

                    scheduleStr += DataManager.getUnitsName(node.TargetID) + " 到达目标点";
                }
                //增加勝利條件/陣營到達目標點
                else if (scheduleNode.GetType() == typeof(BattleResultWinFactionExit))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultWinFactionExit node = (BattleResultWinFactionExit)scheduleNode;

                    scheduleStr += EnumData.GetDisplayName(node.Faction) + " 到达目标点";
                }
                //增加失敗條件/陣營到達目標點
                else if (scheduleNode.GetType() == typeof(BattleResultLoseFactionExit))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultLoseFactionExit node = (BattleResultLoseFactionExit)scheduleNode;

                    scheduleStr += EnumData.GetDisplayName(node.Faction) + " 到达目标点";
                }
                //增加勝利條件/到達回合數
                else if (scheduleNode.GetType() == typeof(BattleResultWinTurn))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultWinTurn node = (BattleResultWinTurn)scheduleNode;

                    scheduleStr += node.Turn + " 回合";
                }
                //增加失敗條件/到達回合數
                else if (scheduleNode.GetType() == typeof(BattleResultLoseTurn))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultLoseTurn node = (BattleResultLoseTurn)scheduleNode;

                    scheduleStr += node.Turn + " 回合";
                }
                //增加勝利條件/陣營全滅
                else if (scheduleNode.GetType() == typeof(BattleResultWinFaction))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultWinFaction node = (BattleResultWinFaction)scheduleNode;

                    scheduleStr += EnumData.GetDisplayName(node.Faction) + " 全灭";
                }
                //增加失敗條件/陣營全滅
                else if (scheduleNode.GetType() == typeof(BattleResultLoseFaction))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultLoseFaction node = (BattleResultLoseFaction)scheduleNode;

                    scheduleStr += EnumData.GetDisplayName(node.Faction) + " 全灭";
                }
                //增加勝利條件/目標死亡
                else if (scheduleNode.GetType() == typeof(BattleResultWinTargetDestroy))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultWinTargetDestroy node = (BattleResultWinTargetDestroy)scheduleNode;

                    scheduleStr += DataManager.getUnitsName(node.TargetID) + " 死亡";
                }
                //增加失敗條件/目標死亡
                else if (scheduleNode.GetType() == typeof(BattleResultLoseTargetDestroy))
                {
                    scheduleStr = discriptionArray[1] + "\\" + scheduleStr + " ";
                    BattleResultLoseTargetDestroy node = (BattleResultLoseTargetDestroy)scheduleNode;

                    scheduleStr += DataManager.getUnitsName(node.TargetID) + " 死亡";
                }
                //移除勝利條件
                else if (scheduleNode.GetType() == typeof(BattleResultWinRemove))
                {
                }
                //移除失敗條件
                else if (scheduleNode.GetType() == typeof(BattleResultLoseRemove))
                {
                }
            }
            //修改勝利條件說明
            else if (scheduleNode.GetType() == typeof(BattleResultChangeWinTip))
            {
                BattleResultChangeWinTip node = (BattleResultChangeWinTip)scheduleNode;

                scheduleStr += "" + node.WinTip;
            }
            //修改失敗條件說明
            else if (scheduleNode.GetType() == typeof(BattleResultChangeLoseTip))
            {
                BattleResultChangeLoseTip node = (BattleResultChangeLoseTip)scheduleNode;

                scheduleStr += "" + node.LoseTip;
            }
            //新增次要條件說明
            else if (scheduleNode.GetType() == typeof(BattleResultAddSecondaryGoal))
            {
                BattleResultAddSecondaryGoal node = (BattleResultAddSecondaryGoal)scheduleNode;

                scheduleStr += "(ID:" + node.SecondaryGoalID + ")" + node.SecondaryGoalTip;
            }
            //修改次要條件狀態
            else if (scheduleNode.GetType() == typeof(BattleResultChangeSecondaryGoal))
            {
                BattleResultChangeSecondaryGoal node = (BattleResultChangeSecondaryGoal)scheduleNode;

                scheduleStr += "(ID:" + node.SecondaryGoalID + ")" + EnumData.GetDisplayName(node.Staus);
            }
            //摄影机移动（锁定格子）
            else if (scheduleNode.GetType() == typeof(BattleResultCameraMoveCell))
            {
                BattleResultCameraMoveCell node = (BattleResultCameraMoveCell)scheduleNode;

                scheduleStr += node.CellNumber + ", 旋转至 " + node.x + ", 距离 " + node.Distance;
            }
            //摄影机移动（锁定部队）
            else if (scheduleNode.GetType() == typeof(BattleResultCameraMoveUnit))
            {
                BattleResultCameraMoveUnit node = (BattleResultCameraMoveUnit)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.UnitId) + ", 旋转至 " + node.x + ", 距离 " + node.Distance;
            }
            //呼叫对话
            else if (scheduleNode.GetType() == typeof(BattleResultTalk))
            {
                BattleResultTalk node = (BattleResultTalk)scheduleNode;

                scheduleStr += DataManager.getTalkMessage(node.TalkID);
            }
            //设定部队是否行动完毕
            else if (scheduleNode.GetType() == typeof(BattleResultUnitIsEndAction))
            {
                BattleResultUnitIsEndAction node = (BattleResultUnitIsEndAction)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitID) + " " + (node.IsEndAction ? "行动完毕" : "开始行动");
            }
            //部队会面
            else if (scheduleNode.GetType() == typeof(BattleResultUnitToUnit))
            {
                BattleResultUnitToUnit node = (BattleResultUnitToUnit)scheduleNode;

                scheduleStr += "移动 " + DataManager.getUnitsName(node.move_id) + " 至 " + DataManager.getUnitsName(node.target_id);
            }
            //部队移动
            else if (scheduleNode.GetType() == typeof(BattleResultMoveUnit))
            {
                BattleResultMoveUnit node = (BattleResultMoveUnit)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitID) + " 移动至:" + node.CellNumber;
            }
            else if (scheduleNode.GetType().IsSubclassOf(typeof(SetFlagBattleAction)))
            {
                SetFlagBattleAction node1 = (SetFlagBattleAction)scheduleNode;

                string desc = "";
                if (node1.Desc.Length > 0)
                {
                    desc = "(" + node1.Desc + ")";
                }

                string methodStr = EnumData.GetDisplayName(node1.method);
                if (node1.method != Method.Clear)
                {
                    methodStr += " " + node1.value;
                }

                scheduleStr += node1.flagName + " " + methodStr + desc;
                //设定全域旗标
                if (scheduleNode.GetType() == typeof(SetGlobalFlagBattleAction))
                {
                }
                //设定战斗旗标
                else if (scheduleNode.GetType() == typeof(SetLocalFlagBattleAction))
                {
                }
            }
            //给奖励
            else if (scheduleNode.GetType() == typeof(BattleResultAddReward))
            {
                BattleResultAddReward node = (BattleResultAddReward)scheduleNode;

                scheduleStr += DataManager.getRewardsStr(node.RewardID, deep + 1);
            }
            //转换音乐
            else if (scheduleNode.GetType() == typeof(BattleResultChangeMusic))
            {
                BattleResultChangeMusic node = (BattleResultChangeMusic)scheduleNode;

                scheduleStr += node.MusicName + ", 淡出时间 " + node.FadeTime + " 秒, " + (node.Continuous ? "" : "不") + "连续";
            }
            //淡出音乐
            else if (scheduleNode.GetType() == typeof(BattleResultFadeOutMusic))
            {
                BattleResultFadeOutMusic node = (BattleResultFadeOutMusic)scheduleNode;

                scheduleStr += "淡出时间 " + node.FadeOutTime + " 秒";
            }
            //播放音效
            else if (scheduleNode.GetType() == typeof(BattleResultPalySound))
            {
                BattleResultPalySound node = (BattleResultPalySound)scheduleNode;

                scheduleStr += node.SoundPath/* + ", 音量 " +node.Volume*/;
            }
            //等待X秒
            else if (scheduleNode.GetType() == typeof(BattleResultWaitAction))
            {
                BattleResultWaitAction node = (BattleResultWaitAction)scheduleNode;

                scheduleStr = "等待 " + node.WaitTime + " 秒";
            }
            //直接结束战斗
            else if (scheduleNode.GetType() == typeof(EndBattleAction))
            {
                EndBattleAction node = (EndBattleAction)scheduleNode;

                scheduleStr += "接续cinematic id:" + node.MovieId;
            }
            //设定掉落奖励百分比
            else if (scheduleNode.GetType() == typeof(SetDropRewardProbability))
            {
                SetDropRewardProbability node = (SetDropRewardProbability)scheduleNode;

                scheduleStr += node.Probability + "%";
            }
            //设定是否掉落奖励（预设开）
            else if (scheduleNode.GetType() == typeof(SetIsDropReward))
            {
                SetIsDropReward node = (SetIsDropReward)scheduleNode;

                scheduleStr += node.IsOpen ? "开" : "关";
            }
            //设定装备按钮开关（全团队）
            else if (scheduleNode.GetType() == typeof(SetIsShowEquip))
            {
                SetIsShowEquip node = (SetIsShowEquip)scheduleNode;

                scheduleStr += node.IsOpen ? "开" : "关";
            }
            //设定道具按钮开关（全团队）
            else if (scheduleNode.GetType() == typeof(SetIsShowItem))
            {
                SetIsShowItem node = (SetIsShowItem)scheduleNode;

                scheduleStr += node.IsOpen ? "开" : "关";
            }
            //设定技能按钮开关（全团队）
            else if (scheduleNode.GetType() == typeof(SetIsShowSkill))
            {
                SetIsShowSkill node = (SetIsShowSkill)scheduleNode;

                scheduleStr += node.IsOpen ? "开" : "关";
            }
            //设定特技按钮开关（全团队）
            else if (scheduleNode.GetType() == typeof(SetIsShowSpecial))
            {
                SetIsShowSpecial node = (SetIsShowSpecial)scheduleNode;

                scheduleStr += node.IsOpen ? "开" : "关";
            }
            //设定部队装备按钮开关（指定部队）
            else if (scheduleNode.GetType() == typeof(SetUnitCanEquip))
            {
                SetUnitCanEquip node = (SetUnitCanEquip)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitID) + (node.IsOpen ? "开" : "关");
            }
            //部队道具按钮开关（指定部队）
            else if (scheduleNode.GetType() == typeof(SetUnitCanUseItem))
            {
                SetUnitCanUseItem node = (SetUnitCanUseItem)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitID) + (node.IsOpen ? "开" : "关");
            }
            //部队技能按钮开关（指定部队）
            else if (scheduleNode.GetType() == typeof(SetUnitCanUseSkills))
            {
                SetUnitCanUseSkills node = (SetUnitCanUseSkills)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitID) + (node.IsOpen ? "开" : "关");
            }
            //部队特技按钮开关（指定部队）
            else if (scheduleNode.GetType() == typeof(SetUnitCanUseSpecialSkill))
            {
                SetUnitCanUseSpecialSkill node = (SetUnitCanUseSpecialSkill)scheduleNode;

                scheduleStr += DataManager.getUnitsName(node.unitID) + (node.IsOpen ? "开" : "关");
            }
            else
            {
                scheduleStr += "---未完成---";
                //scheduleStr = scheduleNode.ToString();
            }



            return scheduleStr;
        }

        public static string replaceRichTextWriteOut(string text, FlowLayoutPanel panel)
        {
            text = text.Replace("\r\n", ",");
            foreach (Control button in panel.Controls)
            {
                if (button is Button)
                {
                    if (button.Tag.ToString() == "<nu_money>")
                    {
                        text = text.Replace("{养成-金钱}", "<nu_money>");
                        text = text.Replace("{金钱值}", "{0}");
                    }
                    else if (button.Tag.ToString() == "<nu_skill>")
                    {
                        text = text.Replace("{养成-技能经验}", "<nu_skill>");
                        text = text.Replace("{技能名}", "{0}");
                        text = text.Replace("{技能经验值}", "{1}");
                    }
                    else if (button.Tag.ToString() == "<nu_mantra>")
                    {
                        text = text.Replace("{养成-心法经验}", "<nu_mantra>");
                        text = text.Replace("{心法名}", "{0}");
                        text = text.Replace("{心法经验值}", "{1}");
                    }
                    else
                    {
                        text = text.Replace(button.Text, button.Tag.ToString());
                    }
                }
            }
            return text;
        }


        public static string replaceRichTextReadIn(string text, FlowLayoutPanel panel)
        {
            if (text.Contains("<nu_money>"))
            {
                text = text.Replace("<nu_money>", "{养成-金钱}");
                text = text.Replace("{0}", "{金钱值}");
            }
            if (text.Contains("<nu_skill>"))
            {
                text = text.Replace("<nu_skill>", "{养成-技能经验}");
                text = text.Replace("{0}", "{技能名}");
                text = text.Replace("{1}", "{技能经验值}");
            }
            if (text.Contains("<nu_mantra>"))
            {
                text = text.Replace("<nu_mantra>", "{养成-心法经验}");
                text = text.Replace("{0}", "{心法名}");
                text = text.Replace("{1}", "{心法经验值}");
            }
            foreach (Control button in panel.Controls)
            {
                if (button is Button)
                {
                    text = text.Replace(button.Tag.ToString(), button.Text);
                }
            }

            return text;
        }


        public static string replaceFormulaTextReadIn(string text, FlowLayoutPanel panel)
        {
            foreach (Control button in panel.Controls)
            {
                if (button is Button)
                {
                    text = text.Replace(button.Tag.ToString(), button.Text);
                }
            }
            string[] splitChar = new string[] { "+", "-", "*", "/", "(", ")", "^" };
            for (int i = 0; i < splitChar.Length; i++)
            {
                text = text.Replace(splitChar[i], "@" + splitChar[i] + "@");
            }
            string[] contents = text.Split('@');
            for (int i = 0; i < contents.Length; i++)
            {
                if (DataManager.allGameFormulaLvis.ContainsKey(contents[i]))
                {
                    ListViewItem lvi = DataManager.allGameFormulaLvis[contents[i]];
                    string text2 = lvi.SubItems[1].Text;
                    if (text2.IsNullOrEmpty())
                    {
                        text2 = lvi.SubItems[2].Text;
                        if (text2.IsNullOrEmpty())
                        {
                            text2 = lvi.Text;
                        }
                    }
                    contents[i] = "{" + text2 + "}";

                }
            }
            text = "";
            for (int i = 0; i < contents.Length; i++)
            {
                text += contents[i];
            }


            text = text.Replace("math.min", "取最小值");
            text = text.Replace("math.max", "取最大值");
            text = text.Replace("math.random", "取随机数");
            text = text.Replace("math.log", "取对数");
            text = text.Replace("player_status", "{玩家属性}");
            text = text.Replace("require_status", "{需求属性}");

            return text;
        }

        public static string replaceFormulaTextWriteOut(string text, FlowLayoutPanel panel)
        {
            foreach (Control button in panel.Controls)
            {
                if (button is Button)
                {
                    text = text.Replace(button.Text, button.Tag.ToString());
                }
            }
            text = text.Replace("取最小值", "math.min");
            text = text.Replace("取最大值", "math.max");
            text = text.Replace("取随机数", "math.random");
            text = text.Replace("取对数", "math.log");
            text = text.Replace("{玩家属性}", "player_status");
            text = text.Replace("{需求属性}", "require_status");
            return text;
        }

        public static void readBaseFlowGraphTree(TreeNode parentNode, OutputNode actionNode)
        {
            if (actionNode != null)
            {
                DescriptionAttribute description = (DescriptionAttribute)actionNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray = description.Value.Split('/');



                if (actionNode.GetType() == typeof(LogicalNode))
                {
                    LogicalNode logicalNode = (LogicalNode)actionNode;
                    List<OutputNode<bool>> inputListNode = logicalNode.inputListNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("复数逻辑判断:" + EnumData.GetDisplayName(logicalNode.op));
                    currentTreeNode.Tag = "\"LogicalNode\" : $ ," + (int)logicalNode.op;
                    for (int i = 0; i < inputListNode.Count; i++)
                    {
                        Utils.readBaseFlowGraphTree(currentTreeNode, inputListNode[i]);
                    }
                }
                else if (actionNode.GetType() == typeof(MultiLogicaAction))
                {
                    MultiLogicaAction MultiLogicaAction = (MultiLogicaAction)actionNode;
                    List<OutputNode<bool>> listNode = MultiLogicaAction.listNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("邏輯動作:");
                    currentTreeNode.Tag = "\"MultiLogicaAction\" : $";
                    for (int i = 0; i < listNode.Count; i++)
                    {
                        Utils.readBaseFlowGraphTree(currentTreeNode, listNode[i]);
                    }
                }
                else if (actionNode.GetType() == typeof(MultiAction))
                {
                    MultiAction MultiAction = (MultiAction)actionNode;
                    List<ActionNode> listNode = MultiAction.actionListNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("复数動作:");
                    currentTreeNode.Tag = "\"MultiAction\" : $";
                    for (int i = 0; i < listNode.Count; i++)
                    {
                        Utils.readBaseFlowGraphTree(currentTreeNode, listNode[i]);
                    }
                }
                else if (actionNode.GetType() == typeof(ClickNode))
                {
                    ClickNode clickNode = (ClickNode)actionNode;
                    MultiAction multiAction = (MultiAction)clickNode.actionNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("点击:");
                    currentTreeNode.Tag = "\"ClickNode\"";
                    Utils.readBaseFlowGraphTree(currentTreeNode, multiAction);
                }
                else if (actionNode.GetType() == typeof(PlayerEnterNode))
                {
                    PlayerEnterNode clickNode = (PlayerEnterNode)actionNode;
                    MultiAction multiAction = (MultiAction)clickNode.actionNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("玩家进入");
                    currentTreeNode.Tag = "\"PlayerEnterNode\"";
                    Utils.readBaseFlowGraphTree(currentTreeNode, multiAction);
                }
                else if (actionNode.GetType() == typeof(PlayerLeaveNode))
                {
                    PlayerLeaveNode clickNode = (PlayerLeaveNode)actionNode;
                    MultiAction multiAction = (MultiAction)clickNode.actionNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("玩家离开");
                    currentTreeNode.Tag = "\"PlayerLeaveNode\"";
                    Utils.readBaseFlowGraphTree(currentTreeNode, multiAction);
                }
                else if (actionNode.GetType() == typeof(TriggerEnterNode))
                {
                    TriggerEnterNode clickNode = (TriggerEnterNode)actionNode;
                    MultiAction multiAction = (MultiAction)clickNode.actionNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("玩家进入Collider");
                    currentTreeNode.Tag = "\"TriggerEnterNode\"";
                    Utils.readBaseFlowGraphTree(currentTreeNode, multiAction);
                }
                else if (actionNode.GetType() == typeof(TriggerExitNode))
                {
                    TriggerExitNode clickNode = (TriggerExitNode)actionNode;
                    MultiAction multiAction = (MultiAction)clickNode.actionNode;

                    TreeNode currentTreeNode = parentNode.Nodes.Add("玩家离开Collider");
                    currentTreeNode.Tag = "\"TriggerExitNode\"";
                    Utils.readBaseFlowGraphTree(currentTreeNode, multiAction);
                }
                else
                {
                    string nodeStr = Utils.getFlowNodeStr(discriptionArray, actionNode, 0);

                    TreeNode newNode = parentNode.Nodes.Add(nodeStr);

                    string[] NodeClassName = actionNode.GetType().ToString().Split('.');
                    string tag = Utils.getBaseFlowGraphNodeTag(actionNode, actionNode.GetType());
                    if (tag.Length > 0)
                    {
                        tag = " : " + tag.Substring(0, tag.Length - 2);
                    }
                    newNode.Tag = "\"" + NodeClassName[NodeClassName.Length - 1] + "\"" + tag;
                }
            }
        }



        public static string getBaseFlowGraphNodeTag(System.Object output, Type type)
        {
            string tag = "";

            if (type.IsSubclassOf(typeof(OutputNode)) && type.BaseType != typeof(OutputNode))
            {
                tag += Utils.getBaseFlowGraphNodeTag(output, type.BaseType);
            }

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.DeclaringType != type || (fieldInfo.GetCustomAttribute<InputFieldAttribute>() == null && fieldInfo.GetCustomAttribute<DisplayNameAttribute>() == null && fieldInfo.GetCustomAttribute<ArgumentAttribute>() == null))
                {
                    continue;
                }

                if (fieldInfo.FieldType.IsSubclassOf(typeof(Enum)))
                {
                    tag += (int)fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(float))
                {
                    tag += ((float)fieldInfo.GetValue(output)).ToString("0.00000") + ", ";
                }
                else if (fieldInfo.FieldType == typeof(int))
                {
                    tag += (int)fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(string))
                {
                    tag += "\"" + fieldInfo.GetValue(output) + "\", ";
                }
                else if (fieldInfo.FieldType == typeof(bool))
                {
                    tag += fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(Vector3))
                {
                    Vector3 vector = (Vector3)fieldInfo.GetValue(output);
                    tag += "{" + vector.x.ToString("0.00000") + ", " + vector.y.ToString("0.00000") + ", " + vector.z.ToString("0.00000") + "}, ";
                }
                else if (fieldInfo.FieldType == typeof(List<AnimationCilpInfo>))
                {
                    tag += "[";

                    List<AnimationCilpInfo> animationClipInfos = (List<AnimationCilpInfo>)fieldInfo.GetValue(output);
                    for (int i = 0; i < animationClipInfos.Count; i++)
                    {
                        string tempTag = Utils.getBaseFlowGraphNodeTag(animationClipInfos[i], typeof(AnimationCilpInfo));
                        tag += "{" + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                    }

                    if (tag.Length > 1)
                    {
                        tag = tag.Substring(0, tag.Length - 2);
                    }

                    tag += "], ";
                }
                else if (fieldInfo.FieldType == typeof(List<GroupTransformAction.TransformInfo>))
                {
                    tag += "[";

                    List<GroupTransformAction.TransformInfo> infos = (List<GroupTransformAction.TransformInfo>)fieldInfo.GetValue(output);
                    for (int i = 0; i < infos.Count; i++)
                    {
                        string tempTag = Utils.getBaseFlowGraphNodeTag(infos[i], typeof(GroupTransformAction.TransformInfo));
                        tag += "{" + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                    }

                    if (tag.Length > 1)
                    {
                        tag = tag.Substring(0, tag.Length - 2);
                    }

                    tag += "], ";
                }
                else if (fieldInfo.FieldType.IsSubclassOf(typeof(OutputNode)))
                {
                    OutputNode outputNode = (OutputNode)fieldInfo.GetValue(output);
                    string name = outputNode.GetType().Name;
                    string tempTag = Utils.getBaseFlowGraphNodeTag(outputNode, outputNode.GetType());
                    tag += "{ \"" + name + "\" : " + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                }
                else if (fieldInfo.FieldType == typeof(List<OutputNode<bool>>))
                {
                    tag += "[";
                    List<OutputNode<bool>> list = (List<OutputNode<bool>>)fieldInfo.GetValue(output);
                    for (int i = 0; i < list.Count; i++)
                    {
                        string tempTag = Utils.getBaseFlowGraphNodeTag(list[i], list[i].GetType());
                        tag += "{ \"" + list[i].GetType().Name + "\" : " + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                    }

                    tag = tag.Substring(0, tag.Length - 2);
                    tag += "], ";
                }
            }

            return tag;
        }



        public static string[] eventNodes = new string[] { "ClickNode", "PlayerEnterNode", "PlayerLeaveNode", "TriggerEnterNode", "TriggerExitNode" };
        public static string[] noFormAction = new string[] { "OpenUICommissionAction", "OpenUIElectiveAction", "OpenUIForgeAction", "OpenUINurturanceAction", "OpenUIPawnShopAction", "OpenUIReadingAction", "OpenUIRefiningAction", "OpenUIShopAction", "PlayerResetWeaponAction", "SortOutNpcAndEventCubeAction", "CameraLockPlayerAction", "CameraUnLockAction", "CameraUnShakeAction", "ElectiveCinematicAction", "NextOrEndQuestAction", "SaveAction" };

        public static string BaseFlowGraphTagToStr(TreeNode actionNode)
        {
            string tagStr = "";

            if (actionNode.Tag.ToString() == "rootNode")
            {
                if (actionNode.Nodes.Count != 0)
                {
                    tagStr = Utils.BaseFlowGraphTagToStr(actionNode.Nodes[0]);
                }
            }
            else
            {
                bool hasChild = false;
                if (actionNode.Tag.ToString().Contains("LogicalNode") || actionNode.Tag.ToString().Contains("MultiLogicaAction") || actionNode.Tag.ToString().Contains("MultiAction"))
                {
                    hasChild = true;
                }
                else
                {
                    for (int i = 0; i < eventNodes.Length; i++)
                    {
                        if (actionNode.Tag.ToString().Contains(eventNodes[i]))
                        {
                            string content = "";
                            if (actionNode.Nodes.Count > 0)
                            {
                                content = ":{" + Utils.BaseFlowGraphTagToStr(actionNode.Nodes[0]) + "} ";
                            }
                            return actionNode.Tag.ToString() + content;
                        }
                    }
                }
                if (hasChild)
                {
                    string childTagStr = "[";
                    for (int i = 0; i < actionNode.Nodes.Count; i++)
                    {
                        childTagStr += "{" + Utils.BaseFlowGraphTagToStr(actionNode.Nodes[i]) + "}, ";
                    }
                    if (childTagStr.Length > 1)
                    {
                        childTagStr = childTagStr.Substring(0, childTagStr.Length - 2);
                    }
                    childTagStr += "]";
                    tagStr += actionNode.Tag.ToString().Replace("$", childTagStr);
                }
                else
                {
                    return actionNode.Tag.ToString();
                }
            }

            return tagStr;
        }

        public static void initFlowTreeView(BaseFlowGraph flow, TreeView treeView)
        {
            treeView.Nodes.Clear();
            TreeNode rootNode = treeView.Nodes.Add("根节点");
            rootNode.Tag = "rootNode";
            if (flow != null)
            {
                Utils.readBaseFlowGraphTree(rootNode, (OutputNode)flow.Output);
            }
            treeView.ExpandAll();
        }

        public static void initComboBox(ComboBox comboBox, Type enumType)
        {
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "key";


            foreach (int temp in Enum.GetValues(enumType))
            {
                ComboBoxItem cbi = new ComboBoxItem(temp.ToString(), EnumData.GetDisplayName((Enum)Enum.Parse(enumType, temp.ToString())));
                comboBox.Items.Add(cbi);
            }
        }

        public static string stringListToString(List<string> list)
        {
            string str = "";
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    str += list[i] + ",";
                }
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public static void addLogicalNode(TreeView treeView)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("请选择要添加到的节点");
                return;
            }
            TreeNode currentNode = treeView.SelectedNode;
            string tag = currentNode.Tag.ToString();
            if (tag.StartsWith("\"") || tag.StartsWith("\\"))
            {
                tag = tag.Substring(1, tag.Length - 1);
            }
            if (tag.EndsWith("\"") || tag.EndsWith("\\"))
            {
                tag = tag.Substring(0, tag.Length - 1);
            }
            while (!tag.Contains("MultiAction") && !tag.Contains("LogicalNode") && !tag.Contains("MultiLogicaAction") && !eventNodes.Contains(tag) && currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                tag = currentNode.Tag.ToString();
                if (tag.StartsWith("\"") || tag.StartsWith("\\"))
                {
                    tag = tag.Substring(1, tag.Length - 1);
                }
                if (tag.EndsWith("\"") || tag.EndsWith("\\"))
                {
                    tag = tag.Substring(0, tag.Length - 1);
                }
            }

            TreeNode node = new TreeNode("复数逻辑判断");
            node.Tag = ":";

            LogicalNodeForm form = new LogicalNodeForm(node, true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                currentNode.Nodes.Add(node);
                treeView.SelectedNode = node;
                node.Parent.Expand();
            }
        }

        public static void addMultiLogicaAction(TreeView treeView)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("请选择要添加到的节点");
                return;
            }

            TreeNode currentNode = treeView.SelectedNode;
            string tag = currentNode.Tag.ToString();
            if (tag.StartsWith("\"") || tag.StartsWith("\\"))
            {
                tag = tag.Substring(1, tag.Length - 1);
            }
            if (tag.EndsWith("\"") || tag.EndsWith("\\"))
            {
                tag = tag.Substring(0, tag.Length - 1);
            }
            while (!tag.Contains("MultiAction") && !tag.Contains("LogicalNode") && !tag.Contains("MultiLogicaAction") && !eventNodes.Contains(tag) && currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                tag = currentNode.Tag.ToString();
                if (tag.StartsWith("\"") || tag.StartsWith("\\"))
                {
                    tag = tag.Substring(1, tag.Length - 1);
                }
                if (tag.EndsWith("\"") || tag.EndsWith("\\"))
                {
                    tag = tag.Substring(0, tag.Length - 1);
                }
            }

            TreeNode node = currentNode.Nodes.Add("逻辑动作");
            node.Tag = "\"MultiLogicaAction\" : $";
            treeView.SelectedNode = node;
        }

        public static void addMultiAction(TreeView treeView)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("请选择要添加到的节点");
                return;
            }

            TreeNode currentNode = treeView.SelectedNode;
            string tag = currentNode.Tag.ToString();
            if (tag.StartsWith("\"") || tag.StartsWith("\\"))
            {
                tag = tag.Substring(1, tag.Length - 1);
            }
            if (tag.EndsWith("\"") || tag.EndsWith("\\"))
            {
                tag = tag.Substring(0, tag.Length - 1);
            }
            while (!tag.Contains("MultiAction") && !tag.Contains("LogicalNode") && !tag.Contains("MultiLogicaAction") && !eventNodes.Contains(tag) && currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                tag = currentNode.Tag.ToString();
                if (tag.StartsWith("\"") || tag.StartsWith("\\"))
                {
                    tag = tag.Substring(1, tag.Length - 1);
                }
                if (tag.EndsWith("\"") || tag.EndsWith("\\"))
                {
                    tag = tag.Substring(0, tag.Length - 1);
                }
            }

            TreeNode node = currentNode.Nodes.Add("复数动作");
            node.Tag = "\"MultiAction\" : $";
            treeView.SelectedNode = node;
        }
        public static void addConditionNode(ListView listView, TreeView treeView)
        {
            try
            {
                if (listView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要添加的节点");
                    return;
                }
                TreeNode currentNode = treeView.SelectedNode;
                if (currentNode == null)
                {
                    MessageBox.Show("请选择要添加至的节点");
                    return;
                }

                string currentNodeTag = currentNode.Tag.ToString();
                if (currentNodeTag.StartsWith("\"") || currentNodeTag.StartsWith("\\"))
                {
                    currentNodeTag = currentNodeTag.Substring(1, currentNodeTag.Length - 1);
                }
                if (currentNodeTag.EndsWith("\"") || currentNodeTag.EndsWith("\\"))
                {
                    currentNodeTag = currentNodeTag.Substring(0, currentNodeTag.Length - 1);
                }

                if (eventNodes.Contains(currentNodeTag))
                {
                    MessageBox.Show("不可手动添加至事件触发节点");
                    return;
                }

                while (!currentNodeTag.Contains("MultiAction") && !currentNodeTag.Contains("LogicalNode") && !currentNodeTag.Contains("MultiLogicaAction") && !eventNodes.Contains(currentNodeTag) && currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    currentNodeTag = currentNode.Tag.ToString();
                }
                if (currentNode.Text == "根节点")
                {
                    MessageBox.Show("不可添加至根节点");
                    return;
                }

                bool isAdd = false;


                TreeNode node = new TreeNode(listView.SelectedItems[0].Text);
                node.Tag = ":";

                if (Utils.noFormAction.Contains(listView.SelectedItems[0].SubItems[1].Text) || eventNodes.Contains(listView.SelectedItems[0].SubItems[1].Text))
                {
                    node.Text = listView.SelectedItems[0].Text;
                    node.Tag = "\"" + listView.SelectedItems[0].SubItems[1].Text + "\"";
                    isAdd = true;
                }
                else
                {

                    string className = "侠之道mod制作器." + listView.SelectedItems[0].SubItems[1].Text + "Form";
                    Type clazz = Type.GetType(className);

                    if (clazz != null)
                    {
                        object obj = Activator.CreateInstance(clazz, new object[] { node, true });

                        MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });


                        if ((DialogResult)method.Invoke(obj, new object[] { }) == DialogResult.OK)
                        {
                            isAdd = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("---未完成---");
                    }
                }

                if (isAdd)
                {

                    treeView.SelectedNode = node;
                    currentNode.Nodes.Add(node);

                    if (eventNodes.Contains(listView.SelectedItems[0].SubItems[1].Text))
                    {
                        addMultiAction(treeView);
                    }
                    currentNode.Expand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void editConditionNode(TreeView treeView)
        {
            TreeNode treeNode = treeView.SelectedNode;
            if (treeNode != null && treeNode.Tag != null)
            {
                string tag = treeNode.Tag.ToString().Split(':')[0].Trim();
                if (tag.StartsWith("\"") || tag.StartsWith("\\"))
                {
                    tag = tag.Substring(1, tag.Length - 1);
                }
                if (tag.EndsWith("\"") || tag.EndsWith("\\"))
                {
                    tag = tag.Substring(0, tag.Length - 1);
                }
                if (tag == "rootNode" || tag.Contains("MultiLogicaAction") || tag.Contains("MultiAction") || eventNodes.Contains(tag))
                {
                    MessageBox.Show("该节点无需修改");
                    return;
                }
                if (tag == "LogicalNode")
                {
                    LogicalNodeForm form = new LogicalNodeForm(treeNode, false);
                    form.ShowDialog();
                }
                else
                {
                    string className = "侠之道mod制作器." + tag + "Form";
                    Type clazz = Type.GetType(className);

                    if (clazz != null)
                    {
                        object obj = Activator.CreateInstance(clazz, new object[] { treeNode, false });

                        MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                        method.Invoke(obj, new object[] { });
                    }
                    else
                    {
                        MessageBox.Show("---未完成---");
                    }

                }
            }
        }

        public static void deleteConditionNode(TreeView treeView)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Parent == null)
                {
                    MessageBox.Show("不可删除根节点");
                    return;
                }

                if (MessageBox.Show("确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    treeView.Nodes.Remove(treeView.SelectedNode);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个节点");
            }
        }

        public static void addToolStripMenuItem(string type,string tag, ContextMenuStrip cms)
        {
            if(type == "buffer")
            {
                DataManager.LoadBuffer(false);
            }
            else if (type == "cinematic")
            {
                DataManager.LoadCinematic(false);
            }
            else if (type == "config/schedule")
            {
                DataManager.LoadConfigSchedule(false);
            }
            else if (type == "battle/schedule")
            {
                DataManager.LoadBattleSchedule(false);
            }
            string[] property = tag.ToString().Split(':')[1].Split(',');
            for (int i = 0; i < property.Length; i++)
            {
                string propertyStr = property[i].Trim();
                while (propertyStr.StartsWith("\"") || propertyStr.StartsWith("\\"))
                {
                    propertyStr = propertyStr.Substring(1, propertyStr.Length - 1);
                }
                while (propertyStr.EndsWith("\"") || propertyStr.EndsWith("\\"))
                {
                    propertyStr = propertyStr.Substring(0, propertyStr.Length - 1);
                }

                if(type == "buffer")
                {

                    if (DataManager.dict["buffer"].Contains(propertyStr) || DataManager.dict["buffer_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看Buff(" + DataManager.getBuffersName(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readBuffToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
                else if (type == "battle/schedule")
                {
                    if (DataManager.dict["battle/schedule"].Contains(propertyStr) || DataManager.dict["battle/schedule_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看战斗流程(" + DataManager.getScheduleName(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readBattleScheduleToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
                else if (type == "Adjustment")
                {
                    if (DataManager.dict["Adjustment"].Contains(propertyStr) || DataManager.dict["Adjustment_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看整备(" + DataManager.getAdjustmentName(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readAdjustmentToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
                else if (type == "BattleArea")
                {
                    if (DataManager.dict["BattleArea"].Contains(propertyStr) || DataManager.dict["BattleArea_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看战斗(" + DataManager.getBattleAreaRemark(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readBattleAreaToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
                else if(type == "Talk")
                {
                    if (DataManager.dict["Talk"].Contains(propertyStr) || DataManager.dict["Talk_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看对话(" + DataManager.getTalkMessage(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readTalkToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
                else if (type == "cinematic")
                {
                    if (DataManager.dict["cinematic"].Contains(propertyStr) || DataManager.dict["cinematic_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看演出(" + DataManager.getCinematicName(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readCinematicToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
                else if (type == "config/schedule")
                {
                    if (DataManager.dict["config/schedule"].Contains(propertyStr) || DataManager.dict["config/schedule_cus"].Contains(propertyStr))
                    {
                        ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem("查看演出(" + DataManager.getCinematicName(propertyStr) + ")");
                        ToolStripMenuItem.Tag = propertyStr;
                        ToolStripMenuItem.Click += readCinematicToolStripMenuItem_Click;
                        cms.Items.Add(ToolStripMenuItem);
                    }
                }
            }
        }
        private static void readBuffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem readBuffToolStripMenuItem = sender as ToolStripMenuItem;
            string bufferId = readBuffToolStripMenuItem.Tag.ToString();


            BufferInfoForm form = new BufferInfoForm(bufferId, true);

            form.Show();
        }
        private static void readBattleScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            string id = ToolStripMenuItem.Tag.ToString();


            ScheduleInfoForm form = new ScheduleInfoForm(id, true);

            form.Show();
        }
        private static void readTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            string id = ToolStripMenuItem.Tag.ToString();


            TalkInfoForm form = new TalkInfoForm(id, true);

            form.Show();
        }
        private static void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            string id = ToolStripMenuItem.Tag.ToString();


            CinematicInfoForm form = new CinematicInfoForm("cinematic", id, true);

            form.Show();
        }
        private static void readBattleAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            string id = ToolStripMenuItem.Tag.ToString();


            BattleAreaInfoForm form = new BattleAreaInfoForm(id, true);

            form.Show();
        }
        private static void readAdjustmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            string id = ToolStripMenuItem.Tag.ToString();


            AdjustmentInfoForm form = new AdjustmentInfoForm(id, true);

            form.Show();
        }

        public static void createCinematicContextMenuStrip(ContextMenuStrip cms,TreeView tv, CancelEventArgs e)
        {
            try
            {
                cms.Items.Clear();

                TreeNode node = tv.SelectedNode;

                if (node.Tag == null)
                {
                    return;
                }

                string tag = node.Tag.ToString();


                if (tag.Contains("TalkAction"))
                {
                    Utils.addToolStripMenuItem("Talk", tag, cms);
                }
                if (tag.Contains("BattleAction"))
                {
                    Utils.addToolStripMenuItem("BattleArea", tag, cms);
                }
                if (tag.Contains("RunCinematicAction") || tag.Contains("ProcessAction") || tag.Contains("OpenUIEvaluationAction"))
                {
                    Utils.addToolStripMenuItem("cinematic", tag, cms);
                }
                if (tag.Contains("OpenUIAdjustmentAction"))
                {
                    Utils.addToolStripMenuItem("Adjustment", tag, cms);
                }
                if (cms.Items.Count > 0)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using UnityEngine;


namespace ActionGroupsExtended
{

    

   
    public class ModuleAGX : PartModule
    {
        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)] 
        public string placeHolder = "Hello World"; //Config nodes can behave wierd when empty, a part with no actions on it will have no data besides this line
        //config nodes get added/removed via OnLoad/OnSave here
        public List<AGXAction> agxActionsThisPart = new List<AGXAction>();

        public override void OnStart(StartState state)
        {
            if(agxActionsThisPart == null)
            {
                agxActionsThisPart = new List<AGXAction>();
            }
        }
        
        public override void OnSave(ConfigNode node)
        {
            string ErrLine = "1";
            try
            {
                node.RemoveNodes("ACTION"); 
                ErrLine = "2";
                if(agxActionsThisPart.Count > 0)
                {
                    ErrLine = "3";
                foreach (AGXAction agAct in agxActionsThisPart)
                {
                    ErrLine = "4";
                    ConfigNode actionNode = new ConfigNode("ACTION");
                    ErrLine = "5";
                    if (agAct != null)
                    {
                        ErrLine = "5a";
                        actionNode = AGextScenario.SaveAGXActionVer2(agAct);
                    }
                    ErrLine = "6";
                    node.AddNode(actionNode);
                    ErrLine = "7";
                }
                }
            }
        catch(Exception e)
        {
            print("AGX partModule OnSave fail: " + ErrLine + " " + e);
        }
        }

            public override void OnLoad(ConfigNode node)
            {
                
                ConfigNode[] actionsNodes = node.GetNodes("ACTION");
                foreach(ConfigNode actionNode in actionsNodes)
                {
                    agxActionsThisPart.Add(AGextScenario.LoadAGXActionVer2(actionNode,this.part,false));
                }
                //print("Load called " + agxActionsThisPart.Count);
            }
       
    }//ModuleAGX

    public class AGXOtherVessel //data class for a vessel that does not have focus
    {
        private uint flightID; //
        private bool vesselInstanceOK = false; //is this vessel loadable? if this is false, run nothing
        private List<AGXAction> actionsList;
        private Vessel thisVsl;

        public AGXOtherVessel(uint FlightID)
        {
            flightID = FlightID;
            //Debug.Log("Before");
            List<Vessel> loadedVessels = FlightGlobals.Vessels.FindAll(vsl => vsl.loaded == true);
            thisVsl = loadedVessels.Find(ves => ves.rootPart.flightID == flightID);
            //Debug.Log("After");
            actionsList = new List<AGXAction>();
            if(!thisVsl.loaded || thisVsl == null) //check vessel is loaded
            {
                vesselInstanceOK = false;
                ScreenMessages.PostScreenMessage("AGX cannot activate actions on unloaded vessels.", 10F, ScreenMessageStyle.UPPER_CENTER);
                return;
            }
            ConfigNode nodeLoad = new ConfigNode();
            if(AGXFlight.AGXFlightNode != null)
            {
                if(AGXFlight.AGXFlightNode.HasNode(flightID.ToString()))
                {
                    nodeLoad = AGXFlight.AGXFlightNode.GetNode(flightID.ToString());
                    ConfigNode[] partNodes = nodeLoad.GetNodes("PART");
                    foreach(ConfigNode prtNode in partNodes)
                    {
                        Part thisPrt = thisVsl.Parts.Find(p => p.flightID == Convert.ToUInt32(prtNode.GetValue("flightID")));
                        ConfigNode[] actionNodes = prtNode.GetNodes("ACTION");
                        foreach(ConfigNode aNode in actionNodes)
                        {
                            actionsList.Add(AGextScenario.LoadAGXActionVer2(aNode, thisPrt, false));
                        }
                    }
                }
                vesselInstanceOK = true;
            }
        }

        public void ActivateActionString(string groupStr, bool force, bool forceDir) //main activation method
        {
            if(thisVsl.HoldPhysics)
            {
                ScreenMessages.PostScreenMessage("AGX cannot activate actions while under timewarp.", 10F, ScreenMessageStyle.UPPER_CENTER);
            }
            else if (vesselInstanceOK)
            {
                int group = actionsList.Find(agx => agx.grpName == groupStr).group;
                ActivateActionGroup(group, force, forceDir);

            }
        }
            
        public void ActivateActionGroup(int group, bool force, bool forceDir) //main activation method
            {
                string ErrLine = "1";    
            try
                {
                    if (thisVsl.HoldPhysics)
                    {
                        ScreenMessages.PostScreenMessage("AGX cannot activate actions while under timewarp.", 10F, ScreenMessageStyle.UPPER_CENTER);
                    }    
                else if (vesselInstanceOK)
                {
                    ErrLine = "2";
                    Dictionary<int, KSPActionGroup> CustomActions = new Dictionary<int, KSPActionGroup>();
                    CustomActions.Add(1, KSPActionGroup.Custom01); //how do you add a range from enum?
                    CustomActions.Add(2, KSPActionGroup.Custom02);
                    CustomActions.Add(3, KSPActionGroup.Custom03);
                    CustomActions.Add(4, KSPActionGroup.Custom04);
                    CustomActions.Add(5, KSPActionGroup.Custom05);
                    CustomActions.Add(6, KSPActionGroup.Custom06);
                    CustomActions.Add(7, KSPActionGroup.Custom07);
                    CustomActions.Add(8, KSPActionGroup.Custom08);
                    CustomActions.Add(9, KSPActionGroup.Custom09);
                    CustomActions.Add(10, KSPActionGroup.Custom10);
                    ErrLine = "3";
                    foreach (AGXAction agAct in actionsList.Where(agx => agx.group == group))
                    {
                        ErrLine = "4";

                        if (force) //are we forcing a direction or toggling?
                        {
                            ErrLine = "5";
                            if (forceDir) //we are forcing a direction so set the agAct.activated to trigger the direction below correctly
                            {
                                agAct.activated = false; //we are forcing activation so activated is false
                            }
                            else
                            {
                                agAct.activated = true;
                            }
                        }
                        ErrLine = "6";
                        if (agAct.activated)
                        {
                            ErrLine = "7";
                            KSPActionParam actParam = new KSPActionParam(KSPActionGroup.None, KSPActionType.Deactivate);
                            //print("AGX action deactivate FIRE! " + agAct.ba.guiName);
                            ErrLine = "8";
                            agAct.ba.Invoke(actParam);
                            ErrLine = "9";
                            if (group <= 10)
                            {
                                ErrLine = "10";
                                thisVsl.ActionGroups[CustomActions[group]] = false;
                            }
                            ErrLine = "11";
                        }
                        else
                        {
                            ErrLine = "12";
                            KSPActionParam actParam = new KSPActionParam(KSPActionGroup.None, KSPActionType.Activate);
                            //agAct.activated = true;
                            //print("AGX action activate FIRE!" + agAct.ba.guiName);
                            ErrLine = "13";
                            agAct.ba.Invoke(actParam);
                            ErrLine = "14";
                            if (group <= 10)
                            {
                                ErrLine = "15";
                                thisVsl.ActionGroups[CustomActions[group]] = true;
                            }
                            ErrLine = "16";
                        }
                        if (agAct.ba.listParent.module.moduleName == "ModuleEngines" && agAct.ba.name == "ActivateAction" || agAct.ba.listParent.module.moduleName == "ModuleEngines" && agAct.ba.name == "OnAction")
                        {
                            ErrLine = "17";
                            //overide to activate part when activating an engine so gimbals come on
                            agAct.ba.listParent.part.force_activate();
                            //print("Force act");

                        }
                        ErrLine = "18";
                        if (agAct.ba.listParent.module.moduleName == "ModuleEnginesFX" && agAct.ba.name == "ActivateAction" || agAct.ba.listParent.module.moduleName == "ModuleEnginesFX" && agAct.ba.name == "OnAction")
                        {
                            ErrLine = "19";
                            //overide to activate part when activating an engine so gimbals come on
                            agAct.ba.listParent.part.force_activate();
                            //print("Force act");
                            ErrLine = "20";
                        }
                        ErrLine = "21";
                    }
                    ErrLine = "22";
                }
        }
        catch(Exception e)
                        {
                            Debug.Log("AGX OtherVsl ActivateActionGroup " + ErrLine + " " + e);

    }

            }
        }
   

}//name space closing bracket

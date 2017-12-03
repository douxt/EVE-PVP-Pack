using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sandbox.Common;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Engine;
using Sandbox.Engine.Physics;
using Sandbox.Engine.Multiplayer;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using VRage.Common.Utils;
using VRageMath;
using VRage;
using VRage.ObjectBuilders;
using VRage.ModAPI;
using Sandbox.Game.EntityComponents;
using VRage.Game.Components;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Utils;
using VRage.Game.Entity;
using VRage.Game.Entity.UseObject;
using Sandbox.Game.Entities.Character;
using Sandbox.Game.Gui;
using SpaceEngineers.Game.ModAPI;

namespace Cython.EnergyShields
{
		
	 [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), true, "BlackShop")]
    public class BlackShop : MyGameLogicComponent
    {
        private MyObjectBuilder_EntityBase builder;
        private Sandbox.ModAPI.IMyAssembler m_generator;
        private IMyCubeBlock m_parent;

        Sandbox.ModAPI.IMyTerminalBlock terminalBlock;

		private static ulong frameShift = 0;
        private ulong Frame;
        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            m_generator = Entity as Sandbox.ModAPI.IMyAssembler;
            m_parent = Entity as IMyCubeBlock;
            builder = objectBuilder;

            Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME; //|= MyEntityUpdateEnum.EACH_FRAME

            terminalBlock = Entity as Sandbox.ModAPI.IMyTerminalBlock;
        }
        #region UpdateBeforeSimulation
        public override void UpdateBeforeSimulation100()
        {
            base.UpdateBeforeSimulation100();

            if (m_generator.IsWorking)
            {
                Frame = frameShift++;
                if (Frame % 30 != 0)
                {
                    return;
                }

    //            IMyInventory inventory = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(0) as IMyInventory;

    //            if (!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
    //            {
    //                //inventory.AddItems(5, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
    //                //terminalBlock.RefreshCustomInfo();
    //            }
				//IMyInventory inventory1 = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(1) as IMyInventory;
				//if (!inventory1.ContainItems(10, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" }))
    //            {
    //                inventory1.AddItems(1, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" });
    //                terminalBlock.RefreshCustomInfo();
    //            }


                //List<IMyPlayer> players = new List<IMyPlayer>();
                //MyAPIGateway.Players.GetPlayers(players, x => x.Controller != null && x.Controller.ControlledEntity != null);
                //foreach (IMyPlayer player in players)
                //{
                //    if (player.Controller.ControlledEntity is IMyCharacter)
                //    {

                //        MyEntity entity = player.Controller.ControlledEntity.Entity as MyEntity;
                //        if (entity.HasInventory)
                //        {
                //            inventory = entity.GetInventoryBase() as MyInventory;
                //            if (!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
                //            {
                //                inventory.AddItems(5, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
                //                terminalBlock.RefreshCustomInfo();
                //            }
                //        }
                //    }

                //}


            }
        }
        #endregion
        public override MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false)
        {
            return builder;
        }

    }

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), true, "MoneyMaker")]
    public class MoneyMaker : MyGameLogicComponent
    {
        private MyObjectBuilder_EntityBase builder;
        private Sandbox.ModAPI.IMyAssembler m_generator;
        private IMyCubeBlock m_parent;

        Sandbox.ModAPI.IMyTerminalBlock terminalBlock;

        private static ulong frameShift = 0;
        private ulong Frame;
        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            m_generator = Entity as Sandbox.ModAPI.IMyAssembler;
            m_parent = Entity as IMyCubeBlock;
            builder = objectBuilder;

            Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME; //|= MyEntityUpdateEnum.EACH_FRAME

            terminalBlock = Entity as Sandbox.ModAPI.IMyTerminalBlock;
        }
        #region UpdateBeforeSimulation
        public override void UpdateBeforeSimulation100()
        {
            base.UpdateBeforeSimulation100();

            if (m_generator.IsWorking)
            {
                Frame = frameShift++;
                if (Frame % 30 != 0)
                {
                    return;
                }

                IMyInventory inventory = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(0) as IMyInventory;

                if (!inventory.ContainItems(20000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
                {
                    inventory.AddItems(300, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
                    terminalBlock.RefreshCustomInfo();
                }
                //IMyInventory inventory1 = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(1) as IMyInventory;
                //if (!inventory1.ContainItems(10, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" }))
                //{
                //    inventory1.AddItems(1, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" });
                //    terminalBlock.RefreshCustomInfo();
                //}


                //List<IMyPlayer> players = new List<IMyPlayer>();
                //MyAPIGateway.Players.GetPlayers(players, x => x.Controller != null && x.Controller.ControlledEntity != null);
                //foreach (IMyPlayer player in players)
                //{
                //    if (player.Controller.ControlledEntity is IMyCharacter)
                //    {

                //        MyEntity entity = player.Controller.ControlledEntity.Entity as MyEntity;
                //        if (entity.HasInventory)
                //        {
                //            inventory = entity.GetInventoryBase() as MyInventory;
                //            if (!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
                //            {
                //                inventory.AddItems(5, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
                //                terminalBlock.RefreshCustomInfo();
                //            }
                //        }
                //    }

                //}


            }
        }
        #endregion
        public override MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false)
        {
            return builder;
        }

    }

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CargoContainer), true, "FuBox")]
    public class FuBox : MyGameLogicComponent
    {
        private MyObjectBuilder_EntityBase builder;
        private Sandbox.ModAPI.IMyCargoContainer m_generator;
        private IMyCubeBlock m_parent;

        Sandbox.ModAPI.IMyTerminalBlock terminalBlock;

        private static ulong frameShift = 0;
        private ulong Frame;
        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            m_generator = Entity as Sandbox.ModAPI.IMyCargoContainer;
            m_parent = Entity as IMyCubeBlock;
            builder = objectBuilder;

            Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME; //|= MyEntityUpdateEnum.EACH_FRAME

            terminalBlock = Entity as Sandbox.ModAPI.IMyTerminalBlock;
        }
        #region UpdateBeforeSimulation
        public override void UpdateBeforeSimulation100()
        {
            base.UpdateBeforeSimulation100();

            if (m_generator.IsWorking)
            {
                Frame = frameShift++;
                if (Frame % 30 != 0)
                {
                    return;
                }

                //IMyInventory inventory = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(0) as IMyInventory;

                //if (!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
                //{
                //    inventory.AddItems(5, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
                //    terminalBlock.RefreshCustomInfo();
                //}
                //IMyInventory inventory1 = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(1) as IMyInventory;
                //if (!inventory1.ContainItems(10, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" }))
                //{
                //    inventory1.AddItems(1, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" });
                //    terminalBlock.RefreshCustomInfo();
                //}


                List<IMyPlayer> players = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(players, x => x.Controller != null && x.Controller.ControlledEntity != null);
                foreach (IMyPlayer player in players)
                {
                    if (player.Controller.ControlledEntity is IMyCharacter)
                    {

                        MyEntity entity = player.Controller.ControlledEntity.Entity as MyEntity;
                        if (entity.HasInventory)
                        {
                            IMyInventory inventory = entity.GetInventoryBase() as MyInventory;
                            if (!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
                            {
                                inventory.AddItems(60, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
                                terminalBlock.RefreshCustomInfo();
                            }
                        }
                    }

                }


            }
        }
        #endregion
        public override MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false)
        {
            return builder;
        }

    }

    //   [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Character),false,"Default_Astronaut")]
    //  public class SurvivalPlayer : MyGameLogicComponent
    //  {
    //      MyObjectBuilder_EntityBase m_objectBuilder = null;
    //      IMyCharacter player;
    //      MyInventory inventory;
    //      MyObjectBuilder_Component componentBuilder;
    //      string componentToAdd = "SteelPlate";

    //      //if you suscribed to events, please always unsuscribe them in close method 
    //      public override void Close()
    //      {
    //      }


    //private static ulong frameShift = 0;
    //      private ulong Frame;

    //      public override void Init(MyObjectBuilder_EntityBase objectBuilder)
    //      {

    //          Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME;
    //          player = Entity as IMyCharacter;
    //          MyEntity entity = Entity as MyEntity;
    //          if(entity.HasInventory)
    //          {
    //              inventory = entity.GetInventoryBase() as MyInventory;
    //          }
    //          componentBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Component>(componentToAdd);
    //      }

    //      public override MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false)
    //      {
    //          return m_objectBuilder;
    //      }

    //      public override void UpdateBeforeSimulation100()
    //      {
    //	//base.UpdateBeforeSimulation100();
    //	Frame = frameShift++;
    //          //MyPhysicalInventoryItem? existingComponent = inventory.FindItem(componentBuilder.GetId());
    //          if (Frame % 30 != 0) {
    //		return;
    //	}
    //	if(!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" })){
    //		//inventory.AddItems(100, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
    //	}




    //      }
    //  }

}


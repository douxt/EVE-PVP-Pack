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
using VRage.Game.Entity.UseObject;
using Sandbox.Game.Entities.Character;
using Sandbox.Game.Gui;

namespace Cython.EnergyShields
{
		
	 [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), true, "BlackShop")]
    public class BlackShop : MyGameLogicComponent
    {
        private MyObjectBuilder_EntityBase builder;
        private Sandbox.ModAPI.IMyAssembler m_generator;
        private IMyCubeBlock m_parent;

        Sandbox.ModAPI.IMyTerminalBlock terminalBlock;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            m_generator = Entity as Sandbox.ModAPI.IMyAssembler;
            m_parent = Entity as IMyCubeBlock;
            builder = objectBuilder;

            Entity.NeedsUpdate |= MyEntityUpdateEnum.EACH_FRAME | MyEntityUpdateEnum.EACH_100TH_FRAME;

            terminalBlock = Entity as Sandbox.ModAPI.IMyTerminalBlock;
        }
        #region UpdateBeforeSimulation
        public override void UpdateBeforeSimulation100()
        {
            base.UpdateBeforeSimulation100();

            if (m_generator.IsWorking)
            {
				IMyInventory inventory = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(0) as IMyInventory;

                if (!inventory.ContainItems(10000, new MyObjectBuilder_Ingot { SubtypeName = "Coin" }))
                {
                    inventory.AddItems(5, new MyObjectBuilder_Ingot { SubtypeName = "Coin" });
                    terminalBlock.RefreshCustomInfo();
                }
				IMyInventory inventory1 = ((Sandbox.ModAPI.IMyTerminalBlock)Entity).GetInventory(1) as IMyInventory;
				if (!inventory1.ContainItems(10, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" }))
                {
                    inventory1.AddItems(1, new MyObjectBuilder_AmmoMagazine { SubtypeName = "NATO_25x184mm" });
                    terminalBlock.RefreshCustomInfo();
                }

            }
        }
        #endregion
        public override MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false)
        {
            return builder;
        }

    }

	}


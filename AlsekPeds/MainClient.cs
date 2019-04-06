using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace AlsekPeds
{
    public class MainClient : BaseScript
    {
        public MainClient()
        {
            API.RegisterCommand("PedA", new Action<int, List<object>, string>((source, arguments, raw) => { Ped(); }), false);
        }

        private bool PedAnim = false;
        private async void Ped()
        {
            await Delay(0);
            if (!PedAnim)
            {
                PedAnim = true;
                var PlayerCoords = GetEntityCoords(PlayerPedId(), true);
                TaskUseNearestScenarioToCoord(PlayerPedId(), PlayerCoords.X, PlayerCoords.Y, PlayerCoords.Z, 30, 0);
            }
            else
            {
                PedAnim = false;
                ClearPedTasksImmediately(PlayerPedId());
            }
        }
    }
}
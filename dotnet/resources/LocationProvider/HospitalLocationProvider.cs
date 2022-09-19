using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace LocationProvider
{
    public static class HospitalLocationProvider
    {
        private static List<Vector3> HospitalPositions { get; }
        
        static HospitalLocationProvider()
        {
            string file = File.ReadAllText("dotnet/runtime/hospitalsCoords.json");
            HospitalPositions = JsonConvert.DeserializeObject<List<Vector3>>(file);
        }

        public static Vector3 GetNearest(Vector3 playerPosition) => HospitalPositions
            .OrderBy(hospitalPosition => hospitalPosition.DistanceTo2D(playerPosition))
            .First();
    }
}
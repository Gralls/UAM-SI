using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SZI
{
    class WeatherFactory
    {
        public enum WeatherTypesEnum
        {
            sunny, cloudy, snowy, rainy
        }
        private static WeatherFactory inst = null;
        public static WeatherFactory GetInst()
        {
            if (inst == null)
                inst = new WeatherFactory();
            return inst;
        }
        public interface IWeatherType
        {
            string name { get; set; }
            bool shouldWater { get; set; }
            WeatherFactory.WeatherTypesEnum type { get; set; }
        }
        class Weather : AbstractTerrainType
        {
            public Weather(string name, WeatherFactory.WeatherTypesEnum type) : base(40, true, name, type)
            {
            }
        }
        public AbstractWeatherType CreateSunnyWeatherTile()
        {
            return new Weather("słonecznie", WeatherTypesEnum.sunny);
        }

        public AbstractWeatherType CreateCloudyWeatherTile()
        {
            return new Weather("pochmurnie", WeatherTypesEnum.cloudy);
        }

        public AbstractWeatherType CreateSnowyWeatherTile()
        {
            return new Weather("śnieżnie", WeatherTypesEnum.snowy);
        }
        public AbstractWeatherType CreateRainyWeatherTile()
        {
            return new Weather("deszczowo", WeatherTypesEnum.rainy);
        }
        public AbstractWeatherType CreateWeatherType(WeatherTypesEnum type)
        {
            AbstractWeatherType terrainType;
            switch (type)
            {
                case WeatherTypesEnum.sunny: terrainType = CreateSunnyWeatherTile(); break;
                case WeatherTypesEnum.cloudy: terrainType = CreateCloudyWeatherTile(); break;
                case WeatherTypesEnum.snowy: terrainType = CreateSnowyWeatherTile(); break;
                case WeatherTypesEnum.rainy: terrainType = CreateRainyWeatherTile(); break;
                default: terrainType = CreateSunnyWeatherTile(); break;
            }

            return terrainType;
        }
        public AbstractWeatherType GetWeatherTypeFromTerrainName(string name)
        {
            Regex reg = new Regex("sunny*");
            if (reg.IsMatch(name))
                return CreateWeatherType(WeatherTypesEnum.sunny);
            reg = new Regex("cloudy*");
            if (reg.IsMatch(name))
                return CreateWeatherType(WeatherTypesEnum.snowy);
            reg = new Regex("snowy*");
            if (reg.IsMatch(name))
                return CreateWeatherType(WeatherTypesEnum.cloudy);
            reg = new Regex("rainy*");
            if (reg.IsMatch(name))
                return CreateWeatherType(WeatherTypesEnum.rainy);
            //default
            return CreateWeatherType(WeatherTypesEnum.sunny);

        }
        public class AbstractWeatherType : IWeatherType
        {
            public bool shouldWater { get; set; }
            public string name { get; set; }
            public TerrainFactory.TerrainTypesEnum type { get; set; }
            protected AbstractWeatherType(int moveCost, bool passable, string name, WeatherFactory.WeatherTypesEnum type)
            {
                this.shouldWater = shouldWater;
                this.name = name;
                this.type = type;
            }
        }
    }
}

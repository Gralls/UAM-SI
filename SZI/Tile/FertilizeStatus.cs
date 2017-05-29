namespace SZI
{
    public class FertilizeStatus
    {
        int isFertilizedAbove = 5;
        public FertilizeStatus(bool isFertilized)
        {
            this.isFertilized = isFertilized;
            if (isFertilized)
                fertilizeLevel = 8;
            else
                fertilizeLevel = 3;
        }

        public void Fertilize()
        {
            isFertilized = true;
            fertilizeLevel = 10;
        }

        public bool isFertilized { get; set; }

        int fertilizeLevel;

        public void NextTurn()
        {
            fertilizeLevel--;
            if (fertilizeLevel < 0)
                fertilizeLevel = 0;
            if (fertilizeLevel < isFertilizedAbove && isFertilized)
                isFertilized = false;
            else if (fertilizeLevel > isFertilizedAbove && !isFertilized)
                isFertilized = true;
            if (fertilizeLevel > 10)
                fertilizeLevel = 10;
        }

        public string GetID3String()
        {
            if (isFertilized)
                return TileParameters.SoilEnoughFertilizer;
            return TileParameters.SoilNotEnoughFertilizer;
        }

        public string FertilizeStringInfo()
        {
            if (isFertilized)
                return "Nawożone";
            return "Potrzebne nawożenie";
        }
    }
}
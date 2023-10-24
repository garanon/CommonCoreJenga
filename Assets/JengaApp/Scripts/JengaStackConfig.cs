namespace JengaApp
{
    public struct JengaStackConfig
    {
        #region Properties

        public int TotalNumBlocks => Blocks.Length;

        public string Label { get; set; }
        public IJengaBlockData[] Blocks { get; set; }

        #endregion

        #region Fields

        public const int NumBlocksPerRow = 3;

        #endregion
    }
}
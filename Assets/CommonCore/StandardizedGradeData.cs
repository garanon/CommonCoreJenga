namespace CommonCore
{
    public interface IStandardizedGradeData
    {
        #region Properties

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        public int Mastery { get; set; }
        public string DomainId { get; set; }
        public string Domain { get; set; }
        public string Cluster { get; set; }
        public string StandardId { get; set; }
        public string StandardDescription { get; set; }

        #endregion
    }
}
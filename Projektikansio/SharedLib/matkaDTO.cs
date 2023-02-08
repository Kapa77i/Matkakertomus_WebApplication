namespace SharedLib
{
    public class matkaDTO
    {
        public long idmatkaaja { get; set; }
        public virtual matkaajaDTO MatkaajaDTO { get; set; }
        public DateTime alkupvm { get; set; }
        public DateTime loppupvm { get; set; }
        public long yksityinen { get; set; }
        public long idmatka { get; set; }

        public virtual ICollection<tarinaDTO> Tarina { get; set; }
    }
}
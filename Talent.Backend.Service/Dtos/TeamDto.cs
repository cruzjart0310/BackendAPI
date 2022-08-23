namespace Talent.Backend.Service.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[NotMapped]
        //public ICollection<TeamUserDto> Users { get; set; }
    }
}

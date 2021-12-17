namespace PokaList.Application.Dtos
{
    public class PokaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}

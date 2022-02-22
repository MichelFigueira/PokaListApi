namespace PokaList.Application.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string DefaultData { get; set; }
        public bool socialLogin { get; set; }
        public string PhotoURL { get; set; }
    }
}

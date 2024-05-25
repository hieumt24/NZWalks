namespace NZWalks.API.Models.Response
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public IList<string> Roles { get; set; }
    }
}